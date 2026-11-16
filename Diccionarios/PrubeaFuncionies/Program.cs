using System;
using System.Collections.Generic;

namespace PruebaFunciones
{
    class Program
    {
        static void Main(string[] args)
        {
            // Diccionario con los datos del inventario
            Dictionary<string, object> datosInventario = new Dictionary<string, object>
            {
                { "Nombre", "Laptop HP Envy" },
                { "Precio", 850.99m },
                { "Cantidad", 15 }
            };

            // Mostramos el contenido completo del diccionario
            Console.WriteLine("\n--- Contenido del Diccionario ---");
            foreach (KeyValuePair<string, object> elemento in datosInventario)
            {
                Console.WriteLine($"Clave: {elemento.Key} | Valor: {elemento.Value}");
            }
            Console.WriteLine("---------------------------------\n");

            // Generando la cláusula SET[cite: 4]
            var setParts = new List<string>();
            foreach (var key in datosInventario.Keys)
            {
                setParts.Add($"{key} = @{key}");
            }
            string setClause = string.Join(", ", setParts);

            Console.WriteLine($"Cláusula SET generada: {setClause}");

            // Generando dinámicamente las columnas y placeholders para un INSERT
            var columns = string.Join(", ", datosInventario.Keys);
            var placeholders = "@" + string.Join(", @", datosInventario.Keys);

            string sql = $"INSERT INTO productos ({columns}) VALUES ({placeholders})";
            Console.WriteLine($"la cadena sql es: {sql}");
        }
    }
}