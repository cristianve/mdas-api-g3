## Hace todos los puntos pedidos (40%)

#### Permite obtener los detalles de un pokemon vía endpoint

Ok

#### Si no existe el pokemon, ¿se lanza una excepción de dominio?

Ok

#### Si la api da timeout, ¿se lanza una excepción de dominio?

Ok

#### Si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

Ok, pero en el caso de no tener conexión o que la API de timeout da un 500, debería devolver un código de error esperado
y que se traduzca en la capa de infraestructura desde una excepción de dominio. Ejemplo: 503 Service Unavailable

#### Tests de aceptación

- El test de aceptación hace peticiones directas a la poke-api en vez de mockear esta parte.

#### Tests de integración

- El test de integración hace peticiones directas a la poke-api en vez de mockear esta parte.

**Puntuación: 30/40**

## Se aplican conceptos explicados (40%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

Ok

#### Aggregates + VOs

Ok

#### No se trabajan con tipos primitivos en dominio

Ok

#### Hay servicios de dominio

Ok

#### Hay use cases en aplicación reutilizables

Ok

#### Se aplica el patrón repositorio

Ok

#### Se utilizan object mothers

Utilizáis los object mother en los tests de forma correcta, pero creo que os ha faltado un punto por entender aquí:
> PokemonId pokemonId = new PokemonId(PokemonIdMother.Id());

Los Mothers encapsulan la creación de los value objects, de tal forma que si estos cambian, solo deberemos cambiar el
mother y no todos los tests. En vuestro caso, el mother únicamente devuelve el dato primitivo, pero debería devolver el
VO directamente (ejemplo):

> PokemonId pokemonId = PokemonIdMother.random();

**Puntuación: 35/40**

## Facilidad setup + README (20%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo user la aplicación"

Ok

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

Ok

**Puntuación: 20/20**

## Extras

- El README está muy currado (y gracias por añadir el puerto)
- Habéis añadido tests para el resto de casos de uso, ¡bien hecho!

**Puntuación: +10**

## Observaciones

¡¡Muy buen trabajo!!
Y me alegro que hayáis encontrado la forma de mockear en los tests unitarios las interfaces :-)

**PUNTUACIÓN FINAL: 95/100**