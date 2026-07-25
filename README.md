# 💳 Ejercicio 1 - Validador de Tarjetas (Algoritmo de Luhn)

## 📖 Descripción

Este proyecto corresponde al **Ejercicio 1** del módulo **Fundamentos de C# y .NET**. Consiste en el desarrollo de una aplicación de consola capaz de validar números de tarjetas de crédito y débito mediante la implementación del **Algoritmo de Luhn**, además de identificar la marca de la tarjeta, procesar múltiples tarjetas desde un archivo, generar números válidos y presentar estadísticas de las validaciones realizadas.

---

## 🎯 Objetivos

- Implementar el algoritmo de Luhn en C#.
- Identificar la marca de una tarjeta según su prefijo y longitud.
- Aplicar conceptos fundamentales de programación en C#.
- Trabajar con archivos de texto para procesar múltiples registros.
- Desarrollar una aplicación modular utilizando métodos con responsabilidad única.

---

## 🛠 Tecnologías utilizadas

- C#
- .NET
- Aplicación de consola
- Visual Studio Code

---

## 📚 Temas aplicados

- Variables
- Tipos de datos
- Cadenas (`string`)
- Caracteres (`char`)
- Condicionales (`if`, `switch`)
- Ciclos (`for`, `do-while`)
- Métodos
- Operadores
- Arreglos
- Manejo de excepciones (`try-catch`)
- Lectura de archivos (`File.ReadAllLines()`)

---

# 🚀 Funcionalidades

La aplicación cuenta con un menú interactivo que permite acceder a las siguientes opciones:

```text
=== VALIDADOR DE TARJETAS ===

1. Validar una tarjeta
2. Validar desde archivo
3. Generar número válido
4. Estadísticas
5. Salir
```

---

## ✅ Validar una tarjeta

Permite ingresar manualmente un número de tarjeta para:

- Verificar si cumple el algoritmo de Luhn.
- Identificar la marca correspondiente.
- Mostrar si la tarjeta es válida o inválida.

Ejemplo:

```text
Número: 4532015112830366
Marca: Visa
Estado: VÁLIDA
```

---

## 📄 Validar desde archivo

Permite leer un archivo de texto (`.txt`) que contiene un número de tarjeta por línea.

El programa procesa cada tarjeta mostrando:

- Número de tarjeta
- Marca identificada
- Estado de validación

Al finalizar, presenta un resumen con las estadísticas obtenidas.

---

## 🎲 Generar número válido

Genera automáticamente un número de tarjeta que cumple el algoritmo de Luhn e indica la marca correspondiente.

Ejemplo:

```text
Número generado: 4123456789012345
Marca: Visa
```

---

## 📊 Estadísticas

El sistema mantiene un registro de las validaciones realizadas durante la ejecución del programa.

Se muestran:

- Total de tarjetas válidas.
- Total de tarjetas inválidas.
- Cantidad de tarjetas Visa.
- Cantidad de tarjetas Mastercard.
- Cantidad de tarjetas American Express.
- Cantidad de tarjetas Discover.
- Cantidad de tarjetas desconocidas.

---

# 🏦 Marcas soportadas

| Marca | Prefijo | Longitud |
|--------|----------|-----------|
| Visa | 4 | 13 o 16 dígitos |
| Mastercard | 51 - 55 | 16 dígitos |
| American Express | 34 o 37 | 15 dígitos |
| Discover | 6011 o 65 | 16 a 19 dígitos |
| Desconocida | Otros | Variable |

---

# 🧮 Algoritmo implementado

La validación de tarjetas se realiza mediante el **Algoritmo de Luhn**, siguiendo los siguientes pasos:

1. Recorrer el número de tarjeta desde el último dígito.
2. Duplicar uno de cada dos dígitos.
3. Si el resultado es mayor que 9, restar 9.
4. Sumar todos los dígitos.
5. Verificar que la suma total sea múltiplo de 10.

Si la condición anterior se cumple, la tarjeta se considera **válida**.

---

# 📁 Estructura del proyecto

```text
ValidadorTarjetas/
│
├── Program.cs
├── tarjetas.txt
├── johny-fontalvo.csproj
└── README.md
```


# 📄 Formato del archivo de entrada

El archivo de texto debe contener un número de tarjeta por cada línea.

Ejemplo:

```text
4111111111111111
5555555555554444
378282246310005
6011111111111117
1234567890123456
```

---

# 📌 Métodos implementados

El proyecto fue desarrollado utilizando métodos independientes para facilitar la organización del código.

- `Main()`
- `ValidarManual()`
- `ValidarTarjeta(string numeroTarjeta)`
- `IdentificarMarca(string numeroTarjeta)`
- `ValidarDesdeArchivo(string rutaArchivo)`
- `GenerarNumeroValido()`
- `CalcularDigitoLuhn(string numeroTarjeta)`
- `MostrarEstadisticas()`
- `ActualizarEstadisticas(bool esValida, string marcaTarjeta)`

---

# 📷 Evidencias

Para la entrega del ejercicio se incluyen capturas de pantalla donde se evidencia:

- Validación de una tarjeta válida.
- Validación de una tarjeta inválida.
- Menú principal de la aplicación.

---

# 👨‍💻 Autor

**Johny Fontalvo**

Estudiante de Ingeniería de Sistemas

---

## 📄 Licencia

Este proyecto fue desarrollado con fines exclusivamente académicos como parte del módulo **Fundamentos de C# y .NET**.
