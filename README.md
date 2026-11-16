# Temas varios – Laboratorio de C# y SQL

Colección de ejercicios cortos en **C# (.NET 10)** y un script **SQL (MySQL)** que practican conceptos básicos de programación: recursividad, sobrecarga de métodos, diccionarios, generación de consultas SQL parametrizadas, simulación con números aleatorios y una demostración de inyección SQL.

## Contenido

| Carpeta | Tema | Qué demuestra |
|---|---|---|
| `Factorial/` | Recursividad | Calcula el factorial de 0 a 10 con un método recursivo (`FactorialMetodo`). |
| `Frecuencias/` | Números aleatorios y `switch` | Simula 6000 tiros de un dado y cuenta la frecuencia de cada cara. |
| `SobreCargados/` | Sobrecarga de métodos | Clase `Operaciones` con dos versiones de `Cuadrado` (`int` y `double`). |
| `Diccionarios/` | `Dictionary<string, object>` | Recorre un diccionario de inventario y genera dinámicamente la cláusula `SET` y un `INSERT` con parámetros. |
| `Consultas SQL/` | SQL | Crea la tabla `permisos`, inserta datos de prueba y ejecuta consultas de ejemplo de inyección SQL. |

## Requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download) (los proyectos apuntan a `net10.0`).
- Visual Studio 2022/2026 o la CLI de `dotnet`.
- MySQL / MariaDB con una base de datos llamada `productosdb` (solo para el script SQL).

## Cómo ejecutar los proyectos C#

Desde la carpeta de cada proyecto (la que contiene el `.csproj`):

```bash
dotnet run
```

Rutas de los proyectos:

```text
Factorial/Factorial/Factorial/
Frecuencias/Frecuencias/Frecuencias/
SobreCargados/SobreCargados/
Diccionarios/PrubeaFuncionies/
```

También puedes abrir el archivo `.slnx` de cada carpeta en Visual Studio y pulsar **F5**.

## Detalle de cada ejercicio

### 1. Factorial
Imprime `n = n!` para `n` de 0 a 10. El método usa un caso base (`numero <= 1` devuelve 1) y un paso recursivo (`numero * FactorialMetodo(numero - 1)`). Se usa `long` para evitar desbordamientos en este rango.

```text
0 = 1
1 = 1
2 = 2
...
10 = 3628800
```

### 2. Frecuencias
Lanza un dado 6000 veces con `Random.Next(1, 7)` y acumula cada resultado en seis contadores mediante `switch`. Al final imprime una tabla Cara / Frecuencia. Cada cara debería salir cerca de 1000 veces; los valores cambian en cada ejecución.

### 3. SobreCargados
La clase `Operaciones` define dos métodos con el mismo nombre y distinto tipo de parámetro:

- `int Cuadrado(int valorInt)`
- `double Cuadrado(double valorDouble)`

El compilador elige la versión según el argumento: `Cuadrado(5)` usa `int` y `Cuadrado(4.5)` usa `double`. El programa espera una tecla al final (`Console.ReadKey()`).

### 4. Diccionarios
Parte de un diccionario con los datos de un producto (`Nombre`, `Precio`, `Cantidad`) y:

1. Muestra cada par clave/valor.
2. Genera la cláusula `SET`: `Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad`.
3. Construye un `INSERT INTO productos (...) VALUES (@..., ...)` usando **parámetros** (`@campo`) en lugar de concatenar valores.

> Los nombres de las columnas salen de las claves del diccionario. Si esas claves pudieran venir del usuario, hay que validarlas contra una lista de columnas permitidas.

### 5. Consultas SQL
El script `Consultas SQL.sql`:

- Usa la base `productosdb`.
- Crea la tabla `permisos` (usuario, contraseña, correo, módulos, etc.) e inserta cuatro registros de ejemplo.
- Incluye consultas de prueba que ilustran inyección SQL:
  - Bypass de autenticación con `OR '1'='1'`.
  - Comentarios SQL para anular parte de la condición.
  - Inyección ciega basada en tiempo con `SLEEP(15)`.

Ejecución:

```bash
mysql -u <usuario> -p productosdb < "Consultas SQL/Consultas SQL.sql"
```

## Capturas de ejecución

