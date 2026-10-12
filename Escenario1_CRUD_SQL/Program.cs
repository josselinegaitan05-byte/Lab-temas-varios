using Escenario1;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var datos = new Dictionary<string, object>
{
    { "nombre", "Laptop HP Envy" },
    { "precio", 850.99m },
    { "cantidad", 15 }
};

Console.WriteLine("=== ESCENARIO 1: Seguridad en el CRUD y consultas parametrizadas ===\n");

Console.WriteLine("--- 1. Uso normal (entrada legítima) ---");
Console.WriteLine("INSERT inseguro : " + ConstructorSql.InsertInseguro("productos", datos));
Console.WriteLine("UPDATE inseguro : " + ConstructorSql.UpdateInseguro("productos", datos, "id", "7"));
Console.WriteLine("INSERT seguro   : " + ConstructorSql.InsertParametrizado("productos", datos));
Console.WriteLine("UPDATE seguro   : " + ConstructorSql.UpdateParametrizado("productos", datos, "Id"));

Console.WriteLine("\n--- 2. Ataque de inyección SQL en el UPDATE ---");
string idMalicioso = "7' OR '1'='1";
Console.WriteLine($"Id recibido del usuario: {idMalicioso}");
Console.WriteLine("UPDATE inseguro : " + ConstructorSql.UpdateInseguro("productos", datos, "id", idMalicioso));
Console.WriteLine("  -> La condición '1'='1' siempre es verdadera: se modificarían TODAS las filas.");

Console.WriteLine("\n--- 3. Ataque de inyección SQL en el INSERT ---");
var datosMaliciosos = new Dictionary<string, object>
{
    { "nombre", "x'); DROP TABLE productos; --" },
    { "precio", 1m },
    { "cantidad", 1 }
};
Console.WriteLine("INSERT inseguro : " + ConstructorSql.InsertInseguro("productos", datosMaliciosos));
Console.WriteLine("  -> El texto del usuario cierra el INSERT y agrega un DROP TABLE.");

Console.WriteLine("\n--- 4. La misma entrada con consulta parametrizada ---");
Console.WriteLine("UPDATE seguro   : " + ConstructorSql.UpdateParametrizado("productos", datos, "Id"));
Console.WriteLine("INSERT seguro   : " + ConstructorSql.InsertParametrizado("productos", datosMaliciosos));
Console.WriteLine("Valores enviados aparte como parámetros (nunca se mezclan con el SQL):");
foreach (var d in datosMaliciosos)
    Console.WriteLine($"  @{d.Key} = {d.Value}");
Console.WriteLine($"  @id = {idMalicioso}");
Console.WriteLine("  -> El motor trata el texto malicioso como un simple dato, no como código.");

Console.WriteLine("\nUniversidad Tecnológica de Panamá - Herramientas de la Programación Aplicada III (.Net)");
