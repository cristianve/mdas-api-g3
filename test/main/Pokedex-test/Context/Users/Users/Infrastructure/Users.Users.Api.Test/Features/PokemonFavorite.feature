Feature: Pokemon Favorites
    In order to create a pokemon as favorite
    Using Users.Users.Api API
    I want to get pokemon favorites as response

Scenario: Save Pokemon Favorites
    Given I have '123456' and '6' as argument
    When I send a request to Users.Users.Api
    Then I get '6' as favorite after request favorites