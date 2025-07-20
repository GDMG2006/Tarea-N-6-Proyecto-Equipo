using System;
using System.Text.RegularExpressions;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public class Empleado : Persona
    {
        public int IDEmpleado { get; private set; }

        private string _puesto;
        public string Puesto
        {
            get => _puesto;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El puesto no puede estar vacío.");
                _puesto = value.Trim();
            }
        }

        private decimal _sueldoMensual;
        public decimal SueldoMensual
        {
            get => _sueldoMensual;
            set
            {
                if (value <= 0 || value > 1_000_000)
                    throw new ArgumentOutOfRangeException("El sueldo debe estar entre 1 y 1,000,000.");
                _sueldoMensual = value;
            }
        }

        private DateTime _fechaIngreso;
        public DateTime FechaIngreso
        {
            get => _fechaIngreso;
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentException("La fecha de ingreso no puede ser futura.");
                _fechaIngreso = value;
            }
        }

        private bool _activo;
        public bool Activo
        {
            get => _activo;
            set => _activo = value;
        }

        public Empleado(int id, string nombre, string apellido, string correo, string telefono,
                        string puesto, decimal sueldo, DateTime ingreso, bool activo)
            : base(nombre, apellido, correo, telefono)
        {
            IDEmpleado = id;
            Puesto = puesto;
            SueldoMensual = sueldo;
            FechaIngreso = ingreso;
            Activo = activo;
        }

        public Empleado()
        {
        }

        public override void MostrarInfo()
        {
            Console.WriteLine("⏤ EMPLEADO ⏤");
            Console.WriteLine($"Nombre: {Nombre} {Apellido}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"ID: {IDEmpleado} | Puesto: {Puesto}");
            Console.WriteLine($"Sueldo Mensual: {SueldoMensual:C}");
            Console.WriteLine($"Fecha de Ingreso: {FechaIngreso:dd/MM/yyyy}");
            Console.WriteLine($"Estado: {(Activo ? "Activo" : "Inactivo")}");
        }
    }
}