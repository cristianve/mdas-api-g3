using PokemonType.Domain.Dto;

namespace PokemonType.Domain.Services
{
    public interface IGetPokemonType
    {
        PokemonTypeDto GetPokemonTypeByName(string name);
    }
}