
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Infrastructure.Clients
{
    public interface IHttpCLient<T>
    {
        Task<List<T>> GetListAsync(string url);
    }
}
