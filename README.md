<div align="center">

# Laboratorio de Temas Varios
### Repaso del CRUD, Inyección SQL, Consultas Parametrizadas, Métodos Sobrecargados, Recursividad y Frecuencias

**Universidad Tecnológica de Panamá**
Facultad de Ingeniería en Sistemas · Campus Víctor Levis Sasso
**Materia:** Herramientas de la Programación Aplicada III (.NET) · **Grupo:** 1IL133
**Módulo IV:** Acceso a base de datos – Aplicaciones en capas
**Instructora:** Ing. Irina Fong
**Estudiante:** NOMBRE APELLIDO · Cédula: X-XXX-XXXX
**Fecha de entrega:** XX de octubre de 2026 · II Semestre 2026

</div>

---

## Tabla de contenido
1. [Tecnologías y versiones](#tecnologías-y-versiones)
2. [Estructura del repositorio](#estructura-del-repositorio)
3. [Guía de instalación y uso](#guía-de-instalación-y-uso)
4. [Problema 1: CRUD y consultas SQL](#problema-1-crud-y-consultas-sql)
5. [Problema 2: Armado de INSERT/UPDATE e inyección SQL](#problema-2-armado-de-insertupdate-e-inyección-sql)
6. [Problema 3: Métodos sobrecargados](#problema-3-métodos-sobrecargados)
7. [Problema 4: Recursividad (factorial)](#problema-4-recursividad-factorial)
8. [Problema 5: Frecuencias](#problema-5-frecuencias)
9. [Conclusiones](#conclusiones)

---

## Tecnologías y versiones

| Componente | Versión |
|---|---|
| SDK de .NET (escenarios de consola) | **.NET 10.0** (`net10.0`) |
| Lenguaje | **C# 14** |
| Proyecto CRUD | .NET Framework **4.7.2** (Windows Forms) |
| Base de datos | MySQL (`productosdb`) |
| Conector | MySql.Data 26.7.0 (NuGet) |
| IDE | Visual Studio 2026 |

Comprobar la versión instalada: `dotnet --version`

## Estructura del repositorio

```
Lab_Sobrecarga_CRUD/
├── Lab_Sobrecarga.slnx                       # Solución con los escenarios de consola
├── Escenario1_CRUD_SQL/                      # Problema 2: cadenas, inyección SQL, parámetros
├── Escenario2_Sobrecarga_Recursividad/       # Problemas 3 y 4: sobrecarga y factorial
├── Escenario3_Frecuencias/                   # Problema 5: frecuencias
├── ProyectoProductos_CRUD/                   # Problema 1: CRUD Windows Forms + MySQL
│   └── crear_base_datos.sql                  # Script de la base de datos
├── evidencias/                               # Capturas de pantalla
├── .gitignore
└── README.md
```

## Guía de instalación y uso

### Escenarios de consola (.NET 10)
```bash
git clone <URL-DEL-REPOSITORIO>
cd Lab_Sobrecarga_CRUD
dotnet restore Lab_Sobrecarga.slnx
dotnet build Lab_Sobrecarga.slnx

dotnet run --project Escenario1_CRUD_SQL
dotnet run --project Escenario2_Sobrecarga_Recursividad
dotnet run --project Escenario3_Frecuencias
```
En Visual Studio: abrir `Lab_Sobrecarga.slnx`, clic derecho sobre el proyecto → *Establecer como proyecto de inicio* → `Ctrl+F5`.

### Proyecto CRUD (requiere Windows y MySQL)
1. Ejecutar `ProyectoProductos_CRUD/crear_base_datos.sql` en MySQL para crear la base `productosdb` y la tabla `productos`.
2. En `ProyectoProductos_CRUD/ProyectoProductos/Conexion.cs`, ajustar `Uid` y `Pwd` con las credenciales propias de MySQL.
3. Abrir `ProyectoProductos_CRUD/ProyectoProductos.sln` en Visual Studio (restaura los paquetes NuGet automáticamente) y presionar `F5`.

---

## Problema 1: CRUD y consultas SQL

Aplicación Windows Forms que gestiona la tabla `productos` (`id`, `nombre`, `precio`, `cantidad`, `imagen`). Implementa las operaciones del CRUD, todas con consultas parametrizadas:

| Operación | Método (`Conexion.cs`) | Sentencia |
|---|---|---|
| Consultar / buscar | `GetProductos(filtro)` | `SELECT ... WHERE ... LIKE @filtro` |
| Insertar | `InsertSeguro(tabla, datos)` | `INSERT INTO ... VALUES (@...)` |
| Modificar | `UpdateSeguro(tabla, datos, id)` | `UPDATE ... SET col = @col WHERE id = @idWhere` |
| Eliminar | `DeleteSeguro(tabla, id)` | `DELETE FROM ... WHERE id = @id` |



---

## Problema 2: Armado de INSERT/UPDATE e inyección SQL

Se construyen las sentencias `INSERT` y `UPDATE` manipulando cadenas, en dos versiones:

- **Insegura:** concatena los valores dentro del SQL.
- **Segura:** usa parámetros (`@campo`), que viajan separados de la sentencia.

```csharp
// INSEGURA: el texto del usuario pasa a formar parte del SQL
$"UPDATE {tabla} SET {set} WHERE {columnaId} = '{valorId}'"

// SEGURA: el valor es un parámetro, nunca código
$"UPDATE {tabla} SET {set} WHERE {columnaId} = @{columnaId}"
```

Con el id `7' OR '1'='1`, la versión insegura produce `... WHERE Id = '7' OR '1'='1'`, condición siempre verdadera que modificaría **todas** las filas. Con el nombre `x'); DROP TABLE productos; --` el `INSERT` se rompe y agrega un `DROP TABLE`. La versión parametrizada trata ambos textos como simples datos.

**Evidencia:**

<img width="1917" height="851" alt="image" src="https://github.com/user-attachments/assets/cd045a98-335b-4e5f-bf23-c7db6f02ff8a" />


---

## Problema 3: Métodos sobrecargados

La clase `Calculadora` define varios métodos con el mismo nombre y distinta firma:

| Método | Firmas |
|---|---|
| `Cuadrado` | `(int)`, `(double)`, `(decimal)` |
| `Sumar` | `(int, int)`, `(int, int, int)`, `(double, double)`, `(int[])` |
| `RegistrarProducto` | `(string)`, `(string, decimal)`, `(string, decimal, int)` |

El compilador elige la versión según el número y tipo de argumentos.

**Evidencia:**

<img width="1917" height="967" alt="image" src="https://github.com/user-attachments/assets/d204a9cb-eb6f-4e7b-8a19-e5032eb70b81" />


---

## Problema 4: Recursividad (factorial)

```csharp
public static long Factorial(long n)
{
    if (n < 0)  throw new ArgumentOutOfRangeException(nameof(n), "No definido para negativos.");
    if (n > 20) throw new ArgumentOutOfRangeException(nameof(n), "21! desborda un long.");

    if (n <= 1) return 1;          // caso base: detiene la recursión
    return n * Factorial(n - 1);   // paso recursivo: se acerca al caso base
}
```

El caso base `n <= 1` evita el `StackOverflow`; la validación del rango (0 a 20) evita el desbordamiento del tipo `long`. Resultado: `10! = 3 628 800` y `20! = 2 432 902 008 176 640 000`.

**Evidencia:**

<img width="1917" height="967" alt="image" src="https://github.com/user-attachments/assets/65b267fc-4b99-4796-98d0-2fe4e7647b5b" />


---

## Problema 5: Frecuencias

`Frecuencias.Contar` recorre los datos una sola vez y usa un diccionario ordenado (`SortedDictionary<int,int>`) para acumular cuántas veces aparece cada número. Se probó con un arreglo fijo y con una simulación de 6000 tiros de dado (la suma de las frecuencias da 6000).

```csharp
foreach (int n in datos)
{
    frecuencias.TryGetValue(n, out int actual);
    frecuencias[n] = actual + 1;
}
```

**Evidencia:**

<img width="1467" height="690" alt="image" src="https://github.com/user-attachments/assets/495e514b-55f8-4d0b-828e-bfc2747f0493" />


---

## Conclusiones

- Concatenar texto del usuario dentro de una sentencia SQL permite que este altere su significado; los parámetros (`@campo`) separan el código de los datos y son obligatorios.
- La sobrecarga de métodos permite reutilizar un nombre con distintas firmas, lo que hace el código más legible y modular.
- Toda función recursiva necesita un caso base y avanzar hacia él; además hay que vigilar el límite del tipo de dato.
- Un diccionario permite contar frecuencias con una sola pasada sobre los datos.

---

<div align="center">

*Universidad Tecnológica de Panamá · Herramientas de la Programación Aplicada III (.NET) · Grupo 1IL133 · Entrega: XX de octubre de 2026*

</div>
