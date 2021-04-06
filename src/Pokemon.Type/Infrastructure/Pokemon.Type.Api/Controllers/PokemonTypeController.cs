using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Type.Application.UseCase;

namespace PokemonType.Api.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokemonTypeController : ControllerBase
    {
        private readonly GetPokemonType _getPokemonType;

        public PokemonTypeController(GetPokemonType getPokemonType)
        {
            _getPokemonType = getPokemonType;
        }

        [HttpGet("{name}/types")]
        public async Task<IActionResult> Get(string name)
        {
            var types = await _getPokemonType.Execute(name);

            return Ok(types);
        }
    }
}
