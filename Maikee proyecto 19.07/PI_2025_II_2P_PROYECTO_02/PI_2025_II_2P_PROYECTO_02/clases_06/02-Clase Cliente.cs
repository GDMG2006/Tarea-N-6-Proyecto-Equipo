using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public class _02_Clase_Cliente : Persona
    {
        public string Direccion { get; set; }

        private int _edad;
        public int Edad
        {
            get => _edad;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentException("Edad inválida.");
                _edad = value;
            }
        }

        public int CodigoCliente { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Cliente: {Nombre} {Apellido}");
            Console.WriteLine($"Correo: {Correo}, Teléfono: {Telefono}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Edad: {Edad}, Código Cliente: {CodigoCliente}");
        }
    }
}


