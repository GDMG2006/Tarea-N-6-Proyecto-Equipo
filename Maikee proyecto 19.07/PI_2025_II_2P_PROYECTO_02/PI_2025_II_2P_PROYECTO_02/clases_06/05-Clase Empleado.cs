uusing System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public class _05_Clase_Empleado : Persona
    {
        public int IDEmpleado { get; set; }

        private string _puesto;
        public string Puesto
        {
            get => _puesto;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El puesto no puede estar vacío.");
                _puesto = value;
            }
        }

        private decimal _sueldo;
        public decimal SueldoMensual
        {
            get => _sueldo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El sueldo debe ser mayor que cero.");
                _sueldo = value;
            }
        }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        public override void MostrarInfo()
        {
            Console.WriteLine($"Empleado: {Nombre} {Apellido}");
            Console.WriteLine($"Correo: {Correo}, Teléfono: {Telefono}");
            Console.WriteLine($"Puesto: {Puesto}, Sueldo: {SueldoMensual:C}");
            Console.WriteLine($"Fecha de Ingreso: {FechaIngreso.ToShortDateString()}");
            Console.WriteLine($"Estado: {(Activo ? "Activo" : "Inactivo")}");
        }
    }
}
