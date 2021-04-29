using FluentAssertions;
using Newtonsoft.Json.Linq;
using Pokemons.Pokemons.Api.Test.Converter;
using Pokemons.Pokemons.Api.Test.Drivers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Pokemons.Pokemons.Api.Test.Steps
{
    [Binding, Scope(Feature = "Pokemons")]
    public class PokemonsSteps
    {
        private readonly WebApiDriver _driver;

        private int _id;
        private HttpResponseMessage _response;

        public PokemonsSteps(WebApiDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        [Given(@"I have '(.*)' as argument")]
        public void GivenIHaveAsArgument(int id)
        {
            _id = id;
        }

        [When(@"I send a request to Pokemons.Pokemons.Api")]
        public async Task WhenISendARequestToWebAPI()
        {
            _response = await _driver.GetPokemons(_id);
        }

        [Then(@"I get a pokemon with id '(.*)' and name '(.*)' with types '(.*)'")]
        public async Task ThenIGetAsPokemon(int id, string pokemon, params string[] types)
        {
            _response.EnsureSuccessStatusCode();

            var content = await _response.Content.ReadAsStreamAsync();
            var outputDeserialized = await Deserialize(content);
            var output = JsonToPokemonResponseConverter.Execute(outputDeserialized);

            output.PokemonId.Should().Be(id);
            output.PokemonName.Should().BeEquivalentTo(pokemon);
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
