using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class _02_Clase_Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public int CodigoCliente { get; set; }

        public void MostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Codigo: {CodigoCliente}");
        }

        public bool ValidarCorreo()
        {
            return Correo.Contains("@") && Correo.Contains(".");
        }

        public bool ValidarTelefono()
        {
            return Telefono.Length >= 8;
        }

        public bool EsMayorDeEdad()
        {
            return Edad >= 18;
        }
    }
}

