namespace Pokemons.Types.Api.Test.Response
{
    public class PokemonTypesResponse
    {
        public string[] Types { get; }

        public PokemonTypesResponse(string[] types)
        {
            Types = types;
        }
    }
}
