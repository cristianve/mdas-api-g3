using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemon.Type.Domain.ValueObject;

namespace Pokemon.Type.Domain.Service
{
    public interface IPokemonTypeRepository
    {
        Task<IEnumerable<PokemonType>> Find(string pokemonName);
    }
}
