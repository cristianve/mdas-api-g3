using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Users.Users.Api.Test.Converter;
using Users.Users.Api.Test.Drivers;

namespace Users.Users.Api.Test.Steps
{
    [Binding, Scope(Feature = "Pokemon Favorites")]
    public class PokemonFavoriteStepDefinitions
    {
        private readonly WebApiDriver _driver;

        private string _userId;
        private int _pokemonId;

        public PokemonFavoriteStepDefinitions(WebApiDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        [Given(@"I have '(.*)' and '(.*)' as argument")]
        public void GivenIHaveAsArgument(string userId, int pokemonId)
        {
            _userId = userId;
            _pokemonId = pokemonId;
        }

        [When(@"I send a request to Users.Users.Api")]
        public async Task WhenISendARequestToWebAPI()
        {
            var responseUser = await _driver.CreateUser(_userId);
            responseUser.EnsureSuccessStatusCode();

            var responseFavorites = await _driver.SaveFavorites(_userId, _pokemonId);
            responseFavorites.EnsureSuccessStatusCode();
        }

        [Then(@"I get '(.*)' as favorite after request favorites")]
        public async Task ThenIPerformAGetFavorites(params int[] favorites)
        {
            var response = await _driver.GetFavorites(_userId);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();
            var outputDeserialized = await Deserialize(content);
            var output = JsonToPokemonFavoritesResponseConverter.Execute(outputDeserialized);

            output.Favorites.Should().BeEquivalentTo(favorites);
        }

        [StepArgumentTransformation]
        public static int[] ToStringArray(string commaSeparatedArray)
        {
            return commaSeparatedArray
                .Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToArray();
        }

        private static async Task<JObject> Deserialize(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return JObject.Parse(reader.ReadToEnd());
        }
    }
}
