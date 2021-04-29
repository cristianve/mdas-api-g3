Feature: Pokemons
    In order to find pokemons
    Using Pokemons.Pokemons.Api API
    I want to get a pokemon as response

Scenario: Find Pokemon
    Given I have '1' as argument
    When I send a request to Pokemons.Pokemons.Api
    Then I get a pokemon with id '1' and name 'bulbasaur' with types 'poison, grass'

Scenario: Find unknown Pokemon
    Given I have '0' as argument
    When I send a request to Pokemons.Pokemons.Api
    Then I get an error response