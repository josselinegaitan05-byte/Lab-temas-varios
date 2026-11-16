using System;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cálculo del Factorial del 0 al 10
            for (long contador = 0; contador <= 10; contador++)
            {
                Console.WriteLine("{0} = {1}", contador, FactorialMetodo(contador));
            }
        }

        // Declaración recursiva del método Factorial
        public static long FactorialMetodo(long numero)
        {
            // Caso base
            if (numero <= 1)
            {
                return 1;
            }
            // Paso de recursividad
            else
            {
                return numero * FactorialMetodo(numero - 1);
            }
        }
    }
}