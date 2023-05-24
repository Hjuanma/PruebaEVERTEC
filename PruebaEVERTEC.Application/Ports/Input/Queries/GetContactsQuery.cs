using MediatR;
using PruebaEVERTEC.Application.DTOs;
using System.Collections.Generic;

namespace PruebaEVERTEC.Application.Ports.Input.Queries
{
    public class GetContactsQuery : IRequest<List<ContactResponse>>
    {
    }
}
