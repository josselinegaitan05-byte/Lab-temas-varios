using Escenario3;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== ESCENARIO 3: Análisis de frecuencias ===\n");

// Parte A: conjunto fijo de datos
int[] datos = { 4, 7, 2, 4, 9, 7, 4, 1, 2, 9, 9, 9, 3, 7 };
Console.WriteLine("Datos: " + string.Join(", ", datos));
Console.WriteLine();
Console.WriteLine("Número\tFrecuencia\tHistograma");
foreach (var (numero, frecuencia) in Frecuencias.Contar(datos))
    Console.WriteLine($"{numero}\t{frecuencia}\t\t{new string('*', frecuencia)}");

// Parte B: 6000 tiros de un dado (semilla fija para resultados repetibles)
Console.WriteLine("\n--- Simulación: 6000 tiros de un dado ---");
var azar = new Random(2026);
var tiros = Enumerable.Range(0, 6000).Select(_ => azar.Next(1, 7));
Console.WriteLine("Cara\tFrecuencia");
int total = 0;
foreach (var (cara, frecuencia) in Frecuencias.Contar(tiros))
{
    Console.WriteLine($"{cara}\t{frecuencia}");
    total += frecuencia;
}
Console.WriteLine($"Total\t{total}");

Console.WriteLine("\nUniversidad Tecnológica de Panamá - Herramientas de la Programación Aplicada III (.Net)");

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();