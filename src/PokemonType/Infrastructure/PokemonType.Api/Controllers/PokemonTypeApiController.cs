using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonType.Application;
using PokemonType.Domain.Entities;
using PokemonType.Infrastructure.Services;

namespace PokemonType.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonTypeApiController : ControllerBase
    {
        private readonly ILogger<PokemonTypeApiController> _logger;
        private readonly GetTypeByPokemonName _getTypeByPokemonName;

        public PokemonTypeApiController(ILogger<PokemonTypeApiController> logger)
        {
            _logger = logger;
            _getTypeByPokemonName = new GetTypeByPokemonName(new GetPokemonType());
        }

        [HttpGet]
        public Type Get(string name)
        {
            _logger.LogTrace("getting pokemon type");
            return _getTypeByPokemonName.Execute(name);
        }
    }
}