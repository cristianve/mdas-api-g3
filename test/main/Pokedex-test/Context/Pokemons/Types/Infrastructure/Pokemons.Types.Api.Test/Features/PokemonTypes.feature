Feature: Pokemon Types
    In order to find pokemon types
    Using Pokemons.Types.Api API
    I want to get pokemon types as response

Scenario: Find Pokemon Types
    Given I have 'charizard' as argument
    When I send a request to Pokemons.Types.Api
    Then I get types 'fire, flying'

Scenario: Find unknown Pokemon
    Given I have '12345' as argument
    When I send a request to Pokemons.Types.Api
    Then I get an error response