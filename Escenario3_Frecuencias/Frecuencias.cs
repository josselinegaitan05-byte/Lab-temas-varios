namespace Escenario3;

public static class Frecuencias
{
    /// <summary>Cuenta cuántas veces aparece cada número, ordenado por valor.</summary>
    public static SortedDictionary<int, int> Contar(IEnumerable<int> datos)
    {
        var frecuencias = new SortedDictionary<int, int>();
        foreach (int n in datos)
        {
            frecuencias.TryGetValue(n, out int actual);
            frecuencias[n] = actual + 1;
        }
        return frecuencias;
    }
}
