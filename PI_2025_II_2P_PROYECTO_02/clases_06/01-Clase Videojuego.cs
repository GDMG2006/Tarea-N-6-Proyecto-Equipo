using System;
using System.Text.RegularExpressions;

namespace PI_2025_II_2P_PROYECTO_02.clases_06
{
    public class Videojuego
    {
        private string _titulo;
        private string _genero;
        private decimal _precio;
        private string _clasificacionEdad;
        private string _plataforma;
        private int _stock;
        private string _codigoJuego;

        
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El título no puede estar vacío.");
                _titulo = value.Trim();
            }
        }

        public string Genero
        {
            get => _genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El género no puede estar vacío.");
                _genero = value.Trim();
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value <= 0 || value > 100000)
                    throw new ArgumentOutOfRangeException("El precio debe estar entre 0.01 y 100,000.");
                _precio = value;
            }
        }

        public string ClasificacionEdad
        {
            get => _clasificacionEdad;
            set
            {
                string[] permitidas = { "E", "E10+", "T", "M", "A" };
                if (!Array.Exists(permitidas, c => c.Equals(value, StringComparison.OrdinalIgnoreCase)))
                    throw new ArgumentException("Clasificación de edad no válida.");
                _clasificacionEdad = value.ToUpper();
            }
        }

        public string Plataforma
        {
            get => _plataforma;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La plataforma no puede estar vacía.");
                _plataforma = value.Trim();
            }
        }

        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El stock no puede ser negativo.");
                _stock = value;
            }
        }

        public string CodigoJuego
        {
            get => _codigoJuego;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 8)
                    throw new ArgumentException("El código de juego debe tener 8 caracteres.");
                _codigoJuego = value.ToUpper();
            }
        }

        public Videojuego(string titulo, string genero, decimal precio, string clasificacionEdad, string plataforma, int stock, string codigoJuego)
        {
            Titulo = titulo;
            Genero = genero;
            Precio = precio;
            ClasificacionEdad = clasificacionEdad;
            Plataforma = plataforma;
            Stock = stock;
            CodigoJuego = codigoJuego;
        }

        public Videojuego()
        {
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine("⏤ INFORMACIÓN DEL VIDEOJUEGO ⏤");
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
            if (porcentaje < 0 || porcentaje > 100)
                throw new ArgumentOutOfRangeException("Porcentaje inválido (0-100).");
            Precio -= Precio * (decimal)(porcentaje / 100);
        }

        public bool HayStock()
        {
            return Stock > 0;
        }
    }
}
