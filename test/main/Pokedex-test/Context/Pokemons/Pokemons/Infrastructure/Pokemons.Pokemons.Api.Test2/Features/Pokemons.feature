Feature: Pokemons
    In order to find pokemons
    Using Pokemons.Pokemons.Api API
    I want to get a pokemon as response

Scenario: Find Pokemon
    Given I have '1' as argument
    When I send a request to Pokemons.Pokemons.Api
    Then I get 'bulbasaur' as pokemon