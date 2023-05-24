
using PruebaEVERTEC.Domain.Entities.Common;
using System;

namespace PruebaEVERTEC.Domain.Entities
{
    public class Contact: BaseEntity<long>
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; }
        public TechQuote TechQuote { get; set; }
    }
}
