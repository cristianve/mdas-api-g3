using FluentAssertions;
using Newtonsoft.Json.Linq;
using Pokemons.Types.Api.Test.Converter;
using Pokemons.Types.Api.Test.Drivers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Pokemons.Types.Api.Test.Steps
{
    [Binding, Scope(Feature = "Pokemon Types")]
    public class PokemonTypesStepDefinitions
    {
        private readonly WebApiDriver _driver;

        private string _name;
        private HttpResponseMessage _response;

        public PokemonTypesStepDefinitions(WebApiDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        [Given(@"I have '(.*)' as argument")]
        public void GivenIHaveAsArgument(string name)
        {
            _name = name;
        }

        [When(@"I send a request to Pokemons.Types.Api")]
        public async Task WhenISendARequestToWebAPI()
        {
            _response = await _driver.GetTypes(_name);
        }

        [Then(@"I get types '(.*)'")]
        public async Task ThenIGetAsPokemon(params string[] types)
        {
            _response.EnsureSuccessStatusCode();

            var content = await _response.Content.ReadAsStreamAsync();
            var outputDeserialized = await Deserialize(content);
            var output = JsonToPokemonTypesResponseConverter.Execute(outputDeserialized);

            output.Types.Should().BeEquivalentTo(types);
        }

        [Then(@"I get an error response")]
        public void ThenIGetAnErrorResponse()
        {
            _response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [StepArgumentTransformation]
        public static string[] ToStringArray(string commaSeparatedArray)
        {
            return commaSeparatedArray
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        private static async Task<JObject> Deserialize(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return JObject.Parse(reader.ReadToEnd());
        }
    }
}
