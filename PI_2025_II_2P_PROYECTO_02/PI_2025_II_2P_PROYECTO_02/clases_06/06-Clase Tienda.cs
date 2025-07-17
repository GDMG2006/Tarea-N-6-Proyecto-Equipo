using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class _06_Clase_Tienda
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string RazonSocial { get; set; }
        public string Rtn { get; set; }
        public string Ciudad { get; set; }

        public void MostrarInfo()
        {
            Console.WriteLine($"Tienda: {Nombre}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Ciudad: {Ciudad}");
            Console.WriteLine($"RTN: {Rtn}");
            Console.WriteLine($"Razón Social: {RazonSocial}");
        }

        public bool ValidarTelefono()
        {
            return Telefono.Length >= 8;
        }

        public bool ValidarRTN()
        {
            return Rtn.Length == 14;
        }
    }
}
