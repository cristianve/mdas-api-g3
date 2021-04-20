using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Exceptions;

namespace Users.Users.Api.Controllers
{
    [ApiController]
    [Route("pokedex")]
    public class PokemonFavoriteController : ControllerBase
    {
        private readonly AddPokemonToFavorites _addPokemonToFavorites;
        private readonly GetPokemonFavorites _getPokemonFavorites;

        public PokemonFavoriteController(AddPokemonToFavorites addPokemonToFavorites,
            GetPokemonFavorites getPokemonFavorites)
        {
            _addPokemonToFavorites = addPokemonToFavorites;
            _getPokemonFavorites = getPokemonFavorites;
        }

        [HttpPut("favorites/{pokemonName}")]
        public async Task<IActionResult> Put([Required][FromHeader(Name = "userId")] string userId, string pokemonName)
        {
            try
            {
                return Accepted(await _addPokemonToFavorites.Execute(userId, pokemonName));
            }
            catch (PokemonFavoriteExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("favorites")]
        public async Task<IActionResult> Get([Required][FromHeader(Name = "userId")] string userId)
        {
            try
            {
                return Ok(await _getPokemonFavorites.Execute(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
