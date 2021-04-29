using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Pokemons.Api.Converter;
using Pokemons.Pokemons.Application.UseCase;
using Pokemons.Pokemons.Domain.Exceptions;

namespace Pokemons.Pokemons.Api.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokemonController : ControllerBase
    {
        private readonly GetPokemonById _getPokemonById;

        public PokemonController(GetPokemonById getPokemon)
        {
            _getPokemonById = getPokemon;
        }

        [HttpGet("pokemons/pokemon/{pokemonId}")]
        public async Task<IActionResult> Get(int pokemonId)
        {
            try
            {
                return Ok(PokemonToJsonConverter.Execute(await _getPokemonById.Execute(pokemonId)));
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
