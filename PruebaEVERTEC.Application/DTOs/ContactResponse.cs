
using PruebaEVERTEC.Domain.Entities;
using System;

namespace PruebaEVERTEC.Application.DTOs
{
    public class ContactResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public TechQuote TechQuote { get; set; }
    }
}
