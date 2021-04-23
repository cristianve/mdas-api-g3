﻿using System;
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

        [HttpPut("user/addFavorite/{pokemonName}")]
        public async Task<IActionResult> Put([Required] [FromHeader(Name = "userId")]
            string userId, string pokemonName)
        {
            try
            {
                await _addPokemonToUserFavorites.Execute(userId, pokemonName);
                return Accepted();
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}