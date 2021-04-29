using Newtonsoft.Json.Linq;
using Shared.Domain.Exceptions;
using Shared.Domain.Services;
using Shared.Domain.ValueObject;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Http
{
    public class HttpRequest : Request
    {
        private HttpClient _httpClient;

        public HttpRequest()
        {
            _httpClient = new HttpClient();
        }

        public async Task<JObject> Get(UrlRequest urlRequest)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlRequest.Url);
                using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode == false)
                    {
                        var message = await response.Content.ReadAsStringAsync();

                        if ((int)response.StatusCode == 404)
                        {
                            throw new HttpNotFoundException(message);
                        }

                        throw new Exception(message);
                    }

                    var stream = await response.Content.ReadAsStreamAsync();

                    StreamReader reader = new StreamReader(stream);
                    return JObject.Parse(reader.ReadToEnd());
                }
            }
            catch (HttpNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new HttpException();
            }
        }
    }
}
