using PokemonType.Domain.Dto;
using PokemonType.Domain.Services;

namespace PokemonType.Infrastructure.Services
{
    public class GetPokemonType : IGetPokemonType
    {
        public PokemonTypeDto GetPokemonTypeByName(string name)
        {
            //llamar a la api de terceros
            return new PokemonTypeDto();
        }
    }
}