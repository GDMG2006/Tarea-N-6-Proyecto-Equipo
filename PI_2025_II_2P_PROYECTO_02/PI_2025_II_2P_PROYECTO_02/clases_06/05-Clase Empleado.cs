using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class _05_Clase_Empleado
    {
        internal object Apellido;

        public int IDEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public decimal SueldoMensual { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; internal set; }

        public void MostrarInfo()
        {
           
            Console.WriteLine($"Empleado: {Nombre}");
            Console.WriteLine($"ID: {IDEmpleado}");
            Console.WriteLine($"Puesto: {Puesto}");
            Console.WriteLine($"Sueldo: {SueldoMensual:C}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Fecha Ingreso: {FechaIngreso.ToShortDateString()}");
        }

        public int ObtenerAntiguedad()
        {
            return DateTime.Now.Year - FechaIngreso.Year;
        }
    }
}

