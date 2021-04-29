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
        private readonly AddPokemonToUserFavorites _addPokemonToUserFavorites;
        private readonly GetPokemonUserFavorites _getPokemonUserFavorites;

        public PokemonFavoriteController(AddPokemonToUserFavorites addPokemonToUserFavorites,
            GetPokemonUserFavorites getPokemonUserFavorites)
        {
            _addPokemonToUserFavorites = addPokemonToUserFavorites;
            _getPokemonUserFavorites = getPokemonUserFavorites;
        }

        [HttpPut("user/addFavorite/{pokemonId}")]
        public async Task<IActionResult> Put([Required] [FromHeader(Name = "userId")]
            string userId, int pokemonId)
        {
            try
            {
                await _addPokemonToUserFavorites.Execute(userId, pokemonId);
                return Created($"user/addFavorite/{pokemonId}", pokemonId);
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
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

        [HttpGet("user/favorites")]
        public async Task<IActionResult> Get([Required] [FromHeader(Name = "userId")]
            string userId)
        {
            try
            {
                return Ok(await _getPokemonUserFavorites.Execute(userId));
            }
            catch (UserNotFoundException ex)
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