using PI_2025_II_2P_PROYECTO_02.clases_06;
using System;
using System.Collections.Generic;
using System.Linq;

public class _03_Clase_Factura
{
    public class ItemFactura
    {
        public _01_Clase_Videojuego Videojuego { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    public int NumeroFactura { get; set; }
    public DateTime Fecha { get; set; }
    public _02_Clase_Cliente Cliente { get; set; }
    public List<ItemFactura> Items { get; set; } = new List<ItemFactura>();
    public string Estado { get; set; } 
    public decimal Subtotal { get; private set; }
    public decimal Impuestos { get; private set; }
    public decimal Total { get; private set; }

    public void CalcularTotales()
    {
        Subtotal = Items.Sum(i => i.Subtotal);
        Impuestos = Subtotal * 0.15m; // 15% de impuestos
        Total = Subtotal + Impuestos;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Factura #: {NumeroFactura}");
        Console.WriteLine($"Fecha: {Fecha:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"Cliente: {Cliente.Nombre} {Cliente.Apellido} (ID: {Cliente.CodigoCliente})");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine("\nItems:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Videojuego.Titulo} x{item.Cantidad} @ ${item.PrecioUnitario} = ${item.Subtotal}");
        }
        Console.WriteLine($"\nSubtotal: ${Subtotal}");
        Console.WriteLine($"Impuestos (15%): ${Impuestos}");
        Console.WriteLine($"TOTAL: ${Total}");
    }
}