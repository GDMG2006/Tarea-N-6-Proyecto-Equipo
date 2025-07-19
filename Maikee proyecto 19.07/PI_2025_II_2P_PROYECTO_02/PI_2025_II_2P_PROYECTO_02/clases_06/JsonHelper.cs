using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public static class JsonHelper
    {
        public static void GuardarEnJson<T>(List<T> datos, string archivo)
        {
            if (datos.Count > 100)
                datos = datos.Take(100).ToList(); // Máximo 100 registros

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(datos, opciones);
            File.WriteAllText(archivo, json);
        }

        public static List<T> CargarDesdeJson<T>(string archivo)
        {
            if (!File.Exists(archivo))
                return new List<T>();

            string json = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
