
using PruebaEVERTEC.Application.Ports.Output.Repositories;
using PruebaEVERTEC.Domain.Entities;
using PruebaEVERTEC.Infrastructure.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Infrastructure.Adapters
{
    public class ContactRepository : IContactRepository
    {

        private readonly IHttpCLient<Contact> _contactHttpClient;

        public ContactRepository(IHttpCLient<Contact> contactHttpClient)
        {
            _contactHttpClient = contactHttpClient;
        }

        public async Task<List<Contact>> FindAll()
        {
            List<Contact> contacts = await _contactHttpClient.GetListAsync("GetUser");
            return contacts;
        }

    }
}
