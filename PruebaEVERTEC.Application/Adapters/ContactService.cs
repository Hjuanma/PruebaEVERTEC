
using AutoMapper;
using PruebaEVERTEC.Application.DTOs;
using PruebaEVERTEC.Application.Ports.Input;
using PruebaEVERTEC.Application.Ports.Output.Repositories;
using PruebaEVERTEC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Application.Adapters
{
    public class ContactService : IContactService
    {

        private readonly IContactRepository _contactRepository;
        private readonly ITechQuoteRepository _techQuoteRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, ITechQuoteRepository techQuoteRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _techQuoteRepository = techQuoteRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactResponse>> ListContacts()
        {
            List<Contact> contacts = await _contactRepository.FindAll();
            List<TechQuote> techQuotes = await _techQuoteRepository.FindAll();
            Random random = new Random();
            foreach (var contact in contacts)
            {
                contact.TechQuote = techQuotes[random.Next(0, techQuotes.Count)];
            }

            List<ContactResponse> contactsResponse = _mapper.Map<List<ContactResponse>>(contacts);
            return contactsResponse;
        }
    }
}
