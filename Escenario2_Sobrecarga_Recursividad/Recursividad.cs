namespace Escenario2;

public static class Recursividad
{
    /// <summary>Factorial recursivo. Usa long y valida el rango para evitar errores.</summary>
    public static long Factorial(long n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "El factorial no está definido para negativos.");
        if (n > 20)
            throw new ArgumentOutOfRangeException(nameof(n), "21! desborda un long; el máximo es 20.");

        // Caso base: detiene la recursión (evita StackOverflow)
        if (n <= 1)
            return 1;

        // Paso recursivo: el problema se acerca al caso base en cada llamada
        return n * Factorial(n - 1);
    }
}
