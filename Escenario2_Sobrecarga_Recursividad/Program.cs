using Escenario2;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var calc = new Calculadora();

Console.WriteLine("=== ESCENARIO 2: Métodos sobrecargados y recursividad ===\n");

Console.WriteLine("--- Sobrecarga de Cuadrado ---");
Console.WriteLine($"Cuadrado(7)    = {calc.Cuadrado(7)}");
Console.WriteLine($"Cuadrado(7.5)  = {calc.Cuadrado(7.5)}");
Console.WriteLine($"Cuadrado(2.5m) = {calc.Cuadrado(2.5m)}");

Console.WriteLine("\n--- Sobrecarga de Sumar ---");
Console.WriteLine($"Sumar(2, 3)         = {calc.Sumar(2, 3)}");
Console.WriteLine($"Sumar(2, 3, 4)      = {calc.Sumar(2, 3, 4)}");
Console.WriteLine($"Sumar(1.5, 2.25)    = {calc.Sumar(1.5, 2.25)}");
Console.WriteLine($"Sumar([1,2,3,4,5])  = {calc.Sumar(new[] { 1, 2, 3, 4, 5 })}");

Console.WriteLine("\n--- Sobrecarga de RegistrarProducto ---");
Console.WriteLine(calc.RegistrarProducto("Mouse"));
Console.WriteLine(calc.RegistrarProducto("Teclado", 25.5m));
Console.WriteLine(calc.RegistrarProducto("Laptop HP Envy", 850.99m, 15));

Console.WriteLine("\n--- Factorial recursivo (0! a 10!) ---");
for (long i = 0; i <= 10; i++)
    Console.WriteLine($"{i}! = {Recursividad.Factorial(i)}");
Console.WriteLine($"20! = {Recursividad.Factorial(20)}");

Console.WriteLine("\n--- Control de errores ---");
foreach (long invalido in new long[] { -3, 25 })
{
    try { Recursividad.Factorial(invalido); }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Factorial({invalido}) rechazado: {ex.Message.Split('\n')[0]}");
    }
}

Console.WriteLine("\nUniversidad Tecnológica de Panamá - Herramientas de la Programación Aplicada III (.Net)");

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();