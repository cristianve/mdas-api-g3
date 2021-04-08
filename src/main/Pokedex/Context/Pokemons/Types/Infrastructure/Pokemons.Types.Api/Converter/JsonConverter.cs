using Newtonsoft.Json;

namespace Pokemons.Types.Api.Converter
{
    public class JsonConverter 
    {
        public static string Execute(dynamic dynamicData)
        {
            return JsonConvert.SerializeObject(dynamicData);
        }
    }
}
