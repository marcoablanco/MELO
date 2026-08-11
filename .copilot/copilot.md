## Git: la IA no toca el repositorio

El repositorio es la herramienta del usuario para **revisar** los cambios del agente.
Cualquier operación de git por parte de la IA ensucia esa revisión y está prohibida.

**Nunca ejecutes:**

- `git commit`, `git push`
- `git add` / staging de cualquier tipo
- `git reset`, `git revert`, `git checkout`, `git restore`, `git stash`
- `git merge`, `git rebase`, `git cherry-pick`
- `git branch`, `git switch`, `git tag`
- `git clean`, ni borrado masivo de archivos versionados

**Sí puedes usar** comandos de sólo lectura para orientarte: `git status`, `git diff`,
`git log`, `git show`.

Regla: los cambios se dejan **en el árbol de trabajo, sin indexar**. El usuario decide qué
se commitea y cuándo. Si crees que conviene un commit, propónlo; no lo hagas.

## Orden de miembros en C#

Cuando generes clases C#, sigue este orden:

1. Campos
    - public const
    - public static
    - public readonly

    - internal const
    - internal static
    - internal readonly

    - protected const
    - protected static
    - protected readonly

    - private const
    - private static
    - private readonly

2. Constructores
    - public
    - internal
    - protected
    - private

3. Propiedades
    - public
    - internal
    - protected
    - private

4. Métodos static
    - public
    - internal
    - protected
    - private

5. Métodos abstract

6. Métodos de instancia
    - public
    - internal
    - protected
    - private

7. Overrides
    - public override
    - internal override
    - protected override

## Nomenclatura de archivos y clases

Todos los archivos y sus clases deben terminar con un sufijo que indique **qué son**. El nombre del archivo debe
coincidir siempre con el nombre del tipo que contiene.

Sufijos a utilizar:

| Sufijo                 | Uso                                                        |
|------------------------|------------------------------------------------------------|
| `Model`                | Entidades y objetos de dominio o de estado                 |
| `Service`              | Lógica de aplicación, orquestación y almacenes             |
| `Repository`           | Acceso a datos persistidos                                 |
| `Db` / `DbContext`     | Contextos de base de datos                                 |
| `Enum`                 | Enumeraciones                                              |
| `Formatter`            | Conversores de formato de salida                           |
| `Parser`               | Conversores de formato de entrada                          |
| `Serializer`           | Conversión bidireccional                                   |
| `Generator`            | Generación de conjuntos derivados                          |
| `Validator`            | Reglas de validación                                       |
| `Factory`              | Creación de objetos                                        |
| `Extensions`           | Métodos de extensión                                       |
| `Options` / `Settings` | Configuración                                              |
| `ViewModel`            | Modelos de vista de MAUI                                   |
| `Tests`                | Clases de pruebas unitarias. `EloCalculatorServiceTests`   |
| `IntegrationTests`     | Clases de pruebas de integración                           |

Reglas adicionales:

- Las interfaces mantienen el prefijo `I` **y** el sufijo correspondiente: `IEloCalculatorService`.
- No se usan sufijos genéricos sin significado como `Helper`, `Manager`, `Util` o `Common`.
- Un archivo contiene un único tipo público.
- La carpeta debe concordar con el sufijo: los `*Model` viven en `Models/`, los `*Service` en `Services/`, etc.
- Única excepción: `Program.cs` y `MauiProgram.cs`, puntos de entrada de la aplicación.

## Arquitectura: dónde vive la lógica

`Melo.Logic` es el **único** proyecto que contiene lógica de negocio. Es reutilizable desde
cualquier salida futura: app MAUI, API web, CLI...

`Melo.App` es un **adaptador fino** (MAUI). Sólo puede contener:

- Registro de dependencias y arranque (`MauiProgram.cs`).
- Vistas y ViewModels (`*ViewModel`, `*ContentPage`).
- Traducción entre los tipos de Logic y el formato de entrada/salida de la UI.

Está **prohibido** en un proyecto de salida:

- Lógica de dominio, cálculos o transformaciones de datos.
- Cualquier `if` sobre lógica de dominio que pudiera necesitarse desde otra salida.

Regla práctica: si el código haría falta igualmente en otro front, va en `Melo.Logic`.

## ReactiveUI

- Se usa **ReactiveUI 24.x** con primitivas propias (no `System.Reactive`).
- `WhenActivated` recibe `MultipleDisposable`, **no** `CompositeDisposable`.
- **No añadir** el paquete `System.Reactive` a ningún proyecto.

## Tests

- Los tests viven en `Melo.Logic.Tests`.
- Se usa `NullLogger<>` para satisfacer `ILogger<T>` en DI. No se necesitan paquetes
  de logging reales (`Microsoft.Extensions.Logging.Debug`, etc.).
- Clase base: `BaseService` con `ServiceCollection` + `NullLogger<>` + método virtual
  `ConfigureServices` para que cada test registre lo suyo.

