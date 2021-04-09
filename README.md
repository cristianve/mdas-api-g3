# LaSalle - Diseño del software II 🎓🏭

# PokeApi 🎮 


# Contenido 📇

* 1. Idea principal
* 2. Estructuración de carpetas
* 2. Instalación 
* 3. Resultados


# 1. Challenge 🤔💭

### Requirements:

* API: https://pokeapi.co
* Given the name of the pokemon return the type by:
  * Console - Terminal
  * Via Endpoint Http Body Json
* Control exceptions (Pokemon not found, PokeApi is down).
* The input via argument has to continue to work even if the api is down.

### Design:

* Commits bounded
* One class per file
* Create the classes strictly necessary to avoid duplicating the logic of the use case.


# 2. Install 🔧 

## Console 🖥️
```git clone https://github.com/CarLoOSX/mdas-api-g3```
### Execute the following commands
```
cd mdas-api-g3
cd src\main\Pokedex\Context\Pokemons\Types\Infrastructure\Pokemons.Types.CliConsole
```
### Compile the app
```dotnet build Pokemons.Types.CliConsole.csproj```
### Run the app and pass the pokemon as argument
```dotnet run charizard```

## Api Rest 🌐

### Execute the following commands
```
cd mdas-api-g3
cd src\main\Pokedex\Context\Pokemons\Types\Infrastructure\Pokemons.Types.Api
```
### Compile the app
```dotnet build Pokemons.Types.Api.csproj```
### Run the app
```dotnet run Pokemons.Types.Api.csproj```
### Go to
```https://localhost:{PORT}/swagger/index.html```

# 3. Results 📷

