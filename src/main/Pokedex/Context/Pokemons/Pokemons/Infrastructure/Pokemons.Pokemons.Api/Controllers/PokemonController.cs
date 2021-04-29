using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Pokemons.Api.Converter;
using Pokemons.Pokemons.Application.UseCase;
using Pokemons.Pokemons.Domain.Exceptions;

namespace Pokemons.Details.Api.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokemonController : ControllerBase
    {
        private readonly GetPokemon _getPokemon;

        public PokemonController(GetPokemon getPokemon)
        {
            _getPokemon = getPokemon;
        }

        [HttpGet("{id}/pokemons")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(PokemonToJsonConverter.Execute(await _getPokemon.Execute(id)));
            }
            catch (PokemonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
