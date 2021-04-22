using Moq;
using Pokemons.Types.Application.UseCase;
using Pokemons.Types.Domain.Aggregate;
using Pokemons.Types.Domain.Service;
using Pokemons.Types.Domain.Test.ValueObject;
using Pokemons.Types.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pokemons.Types.Application.Test.UseCase
{
    public class GetPokemonTypeTest
    {
        [Fact]
        public async Task GetPokemonType_ReturnsTypes()
        {
            #region Arrange
            string pokemonName = PokemonNameMother.Name();
            var pokemonTypeRepository = new Mock<PokemonTypeRepository>();

            pokemonTypeRepository
                .Setup(r => r.Search(It.Is<PokemonName>(n => String.Equals(n.Name, pokemonName, StringComparison.InvariantCultureIgnoreCase))))
                .ReturnsAsync(PokemonTypesMother.PokemonTypes());

            PokemonTypeSearcher pokemonTypeSearcher = new PokemonTypeSearcher(pokemonTypeRepository.Object);
            GetPokemonTypes getPokemonTypes = new GetPokemonTypes(pokemonTypeSearcher);

            #endregion

            #region Act
            PokemonTypes pokemonTypes = await getPokemonTypes.Execute(pokemonName);

            #endregion

            #region Assert
            Assert.Equal(pokemonTypes.Types.Select(s => s.PokemonTypeName.Name).ToArray(), PokemonTypesMother.PokemonTypes().Types.Select(s => s.PokemonTypeName.Name).ToArray());

            #endregion
        }

        [Fact]
        public void GetPokemonType_NotFound_ReturnsException()
        {
            #region Arrange
            string pokemonName = PokemonNameMother.Random();
            string expectedMessage = $"Pokemon '{pokemonName}' does not exist";

            var pokemonTypeRepository = new Mock<PokemonTypeRepository>();

            pokemonTypeRepository
                .Setup(r => r.Search(It.Is<PokemonName>(n => String.Equals(n.Name, pokemonName, StringComparison.InvariantCultureIgnoreCase))))
                .ReturnsAsync(null as PokemonTypes);

            PokemonTypeSearcher pokemonTypeSearcher = new PokemonTypeSearcher(pokemonTypeRepository.Object);
            GetPokemonTypes getPokemonTypes = new GetPokemonTypes(pokemonTypeSearcher);

            #endregion

            #region Act
            var exception = Record.ExceptionAsync(async () => await getPokemonTypes.Execute(pokemonName));

            #endregion

            #region Assert
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}
