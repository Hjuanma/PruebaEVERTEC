
using AutoMapper;
using PruebaEVERTEC.Application.DTOs;
using PruebaEVERTEC.Domain.Entities;

namespace PruebaEVERTEC.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactResponse>();
        }
    }
}
