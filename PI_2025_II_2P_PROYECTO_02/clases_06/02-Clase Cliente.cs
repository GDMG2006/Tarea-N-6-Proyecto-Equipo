using System;
using System.Text.RegularExpressions;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public class Cliente : Persona
    {
        private int _codigoCliente;
        private int _edad;
        private string _direccion;

      
        public int CodigoCliente
        {
            get => _codigoCliente;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El código del cliente debe ser positivo.");
                _codigoCliente = value;
            }
        }

        public int Edad
        {
            get => _edad;
            set
            {
                if (value < 0 || value > 120)
                    throw new ArgumentOutOfRangeException("Edad fuera de rango válido (0-120).");
                _edad = value;
            }
        }

        public string Direccion
        {
            get => _direccion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La dirección no puede estar vacía.");
                _direccion = value.Trim();
            }
        }

       
        public Cliente(int codigoCliente, string nombre, string apellido, string correo, string telefono, string direccion, int edad)
            : base(nombre, apellido, correo, telefono)
        {
            CodigoCliente = codigoCliente;
            Direccion = direccion;
            Edad = edad;
        }

        public Cliente()
        {
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("⏤ INFORMACIÓN DEL CLIENTE ⏤");
            Console.WriteLine($"Código: {CodigoCliente}");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Edad: {Edad}");
        }

       
        public string NombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}


