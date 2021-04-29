using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Test.Aggregate;
using Pokemons.Pokemons.Domain.Test.ValueObject;
using Pokemons.Pokemons.Domain.ValueObject;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pokemons.Pokemons.Persistence.Test
{
    public class PokeApiPokemonRepositoryTest
    {
        [Fact]
        public async Task Search_Found_ReturnsTypes()
        {
            #region Arrange

            PokeApiPokemonRepository pokemonRepository = new PokeApiPokemonRepository();
            PokemonId pokemonId = new PokemonId(PokemonIdMother.Id());

            #endregion

            #region Act
            Pokemon pokemon = await pokemonRepository.Find(pokemonId);

            #endregion

            #region Assert
            var typesArray = pokemon.PokemonTypes.Types.Select(s => s.Type).ToArray();

            Assert.Equal(pokemon.PokemonId.Id, PokemonMother.Pokemon().PokemonId.Id);
            Assert.Equal(pokemon.PokemonName.Name, PokemonMother.Pokemon().PokemonName.Name);
            Assert.Equal(typesArray, PokemonMother.Pokemon().PokemonTypes.Types.Select(s => s.Type).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public async Task Search_NotFound_ReturnsNull()
        {
            #region Arrange

            PokeApiPokemonRepository pokemonRepository = new PokeApiPokemonRepository();
            PokemonId pokemonId = new PokemonId(PokemonIdMother.IdUnknown());

            #endregion

            #region Act
            Pokemon pokemon = await pokemonRepository.Find(pokemonId);

            #endregion

            #region Assert
            Assert.Null(pokemon);

            #endregion
        }
    }
}
