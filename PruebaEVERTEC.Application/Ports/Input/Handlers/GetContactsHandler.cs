
using MediatR;
using PruebaEVERTEC.Application.DTOs;
using PruebaEVERTEC.Application.Ports.Input.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Application.Ports.Input.Handlers
{
    public class GetContactsHandler : IRequestHandler<GetContactsQuery, List<ContactResponse>>
    {

        private readonly IContactService _contactService;

        public GetContactsHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<List<ContactResponse>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            List<ContactResponse> response = await _contactService.ListContacts();
            return response;
        }
    }
}
