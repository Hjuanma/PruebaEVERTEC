
using PruebaEVERTEC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Application.Ports.Output.Repositories
{
    public interface ITechQuoteRepository
    {
        Task<List<TechQuote>> FindAll();
    }
}
