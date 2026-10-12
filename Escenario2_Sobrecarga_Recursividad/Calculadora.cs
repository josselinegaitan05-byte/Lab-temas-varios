namespace Escenario2;

/// <summary>Métodos sobrecargados: mismo nombre, distinta firma.</summary>
public class Calculadora
{
    // Cuadrado: int, double, decimal
    public int Cuadrado(int valor)
    {
        Console.WriteLine($"  [Cuadrado(int)] argumento: {valor}");
        return valor * valor;
    }

    public double Cuadrado(double valor)
    {
        Console.WriteLine($"  [Cuadrado(double)] argumento: {valor}");
        return valor * valor;
    }

    public decimal Cuadrado(decimal valor)
    {
        Console.WriteLine($"  [Cuadrado(decimal)] argumento: {valor}");
        return valor * valor;
    }

    // Sumar: distinta cantidad y tipo de parámetros
    public int Sumar(int a, int b)
    {
        Console.WriteLine("  [Sumar(int, int)]");
        return a + b;
    }

    public int Sumar(int a, int b, int c)
    {
        Console.WriteLine("  [Sumar(int, int, int)]");
        return a + b + c;
    }

    public double Sumar(double a, double b)
    {
        Console.WriteLine("  [Sumar(double, double)]");
        return a + b;
    }

    public int Sumar(int[] valores)
    {
        Console.WriteLine($"  [Sumar(int[])] {valores.Length} elementos");
        return valores.Sum();
    }

    // Registro de un producto con sobrecarga de parámetros
    public string RegistrarProducto(string nombre)
        => $"Producto '{nombre}' (sin precio ni cantidad)";

    public string RegistrarProducto(string nombre, decimal precio)
        => $"Producto '{nombre}' con precio {precio:C}";

    public string RegistrarProducto(string nombre, decimal precio, int cantidad)
        => $"Producto '{nombre}' con precio {precio:C} y cantidad {cantidad}";
}
