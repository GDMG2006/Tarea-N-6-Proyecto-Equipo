using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private string _correo;
        public string Correo
        {
            get => _correo;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Correo inválido.");
                _correo = value;
            }
        }

        private string _telefono;

        protected Persona(string nombre, string apellido, string correo, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
        }

        public string Telefono
        {
            get => _telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono no puede estar vacío.");
                _telefono = value;
            }
        }

        public abstract void MostrarInfo();
    }
}