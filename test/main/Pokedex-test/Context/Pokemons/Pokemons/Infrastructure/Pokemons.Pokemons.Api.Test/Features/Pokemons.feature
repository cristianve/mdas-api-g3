Feature: Pokemons
    In order to find pokemons
    Using Pokemons.Pokemons.Api API
    I want to get a pokemon as response

Scenario: Find Pokemon
    Given I have '6' as argument
    When I send a request to Pokemons.Pokemons.Api
    Then I get a pokemon with id '6' and name 'charizard' with types 'fire, flying'

Scenario: Find unknown Pokemon
    Given I have '0' as argument
    When I send a request to Pokemons.Pokemons.Api
    Then I get an error response