Guarda las capturas en la carpeta `capturas/` con estos nombres (el README ya las enlaza).

### Factorial
<img width="1471" height="745" alt="image" src="https://github.com/user-attachments/assets/15a3be46-b8b1-4a62-b87e-f0f88cee8c89" />


### Frecuencias
<img width="1480" height="763" alt="image" src="https://github.com/user-attachments/assets/ef42ffb3-080b-48e4-8d1a-0a11d1970a4d" />


### SobreCargados
Salida esperada:

```text
Se llamó a Cuadrado con argumento int: 5
Resultado entero: 25

Se llamó a Cuadrado con argumento double: 4.5
Resultado double: 20.25
```

<img width="1473" height="747" alt="image" src="https://github.com/user-attachments/assets/d1cd7099-a56d-434f-93f3-87a41e66e3bd" />


### Diccionarios
Salida esperada:

```text
--- Contenido del Diccionario ---
Clave: Nombre | Valor: Laptop HP Envy
Clave: Precio | Valor: 850.99
Clave: Cantidad | Valor: 15
---------------------------------

Cláusula SET generada: Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad
la cadena sql es: INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@Nombre, @Precio, @Cantidad)
```

<img width="1472" height="756" alt="image" src="https://github.com/user-attachments/assets/6ee248ee-8865-4974-b73d-20b86b87a567" />


### Consultas SQL
<img width="1410" height="830" alt="Captura de pantalla 2026-11-16 103949" src="https://github.com/user-attachments/assets/5327fe7c-8fcd-4432-8e9a-050155aca2f6" />


## Notas de seguridad

- Las consultas de inyección SQL son **solo con fines educativos**; ejecútalas únicamente en una base de datos local de pruebas.
- La defensa correcta es usar **consultas parametrizadas** (como en el ejercicio de Diccionarios), no concatenar texto del usuario.
- El script SQL contiene contraseñas codificadas en Base64. Base64 **no es cifrado**: se decodifica de forma trivial. Si son datos reales, cámbialas y no las subas a un repositorio público; en una aplicación real se guardan con un hash con sal (bcrypt, Argon2).

## Estructura del repositorio

```text
Temas varios/
├── Consultas SQL/
│   └── Consultas SQL.sql
├── Diccionarios/
│   └── PrubeaFuncionies/        # Program.cs
├── Factorial/
│   └── Factorial/Factorial/     # Program.cs
├── Frecuencias/
│   └── Frecuencias/Frecuencias/ # Program.cs
└── SobreCargados/
    └── SobreCargados/           # Program.cs, sobreCargados.cs
```

## Recomendación para Git

Las carpetas `bin/`, `obj/` y `.vs/` son generadas por Visual Studio. Agrega un `.gitignore` para no versionarlas:

```gitignore
bin/
obj/
.vs/
```

## Bibliografía

**Libro**

- Deitel, P. & Deitel, H. *Visual C# How to Program*. Pearson. (Los ejercicios de recursividad, lanzamiento de dados y sobrecarga de métodos siguen el estilo de este texto; ajusta la edición y el año a la de tu curso.)

**Documentación oficial de C# / .NET**

- Microsoft. *Métodos (Guía de programación de C#)*. <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods>
- Microsoft. *Clase `Dictionary<TKey,TValue>`*. <https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2>
- Microsoft. *Clase `Random`*. <https://learn.microsoft.com/en-us/dotnet/api/system.random>
- Microsoft. *Instrucciones de selección (`if`, `switch`)*. <https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements>
- Microsoft. *Instrucciones de iteración (`for`, `foreach`)*. <https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements>

**SQL y seguridad**

- MySQL. *MySQL 8.0 Reference Manual – Miscellaneous Functions (`SLEEP()`)*. <https://dev.mysql.com/doc/refman/8.0/en/miscellaneous-functions.html>
- OWASP. *SQL Injection*. <https://owasp.org/www-community/attacks/SQL_Injection>
- OWASP. *Query Parameterization Cheat Sheet*. <https://cheatsheetseries.owasp.org/cheatsheets/Query_Parameterization_Cheat_Sheet.html>
- OWASP. *Password Storage Cheat Sheet*. <https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html>
