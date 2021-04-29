using System;
using System.Linq;
using System.Threading.Tasks;
using Pokemons.Types.Domain.Test.ValueObject;
using Pokemons.Types.Domain.ValueObject;
using Xunit;

namespace Pokemons.Types.Persistence.Test
{
    public class PokeApiPokemonTypeRepositoryTest
    {
        [Fact]
        public async Task Search_Found_ReturnsTypes()
        {
            #region Arrange

            PokeApiPokemonTypeRepository pokemonTypeRepository = new PokeApiPokemonTypeRepository();
            PokemonName pokemonName = new PokemonName() { Name = PokemonNameMother.Name() };

            #endregion

            #region Act
            PokemonTypes pokemonTypes = await pokemonTypeRepository.Search(pokemonName);

            #endregion

            #region Assert
            var typesArray = pokemonTypes.Types.Select(s => s.PokemonTypeName.Name).ToArray();
            Assert.Equal(typesArray, PokemonTypesMother.PokemonTypes().Types.Select(s => s.PokemonTypeName.Name).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public async Task Search_NotFound_ReturnsNull()
        {
            #region Arrange

            PokeApiPokemonTypeRepository pokemonTypeRepository = new PokeApiPokemonTypeRepository();
            PokemonName pokemonName = new PokemonName() { Name = PokemonNameMother.Random() };

            #endregion

            #region Act
            PokemonTypes pokemonTypes = await pokemonTypeRepository.Search(pokemonName);

            #endregion

            #region Assert
            Assert.Null(pokemonTypes);

            #endregion
        }
    }
}
