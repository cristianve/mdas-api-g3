﻿using Pokemons.Pokemons.Domain.ValueObject;

namespace Pokemons.Pokemons.Domain.Aggregate
{
    public class Pokemon
    {
        public PokemonId PokemonId { get; }
        public PokemonName PokemonName { get; }
        public PokemonTypes PokemonTypes { get; }

        public PokemonFavouriteCount PokemonFavouriteCount { get; }
        
        public Pokemon(PokemonId pokemonId, PokemonName pokemonName, PokemonTypes pokemonTypes, PokemonFavouriteCount pokemonFavouriteCount)
        {
            PokemonId = pokemonId;
            PokemonName = pokemonName;
            PokemonTypes = pokemonTypes;
            PokemonFavouriteCount = pokemonFavouriteCount;
        }
    }
}
