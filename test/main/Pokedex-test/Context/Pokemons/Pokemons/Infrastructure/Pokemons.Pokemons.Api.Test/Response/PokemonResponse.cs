namespace Pokemons.Pokemons.Api.Test.Response
{
    public class PokemonResponse
    {
        public int PokemonId { get; }
        public string PokemonName { get; }
        public string[] Types { get; }

        public PokemonResponse(int pokemonId, string pokemonName, string[] types)
        {
            PokemonId = pokemonId;
            PokemonName = pokemonName;
            Types = types;
        }
    }
}
