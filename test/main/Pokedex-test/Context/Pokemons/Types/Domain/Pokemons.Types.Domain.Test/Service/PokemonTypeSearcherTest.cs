using Moq;
using Pokemons.Types.Domain.Aggregate;
using Pokemons.Types.Domain.Service;
using Pokemons.Types.Domain.Test.ValueObject;
using Pokemons.Types.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pokemons.Types.Domain.Test.Service
{
    public class PokemonTypeSearcherTest
    {
        [Fact]
        public async Task PokemonTypeSearcher_ReturnsTypes()
        {
            #region Arrange
            string name = PokemonNameMother.Name();
            PokemonName pokemonName = new PokemonName() { Name = name };
            var pokemonTypeRepository = new Mock<PokemonTypeRepository>();

            pokemonTypeRepository
                .Setup(r => r.Search(It.Is<PokemonName>(n => String.Equals(n.Name, name, StringComparison.InvariantCultureIgnoreCase))))
                .ReturnsAsync(PokemonTypesMother.PokemonTypes());

            var pokemonTypeSearcher = new PokemonTypeSearcher(pokemonTypeRepository.Object);

            #endregion

            #region Act
            PokemonTypes pokemonTypes = await pokemonTypeSearcher.Execute(pokemonName);
            
            #endregion

            #region Assert
            var typesArray = pokemonTypes.Types.Select(s => s.PokemonTypeName.Name).ToArray();
            Assert.Equal(typesArray, PokemonTypesMother.PokemonTypes().Types.Select(s => s.PokemonTypeName.Name).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public void PokemonTypeSearcher_ReturnsException()
        {
            #region Arrange
            string name = PokemonNameMother.Random();
            PokemonName pokemonName = new PokemonName() { Name = name };
            string expectedMessage = $"Pokemon '{name}' does not exist";
            var pokemonTypeRepository = new Mock<PokemonTypeRepository>();

            pokemonTypeRepository
                .Setup(r => r.Search(It.Is<PokemonName>(n => String.Equals(n.Name, name, StringComparison.InvariantCultureIgnoreCase))))
                .ReturnsAsync(null as PokemonTypes);

            var pokemonTypeSearcher = new PokemonTypeSearcher(pokemonTypeRepository.Object);

            #endregion

            #region Act
            var exception = Record.ExceptionAsync(async () => await pokemonTypeSearcher.Execute(pokemonName));

            #endregion

            #region Assert
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}
