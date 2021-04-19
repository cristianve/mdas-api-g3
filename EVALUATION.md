# Evaluación reto 1

## Hace todos los puntos pedidos (40%)
#### Dado un nombre vía argumento, devolver sus tipos
OK

#### Dado un nombre vía endpoint, devolver sus tipos
OK

#### Si no existe el pokemon, ¿se lanza una excepción de dominio?
OK

#### Si la api da timeout, ¿se lanza una excepción de dominio?
No. Se lanza la excepción que lance el cliente HTTP. Debería estar mapeada
igual que lo está la `PokemonNotFoundException` y mapearla en el controlador
a un error esperado (no un 500)

#### Si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP/un error legible en consola?
OK, se hace para `PokemonNotFoundException` aunque 
falta el otro caso mencionado en el apartado anterior

**Puntuación final: 37/40**

## Se aplican conceptos explicados (40%)
#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)
En general hay una buena separación de capas y responsabilidades. Sin embargo:

En la capa de dominio no debe haber conceptos técnicos, tales como
`StatusCode` en `DomainException`, ni `Serializable`, ni `System.Runtime.Serialization.*`

#### Aggregates + VOs
OK, a falta del Value Object `PokemonName` de entrada

#### No se trabajan con tipos primitivos en dominio
El `pokemonName` debería ser un Value Object

#### Hay servicios de dominio
Se llama directamente al repository en vez de usar un searcher (servicio de dominio)

#### Hay use cases en aplicación reutilizables
OK

#### Se aplica el patrón repositorio
OK

**Puntuación final: 32/40**

## Facilidad setup + README (20%)
#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo user la aplicación"
OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"
OK

**Puntuación final: 20/20**

## Extra
- ¡Swagger! (aunque os ha faltado especificar el puerto :( )
- ¡README muy currado!

**Puntuación: +8**

## Observaciones
- ¿Por qué hay un README por package? 🤔
- Como se compila y se ejecuta la app distinta en función de si es API o shell
un Makefile lo hubiese hecho más fácil :)
  
- No nombras las interfaces como `IBlabla`. 
  Es un estándar obsoleto hoy en día (salvo que sea algún tipo de convención del lenguaje)
  
- ¿Por qué getters y setters? Para evitar modelos anémicos, 
  lo mejor es no ponerlos. Recordad: tell don't ask
  
- Es preferible que las excepciones de dominio (o cualquiera) no hereden de una 
clase padre como `DomainException`. Herencia vs composición
  
**PUNTUACIÓN FINAL: 97/100**