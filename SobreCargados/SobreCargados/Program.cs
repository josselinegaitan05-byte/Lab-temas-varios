using System;

namespace sobreCargados
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos la clase Operaciones dentro del mismo namespace
            Operaciones calc = new Operaciones();

            // Llamamos al método con un entero (int)
            int resultadoInt = calc.Cuadrado(5);
            Console.WriteLine($"Resultado entero: {resultadoInt}\n");

            // Llamamos al método con un decimal (double)
            double resultadoDouble = calc.Cuadrado(4.5);
            Console.WriteLine($"Resultado double: {resultadoDouble}");

            Console.ReadKey();
        }
    }
}