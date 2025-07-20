using System;
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
            if (datos == null)
                throw new ArgumentNullException(nameof(datos), "La lista de datos no puede ser nula.");

            if (string.IsNullOrWhiteSpace(archivo))
                throw new ArgumentException("La ruta del archivo no puede estar vacía.");

            if (!archivo.EndsWith(".json"))
                archivo += ".json";

            if (datos.Count > 100)
                datos = datos.Take(100).ToList(); // Limite máximo de registros

            var opciones = new JsonSerializerOptions { WriteIndented = true };

            try
            {
                string json = JsonSerializer.Serialize(datos, opciones);
                File.WriteAllText(archivo, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
                // Aquí podrías registrar el error o relanzar la excepción si lo deseas
            }
        }

        public static List<T> CargarDesdeJson<T>(string archivo)
        {
            if (string.IsNullOrWhiteSpace(archivo))
                throw new ArgumentException("La ruta del archivo no puede estar vacía.");

            if (!archivo.EndsWith(".json"))
                archivo += ".json";

            if (!File.Exists(archivo))
                return new List<T>();

            try
            {
                string json = File.ReadAllText(archivo);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<T>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
                return new List<T>();
            }
        }
    }
}