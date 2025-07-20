using System;
using System.Text.RegularExpressions;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class Tienda
    {
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private string _correo;
        private string _razonSocial;
        private string _rtn;
        private string _ciudad;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                _nombre = value.Trim();
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

        public string Telefono
        {
            get => _telefono;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{8}$"))
                    throw new ArgumentException("El teléfono debe tener 8 dígitos numéricos.");
                _telefono = value;
            }
        }

        public string Correo
        {
            get => _correo;
            set
            {
                if (!Regex.IsMatch(value, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
                    throw new ArgumentException("Correo electrónico inválido.");
                _correo = value.Trim();
            }
        }

        public string RazonSocial
        {
            get => _razonSocial;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La razón social no puede estar vacía.");
                _razonSocial = value.Trim();
            }
        }

        public string Rtn
        {
            get => _rtn;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{14}$"))
                    throw new ArgumentException("El RTN debe tener exactamente 14 dígitos.");
                _rtn = value;
            }
        }

        public string Ciudad
        {
            get => _ciudad;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La ciudad no puede estar vacía.");
                _ciudad = value.Trim();
            }
        }

      
        public Tienda(string nombre, string direccion, string telefono, string correo, string razonSocial, string rtn, string ciudad)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            RazonSocial = razonSocial;
            Rtn = rtn;
            Ciudad = ciudad;
        }

       
        public virtual void MostrarInfo()
        {
            Console.WriteLine("⏤ INFORMACIÓN DE LA TIENDA ⏤");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Razón Social: {RazonSocial}");
            Console.WriteLine($"RTN: {Rtn}");
            Console.WriteLine($"Ciudad: {Ciudad}");
        }
    }
}