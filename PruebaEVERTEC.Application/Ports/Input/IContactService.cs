
using PruebaEVERTEC.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Application.Ports.Input
{
    public interface IContactService
    {
        Task<List<ContactResponse>> ListContacts();
    }
}
