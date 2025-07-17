using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class _01_Clase_Videojuego
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public decimal Precio { get; set; }
        public string ClasificacionEdad { get; set; }
        public string Plataforma { get; set; }
        public int Stock { get; set; }
        public string CodigoJuego { get; set; }

        public void MostrarInfo()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Género: {Genero}");
            Console.WriteLine($"Precio: {Precio:C}");
            Console.WriteLine($"Clasificación: {ClasificacionEdad}");
            Console.WriteLine($"Plataforma: {Plataforma}");
            Console.WriteLine($"Stock: {Stock}");
            Console.WriteLine($"Código: {CodigoJuego}");
        }

        public void AplicarDescuento(double porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100) return;
            Precio -= Precio * (decimal)(porcentaje / 100);
        }

        public bool HayStock()
        {
            if (Stock < 0) throw new ArgumentOutOfRangeException("El stock no puede ser negativo.");
            return Stock > 0;
        }
    }
}
