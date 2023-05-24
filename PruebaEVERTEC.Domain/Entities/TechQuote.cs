
using PruebaEVERTEC.Domain.Entities.Common;

namespace PruebaEVERTEC.Domain.Entities
{
    public class TechQuote : BaseEntity<long>
    {
        public string Quote { get; set; }
    }
}
