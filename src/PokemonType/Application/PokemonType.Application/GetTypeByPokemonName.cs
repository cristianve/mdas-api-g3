using PokemonType.Domain.Entities;
using PokemonType.Domain.Services;

namespace PokemonType.Application
{
    public class GetTypeByPokemonName
    {
        private readonly IGetPokemonType _pokemonType;

        public GetTypeByPokemonName(IGetPokemonType pokemonType)
        {
            _pokemonType = pokemonType;
        }

        public Type Execute(string pokemonName)
        {
            var pokemonTypeDto = _pokemonType.GetPokemonTypeByName(pokemonName);
            // return  Servicio.DevuelveNuestroType(pokemonTypeDto);
            return new Type();
        }
    }
}