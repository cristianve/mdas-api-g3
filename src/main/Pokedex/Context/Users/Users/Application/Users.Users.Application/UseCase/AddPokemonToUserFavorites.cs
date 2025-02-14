﻿using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.Services;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Application.UseCase
{
    public class AddPokemonToUserFavorites
    {
        private readonly UserFinder _userFinder;
        private readonly PokemonFavoriteCreator _pokemonFavoriteCreator;
        private readonly EventPublisher _publisher;
        public AddPokemonToUserFavorites(UserFinder userFinder, PokemonFavoriteCreator pokemonFavoriteCreator,
            EventPublisher eventPublisher)
        {
            _userFinder = userFinder;
            _pokemonFavoriteCreator = pokemonFavoriteCreator;
            _publisher = eventPublisher;
        }

        public async Task Execute(string userId, int pokemonId)
        {
            User user = await _userFinder.Execute(new UserId(userId));
            await _pokemonFavoriteCreator.Execute(user, new PokemonFavorite(new PokemonId(pokemonId)));
            _publisher.Publish(new DomainEvent(new MessageEvent(pokemonId.ToString())));

        }
    }
}