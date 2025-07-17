using System;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class _04_Clase_Pedido
    {
        public int IDPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public _02_Clase_Cliente Cliente { get; set; }
        public _01_Clase_Videojuego Videojuego { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; private set; }

        public void CalcularTotal()
        {
            Total = Cantidad * PrecioUnitario;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Pedido #{IDPedido}");
            Console.WriteLine($"Fecha: {FechaPedido.ToShortDateString()}");
            Console.WriteLine($"Cliente: {Cliente.Nombre} {Cliente.Apellido}");
            Console.WriteLine($"Juego: {Videojuego.Titulo}");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Precio Unitario: {PrecioUnitario:C}");
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }
}

