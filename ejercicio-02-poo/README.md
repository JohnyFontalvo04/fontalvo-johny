# 📝 Ejercicio 2 - Sistema de Gestión de Tareas (POO)

## 📖 Descripción

Este proyecto corresponde al **Ejercicio 2** del módulo **Programación Orientada a Objetos (POO)**. Consiste en el desarrollo de una aplicación de consola para la gestión de tareas, aplicando los principales conceptos de la Programación Orientada a Objetos como clases, encapsulamiento, herencia, interfaces y polimorfismo. Además, incorpora persistencia de datos mediante archivos JSON para conservar la información entre ejecuciones.

---

## 🎯 Objetivos

- Aplicar los principios fundamentales de la Programación Orientada a Objetos.
- Implementar herencia y polimorfismo mediante una jerarquía de clases.
- Utilizar interfaces para definir comportamientos comunes.
- Gestionar colecciones de objetos utilizando `List<T>`.
- Implementar persistencia de datos utilizando archivos JSON.
- Desarrollar una aplicación modular con separación de responsabilidades.

---

## 🛠 Tecnologías utilizadas

- C#
- .NET
- Aplicación de consola
- Visual Studio Code
- System.Text.Json

---

## 📚 Temas aplicados

- Clases
- Objetos
- Encapsulamiento
- Propiedades
- Constructores
- Herencia
- Polimorfismo
- Interfaces
- Enumeraciones (`enum`)
- Colecciones (`List<T>`)
- DateTime
- Serialización y deserialización JSON
- Manejo de archivos
- Manejo de excepciones (`try-catch`)

---

# 🚀 Funcionalidades

La aplicación cuenta con un menú interactivo que permite acceder a las siguientes opciones:

```text
=== GESTOR DE TAREAS ===

1. Agregar tarea
2. Listar todas
3. Listar por categoría
4. Listar por prioridad
5. Marcar como completada
6. Mostrar tareas vencidas
7. Eliminar tarea
8. Exportar a JSON
9. Salir
```

---

## ✅ Agregar tarea

Permite registrar tareas simples o tareas con fecha de vencimiento.

Para cada tarea se solicita:

- Título
- Descripción
- Categoría
- Prioridad
- Fecha de vencimiento (opcional)

Ejemplo:

```text
Título: Proyecto Final
Descripción: Entregar ejercicio de POO
Categoría: Universidad
Prioridad: Crítica
Fecha de vencimiento: 15/08/2025
```

---

## 📋 Listar tareas

Permite visualizar todas las tareas registradas utilizando una lista polimórfica.

Para cada tarea se muestra:

- ID
- Título
- Descripción
- Categoría
- Prioridad
- Estado
- Fecha de creación

Las tareas con vencimiento muestran además:

- Fecha de vencimiento
- Días restantes

---

## 📂 Filtrar tareas

La aplicación permite consultar tareas específicas mediante filtros.

### Por categoría

Muestra únicamente las tareas pertenecientes a una categoría determinada.

### Por prioridad

Permite visualizar las tareas según su nivel de prioridad:

- Baja
- Media
- Alta
- Crítica

---

## ⏰ Mostrar tareas vencidas

Permite listar automáticamente todas las tareas cuya fecha de vencimiento ya ha expirado y que aún no han sido completadas.

---

## ✅ Marcar tarea como completada

Permite actualizar el estado de una tarea utilizando su identificador (ID).

---

## 🗑 Eliminar tarea

Permite eliminar una tarea registrada utilizando su ID.

---

## 💾 Persistencia de datos

La aplicación guarda automáticamente todas las tareas en un archivo **JSON** al finalizar la ejecución.

Al iniciar nuevamente el programa, la información es cargada automáticamente desde el archivo, conservando todas las tareas previamente registradas.

---

# 🏗 Modelo de clases

El sistema está compuesto por las siguientes clases principales:

| Clase | Descripción |
|--------|-------------|
| `Tarea` | Clase base del sistema. |
| `TareaConVencimiento` | Hereda de `Tarea` e incorpora fecha de vencimiento. |
| `Categoria` | Representa la información de una categoría. |
| `GestorTareas` | Administra todas las operaciones del sistema. |
| `TareaDTO` | Clase utilizada para la persistencia en JSON. |

Además, se implementa la interfaz:

- `IExportable`

Y la enumeración:

- `Prioridad`

---

# 🧬 Conceptos de POO implementados

Durante el desarrollo del proyecto se aplicaron los siguientes principios:

- Encapsulamiento mediante propiedades.
- Herencia entre `Tarea` y `TareaConVencimiento`.
- Polimorfismo utilizando una `List<Tarea>`.
- Interfaces mediante `IExportable`.
- Sobrescritura de métodos (`override`).
- Constructores con llamada a `base()`.

---

# 📁 Estructura del proyecto

```text
SistemaGestionTareas/
│
├── Enums/
│   └── Prioridad.cs
│
├── Interfaces/
│   └── IExportable.cs
│
├── Models/
│   ├── Categoria.cs
│   ├── Tarea.cs
│   └── TareaConVencimiento.cs
│
├── Persistence/
│   └── TareaDTO.cs
│
├── Services/
│   └── GestorTareas.cs
│
├── Program.cs
├── tareas.json
├── ejercicio-02-poo.csproj
└── README.md
```

---

# 📄 Formato del archivo JSON

Las tareas se almacenan automáticamente en un archivo denominado:

```text
tareas.json
```

Ejemplo:

```json
[
  {
    "Tipo": "Simple",
    "Id": 1,
    "Titulo": "Estudiar POO",
    "Descripcion": "Repasar herencia",
    "Prioridad": 2,
    "Categoria": "Universidad",
    "Completada": false,
    "FechaCreacion": "2025-08-10T10:00:00"
  }
]
```

---

# 📌 Métodos implementados

El proyecto fue desarrollado utilizando métodos independientes para facilitar la organización del código.

## Program.cs

- `Main()`
- `AgregarTarea()`
- `ListarTodas()`
- `ListarCategoria()`
- `ListarPrioridad()`
- `Completar()`
- `MostrarVencidas()`
- `Eliminar()`

## GestorTareas.cs

- `Agregar()`
- `Completar()`
- `Eliminar()`
- `ListarPorCategoria()`
- `ListarPorPrioridad()`
- `ObtenerVencidas()`
- `GuardarEnJSON()`
- `CargarDeJSON()`

## Tarea.cs

- `MostrarInfo()`
- `Exportar()`

## TareaConVencimiento.cs

- `MostrarInfo()`

---

# 📷 Evidencias

Para la entrega del ejercicio se incluyen capturas de pantalla donde se evidencia:

- Creación de una tarea simple.
- Creación de una tarea con fecha de vencimiento.
- Listado polimórfico de tareas.
- Persistencia de datos mediante JSON (cerrar y volver a abrir la aplicación conservando la información).

---

# 👨‍💻 Autor

**Johny Fontalvo**

Estudiante de Ingeniería de Sistemas

---

## 📄 Licencia

Este proyecto fue desarrollado con fines exclusivamente académicos como parte del módulo **Programación Orientada a Objetos (POO)**.
