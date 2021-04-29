using FluentAssertions;
using Pokemons.Pokemons.Api.Test.Drivers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        [Then(@"I get '(.*)' as pokemon")]
        public async Task ThenIGetAsPokemon(string pokemon)
        {
            _response.EnsureSuccessStatusCode();

            var content = await _response.Content.ReadAsStreamAsync();
            var output = await Deserialize<string>(content);

            output.Should().BeEquivalentTo(pokemon);
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

        private static async Task<T> Deserialize<T>(Stream content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<T>(content, options);
        }
    }
}
