using Newtonsoft.Json.Linq;
using Shared.Domain.ValueObject;
using System.Threading.Tasks;

namespace Shared.Domain.Services
{
    public interface Request
    {
        Task<JObject> Get(UrlRequest urlRequest);
    }
}
