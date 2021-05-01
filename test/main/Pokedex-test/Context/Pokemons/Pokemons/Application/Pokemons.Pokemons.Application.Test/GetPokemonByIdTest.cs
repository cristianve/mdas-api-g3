using Moq;
using Pokemons.Pokemons.Application.UseCase;
using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.Services;
using Pokemons.Pokemons.Domain.Test.Aggregate;
using Pokemons.Pokemons.Domain.Test.ValueObject;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pokemons.Pokemons.Application.Test
{
    public class GetPokemonByIdTest
    {
        [Fact]
        public async Task GetPokemonById_ReturnsPokemon()
        {
            #region Arrange
            int pokemonId = PokemonIdMother.Id();
            var pokemonRepository = new Mock<PokemonRepository>();

            pokemonRepository
                .Setup(r => r.Find(It.IsAny<PokemonId>()))
                .ReturnsAsync(PokemonMother.Pokemon());

            pokemonRepository
                .Setup(r => r.Exists(It.IsAny<PokemonId>()))
                .ReturnsAsync(true);

            PokemonFinder pokemonFinder = new PokemonFinder(pokemonRepository.Object);
            GetPokemonById getPokemonById = new GetPokemonById(pokemonFinder);

            #endregion

            #region Act
            Pokemon pokemon = await getPokemonById.Execute(pokemonId);

            #endregion

            #region Assert
            Assert.Equal(pokemon.PokemonId.Id, PokemonMother.Pokemon().PokemonId.Id);
            Assert.Equal(pokemon.PokemonName.Name, PokemonMother.Pokemon().PokemonName.Name);
            Assert.Equal(pokemon.PokemonTypes.Types.Select(s => s.Type).ToArray(), PokemonMother.Pokemon().PokemonTypes.Types.Select(s => s.Type).ToArray());

            #endregion
        }

        [Fact]
        public void GetPokemonById_NotFound_ReturnsException()
        {
            #region Arrange
            int pokemonId = PokemonIdMother.Id();
            var pokemonRepository = new Mock<PokemonRepository>();
            string expectedMessage = $"Pokemon with Id '{pokemonId}' does not exist";
            
            pokemonRepository
                .Setup(r => r.Find(It.IsAny<PokemonId>()))
                .ReturnsAsync(PokemonMother.Pokemon());

            PokemonFinder pokemonFinder = new PokemonFinder(pokemonRepository.Object);
            GetPokemonById getPokemonById = new GetPokemonById(pokemonFinder);

            #endregion

            #region Act
            var exception = Record.ExceptionAsync(async () => await getPokemonById.Execute(pokemonId));

            #endregion

            #region Assert
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}
