## Hace todos los puntos pedidos (40%)

#### Permite crear usuarios vía endpoint

OK

#### Permite añadir favoritos vía endpoint

Esta parte está hecha pero con NAME en vez de ID :-(

#### Si el pokemon ya está marcado como favorito, ¿se lanza una excepción de dominio?

OK

#### Si el usuario no existe, ¿se lanza una excepción de dominio?

OK

#### Si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

OK

#### Hay tests unitarios

OK, pero algunos comentarios:

- En los test unitarios, cuando una clase tiene varios colaboradores que se inyectan, sólamente se instancia la clase a
  testear, mientras que el resto se mockean. Por ejemplo, en el caso de `AddPokemonToUserFavorites` habéis mockeado el
  repositorio, mientras que lo que tendríais que haber mockeado son el
  `UserFinder` y el `PokemonFavoriteCreator`. En el hipotético caso de tener un
  `UserFinderTest` (que en vuestro caso falta), sí se mockearía el repo.

- Os faltan test de algunos servicios: `UserFinder` y `PokemonFavoriteSearcher`. Aunque no os voy a penalizar porque no
  lo he pedido explícitamente. Aun así, al añadir funcionalidades es mejor que tengan test :-)

**Puntuación: 35/40**

## Se aplican conceptos explicados (40%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

OK

#### Aggregates + VOs

- No hay un objeto `PokemonFavourites` el cual encapsularía la lógica del listado y tendría la responsabilidad de añadir
  el `PokemonFavourite`.
- Cuando se quiera añadir un pokemon favorito, deberíamos pasar la entidad PokemonFavourite desde el caso de uso en vez
  de crear el `PokemonFavourite` dentro del propio agregado.

#### No se trabajan con tipos primitivos en dominio

El agregado User recibe en el constructor un string `userId`, cuando debería recibir directamente el value
object `UserId`

#### Hay servicios de dominio

OK. Nota: El `UserRepository` no es un servicio de dominio. Podría/debería estar en la raíz con los agregados,
entidades, etc. No encaja realmente en ninguno de los paquetes que tenéis. Quizá uno que fuese `Repositories`
sería más acertado.

#### Hay use cases en aplicación reutilizables

OK

#### Se aplica el patrón repositorio

OK

#### Se utilizan object mothers

OK

**Puntuación: 33/40**

## Facilidad setup + README (20%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo user la aplicación"

OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

OK, aunque para el swagger os sigue faltando el puerto :-(

**Puntuación: 18/20**

## Extra

- ¡Añadido un endpoint donde poder ver los favoritos de un usuario!
- Hay tests del contexto pokemon-type 🥳

**Puntuación: +10**

## Observaciones

- El status code asociado a la creación es el 201 (CREATED), no el 202 (ACCEPTED)
- El status code a la hora de obtener un usuario cuando el user no existe es un 500 INTERNAL SERVER ERROR cuando debería
  ser un 404 NOT FOUND

**PUNTUACIÓN FINAL: 96/100**