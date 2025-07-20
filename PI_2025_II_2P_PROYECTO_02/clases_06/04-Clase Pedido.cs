using System;
using System.Linq;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    internal class Pedido
    {
       
        private int _idPedido;
        private DateTime _fechaPedido;
        private Cliente _cliente;
        private Videojuego _videojuego;
        private int _cantidad;
        private decimal _precioUnitario;
        private string _estado;
        private decimal _total;

        
        public int IDPedido
        {
            get => _idPedido;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID del pedido debe ser mayor que cero.");
                _idPedido = value;
            }
        }

        public DateTime FechaPedido
        {
            get => _fechaPedido;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("La fecha del pedido no puede estar en el futuro.");
                _fechaPedido = value;
            }
        }

        public Cliente Cliente
        {
            get => _cliente;
            set => _cliente = value ?? throw new ArgumentNullException(nameof(Cliente), "El cliente no puede ser nulo.");
        }

        public Videojuego Videojuego
        {
            get => _videojuego;
            set => _videojuego = value ?? throw new ArgumentNullException(nameof(Videojuego), "El videojuego no puede ser nulo.");
        }

        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cantidad debe ser mayor que cero.");
                _cantidad = value;
            }
        }

        public decimal PrecioUnitario
        {
            get => _precioUnitario;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio unitario debe ser mayor que cero.");
                _precioUnitario = value;
            }
        }

        public string Estado
        {
            get => _estado;
            set
            {
                string[] estadosValidos = { "Pendiente", "Procesado", "Cancelado" };
                if (!estadosValidos.Contains(value))
                    throw new ArgumentException("El estado no es válido.");
                _estado = value;
            }
        }

        public decimal Total => _total;

        public Pedido(int idPedido, DateTime fecha, Cliente cliente, Videojuego videojuego, int cantidad, decimal precioUnitario, string estado)
        {
            IDPedido = idPedido;
            FechaPedido = fecha;
            Cliente = cliente;
            Videojuego = videojuego;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Estado = estado;
            CalcularTotal(); 
        }

        public Pedido()
        {
        }

        public void CalcularTotal()
        {
            _total = Cantidad * PrecioUnitario;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine("⏤ PEDIDO ⏤");
            Console.WriteLine($"ID: #{IDPedido}");
            Console.WriteLine($"Fecha: {FechaPedido:dd/MM/yyyy}");
            Console.WriteLine(value: $"Cliente: {Cliente.NombreCompleto}");
            Console.WriteLine($"Videojuego: {Videojuego.Titulo}");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Precio Unitario: {PrecioUnitario:C}");
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }

    
   
    public class Clientes
    {
        internal object NombreCompleto => throw new NotImplementedException();
    }
}