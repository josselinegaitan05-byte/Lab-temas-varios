namespace Escenario1;

/// <summary>
/// Arma sentencias INSERT y UPDATE manipulando cadenas.
/// Cada operación existe en dos versiones: INSEGURA (concatena valores)
/// y SEGURA (usa parámetros @nombre).
/// </summary>
public static class ConstructorSql
{
    // ---------- VERSIÓN INSEGURA (vulnerable a inyección SQL) ----------

    public static string InsertInseguro(string tabla, Dictionary<string, object> datos)
    {
        string columnas = string.Join(", ", datos.Keys);
        string valores = string.Join(", ", datos.Values.Select(Literal));
        return $"INSERT INTO {tabla} ({columnas}) VALUES ({valores})";
    }

    public static string UpdateInseguro(string tabla, Dictionary<string, object> datos, string columnaId, string valorId)
    {
        string set = string.Join(", ", datos.Select(d => $"{d.Key} = {Literal(d.Value)}"));
        // El id llega como texto y se concatena tal cual: aquí entra el ataque.
        return $"UPDATE {tabla} SET {set} WHERE {columnaId} = '{valorId}'";
    }

    // ---------- VERSIÓN SEGURA (consulta parametrizada) ----------

    public static string InsertParametrizado(string tabla, Dictionary<string, object> datos)
    {
        string columnas = string.Join(", ", datos.Keys);
        string parametros = string.Join(", ", datos.Keys.Select(k => "@" + k));
        return $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})";
    }

    public static string UpdateParametrizado(string tabla, Dictionary<string, object> datos, string columnaId)
    {
        string set = string.Join(", ", datos.Keys.Select(k => $"{k} = @{k}"));
        return $"UPDATE {tabla} SET {set} WHERE {columnaId} = @{columnaId}";
    }

    // Convierte un valor a literal SQL por concatenación (a propósito, sin escapar).
    private static string Literal(object valor) => valor switch
    {
        string s => $"'{s}'",
        decimal d => d.ToString(System.Globalization.CultureInfo.InvariantCulture),
        double d => d.ToString(System.Globalization.CultureInfo.InvariantCulture),
        _ => Convert.ToString(valor, System.Globalization.CultureInfo.InvariantCulture) ?? "NULL"
    };
}
