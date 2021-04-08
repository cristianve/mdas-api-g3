using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Types.Api.Converter;
using Pokemons.Types.Application.Request;
using Pokemons.Types.Application.UseCase;
using Pokemons.Types.Domain.Exceptions;

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
            try
            {
                var response = await _getPokemonType.Execute(
                    new GetPokemonTypeRequest()
                    {
                        PokemonName = name
                    });

                return Ok(JsonConverter.Execute(response));
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
