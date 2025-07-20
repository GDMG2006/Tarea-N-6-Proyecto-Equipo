using PI_2025_II_2P_PROYECTO_02.clases_06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace PI_2025_II_2P_PROYECTO_02
{
    class Program
    {
        // Listas para almacenar los datos
        private static List<Videojuego> listaJuegos = new List<Videojuego>();
        private static List<Cliente> listaClientes = new List<Cliente>();
        private static List<Factura> listaFacturas = new List<Factura>();
        private static List<Pedido> listaPedidos = new List<Pedido>();
        private static List<Empleado> listaEmpleados = new List<Empleado>();
        private static List<Tienda> listaTiendas = new List<Tienda>();

        static void Main(string[] args)
        {
            CargarDatosIniciales();

            int opcionPrincipal;
            do
            {
                Console.Clear();
                MostrarMenuPrincipal();

                if (!int.TryParse(Console.ReadLine(), out opcionPrincipal)) continue;

                switch (opcionPrincipal)
                {
                    case 1: GestionarVideojuegos(); break;
                    case 2: GestionarClientes(); break;
                    case 3: GestionarFacturas(); break;
                    case 4: GestionarPedidos(); break;
                    case 5: GestionarEmpleados(); break;
                    case 6: GestionarTiendas(); break;
                    case 7: GuardarDatos(); break;
                    case 8: Console.WriteLine("Saliendo del sistema..."); break;
                    default: MostrarError("Opción inválida"); break;
                }

                if (opcionPrincipal != 8) Continuar();

            } while (opcionPrincipal != 8);
        }

        #region Métodos principales
        private static void CargarDatosIniciales()
        {
            try
            {
                // Aquí iría la carga desde archivos JSON
                Console.WriteLine("Cargando datos iniciales...");

                // Datos de ejemplo para pruebas
                listaTiendas.Add(new Tienda("GameCenter", "Calle Principal 123", "22334455", "info@gamecenter.com",
                                           "GameCenter S.A.", "08011990012345", "Tegucigalpa"));

                listaEmpleados.Add(new Empleado(1, "Juan", "Pérez", "juan@gamecenter.com", "98765432",
                                              "Gerente", 25000m, new DateTime(2020, 1, 15), true));

                listaClientes.Add(new Cliente(1, "Carlos", "López", "carlos@email.com", "87654321",
                                            "Colonia Palmira", 28));

                listaJuegos.Add(new Videojuego("FIFA 23", "Deportes", 1200m, "E", "PS5", 50, "FIFA2023"));
                listaJuegos.Add(new Videojuego("Call of Duty", "FPS", 1500m, "M", "XBOX", 30, "COD2023"));

                Console.WriteLine("Datos iniciales cargados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }
        }

        private static void GuardarDatos()
        {
            try
            {
                // Aquí iría el guardado a archivos JSON
                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos: {ex.Message}");
            }
        }
        #endregion

        #region Menús y helpers
        private static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE TIENDA DE VIDEOJUEGOS ===");
            Console.WriteLine("1. Gestión de Videojuegos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Facturas");
            Console.WriteLine("4. Gestión de Pedidos");
            Console.WriteLine("5. Gestión de Empleados");
            Console.WriteLine("6. Gestión de Tiendas");
            Console.WriteLine("7. Guardar datos");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private static void Continuar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarError(string mensaje)
        {
            Console.WriteLine($"❌ {mensaje}");
        }

        private static void MostrarExito(string mensaje)
        {
            Console.WriteLine($"✅ {mensaje}");
        }
        #endregion

        #region Gestión de Videojuegos
        static void GestionarVideojuegos()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE VIDEOJUEGOS ===");
                Console.WriteLine("1. Agregar Videojuego");
                Console.WriteLine("2. Buscar Videojuego");
                Console.WriteLine("3. Actualizar Videojuego");
                Console.WriteLine("4. Eliminar Videojuego");
                Console.WriteLine("5. Listar Videojuegos");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: AgregarVideojuego(); break;
                    case 2: BuscarVideojuego(); break;
                    case 3: ActualizarVideojuego(); break;
                    case 4: EliminarVideojuego(); break;
                    case 5: ListarVideojuegos(); break;
                }

            } while (opcion != 6);
        }

        static void AgregarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR VIDEOJUEGO ===");

            try
            {
                var juego = new Videojuego();

                Console.Write("Título: "); juego.Titulo = Console.ReadLine();
                Console.Write("Género: "); juego.Genero = Console.ReadLine();

                Console.Write("Precio: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal precio)) throw new ArgumentException("Precio inválido");
                juego.Precio = precio;

                Console.Write("Clasificación (E/E10+/T/M/A): "); juego.ClasificacionEdad = Console.ReadLine();
                Console.Write("Plataforma: "); juego.Plataforma = Console.ReadLine();

                Console.Write("Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int stock)) throw new ArgumentException("Stock inválido");
                juego.Stock = stock;

                Console.Write("Código (8 caracteres): "); juego.CodigoJuego = Console.ReadLine();

                listaJuegos.Add(juego);
                MostrarExito("Videojuego agregado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR VIDEOJUEGO ===");
            Console.Write("Ingrese código o título: ");
            string busqueda = Console.ReadLine();

            var resultados = listaJuegos.Where(j =>
                j.CodigoJuego.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                j.Titulo.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron videojuegos");
                return;
            }

            foreach (var j in resultados)
            {
                j.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void ActualizarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR VIDEOJUEGO ===");
            Console.Write("Ingrese código del juego: ");
            string codigo = Console.ReadLine();

            var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (juego == null)
            {
                MostrarError("Videojuego no encontrado");
                return;
            }

            try
            {
                Console.WriteLine("\nDatos actuales:");
                juego.MostrarInfo();

                Console.WriteLine("\nNuevos datos (deje vacío para mantener):");

                Console.Write($"Título ({juego.Titulo}): ");
                string titulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(titulo)) juego.Titulo = titulo;

                Console.Write($"Género ({juego.Genero}): ");
                string genero = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(genero)) juego.Genero = genero;

                Console.Write($"Precio ({juego.Precio}): ");
                string precioInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(precioInput) && decimal.TryParse(precioInput, out decimal precio))
                    juego.Precio = precio;

                Console.Write($"Clasificación ({juego.ClasificacionEdad}): ");
                string clasificacion = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(clasificacion)) juego.ClasificacionEdad = clasificacion;

                Console.Write($"Plataforma ({juego.Plataforma}): ");
                string plataforma = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(plataforma)) juego.Plataforma = plataforma;

                Console.Write($"Stock ({juego.Stock}): ");
                string stockInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int stock))
                    juego.Stock = stock;

                MostrarExito("Videojuego actualizado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void EliminarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR VIDEOJUEGO ===");
            Console.Write("Ingrese código del juego: ");
            string codigo = Console.ReadLine();

            var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (juego == null)
            {
                MostrarError("Videojuego no encontrado");
                return;
            }

            Console.WriteLine("\nDatos del videojuego:");
            juego.MostrarInfo();

            Console.Write("\n¿Confirmar eliminación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaJuegos.Remove(juego);
                MostrarExito("Videojuego eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarVideojuegos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE VIDEOJUEGOS ===");

            if (listaJuegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos registrados");
                return;
            }

            foreach (var j in listaJuegos)
            {
                j.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }
        #endregion

        #region Gestión de Clientes
        static void GestionarClientes()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
                Console.WriteLine("1. Agregar Cliente");
                Console.WriteLine("2. Buscar Cliente");
                Console.WriteLine("3. Actualizar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Listar Clientes");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: AgregarCliente(); break;
                    case 2: BuscarCliente(); break;
                    case 3: ActualizarCliente(); break;
                    case 4: EliminarCliente(); break;
                    case 5: ListarClientes(); break;
                }

            } while (opcion != 6);
        }

        static void AgregarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR CLIENTE ===");

            try
            {
                var cliente = new Cliente();

                Console.Write("ID Cliente: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || listaClientes.Any(c => c.CodigoCliente == id))
                    throw new ArgumentException("ID inválido o ya existe");
                cliente.CodigoCliente = id;

                Console.Write("Nombre: "); cliente.Nombre = Console.ReadLine();
                Console.Write("Apellido: "); cliente.Apellido = Console.ReadLine();

                Console.Write("Correo: ");
                string correo = Console.ReadLine();
                if (!correo.Contains("@")) throw new ArgumentException("Correo inválido");
                cliente.Correo = correo;

                Console.Write("Teléfono: "); cliente.Telefono = Console.ReadLine();
                Console.Write("Dirección: "); cliente.Direccion = Console.ReadLine();

                Console.Write("Edad: ");
                if (!int.TryParse(Console.ReadLine(), out int edad)) throw new ArgumentException("Edad inválida");
                cliente.Edad = edad;

                listaClientes.Add(cliente);
                MostrarExito("Cliente agregado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR CLIENTE ===");
            Console.Write("Ingrese ID, nombre o apellido: ");
            string busqueda = Console.ReadLine();

            var resultados = listaClientes.Where(c =>
                c.CodigoCliente.ToString().Contains(busqueda) ||
                c.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                c.Apellido.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron clientes");
                return;
            }

            foreach (var c in resultados)
            {
                c.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void ActualizarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR CLIENTE ===");
            Console.Write("Ingrese ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == id);
            if (cliente == null)
            {
                MostrarError("Cliente no encontrado");
                return;
            }

            try
            {
                Console.WriteLine("\nDatos actuales:");
                cliente.MostrarInfo();

                Console.WriteLine("\nNuevos datos (deje vacío para mantener):");

                Console.Write($"Nombre ({cliente.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre)) cliente.Nombre = nombre;

                Console.Write($"Apellido ({cliente.Apellido}): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(apellido)) cliente.Apellido = apellido;

                Console.Write($"Correo ({cliente.Correo}): ");
                string correo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@"))
                    cliente.Correo = correo;

                Console.Write($"Teléfono ({cliente.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono)) cliente.Telefono = telefono;

                Console.Write($"Dirección ({cliente.Direccion}): ");
                string direccion = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(direccion)) cliente.Direccion = direccion;

                Console.Write($"Edad ({cliente.Edad}): ");
                string edadInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(edadInput) && int.TryParse(edadInput, out int edad))
                    cliente.Edad = edad;

                MostrarExito("Cliente actualizado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR CLIENTE ===");
            Console.Write("Ingrese ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == id);
            if (cliente == null)
            {
                MostrarError("Cliente no encontrado");
                return;
            }

            Console.WriteLine("\nDatos del cliente:");
            cliente.MostrarInfo();

            Console.Write("\n¿Confirmar eliminación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaClientes.Remove(cliente);
                MostrarExito("Cliente eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE CLIENTES ===");

            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados");
                return;
            }

            foreach (var c in listaClientes)
            {
                c.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }
        #endregion

        #region Gestión de Facturas
        static void GestionarFacturas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE FACTURAS ===");
                Console.WriteLine("1. Crear Factura");
                Console.WriteLine("2. Buscar Factura");
                Console.WriteLine("3. Anular Factura");
                Console.WriteLine("4. Listar Facturas");
                Console.WriteLine("5. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: CrearFactura(listaFacturas); break;
                    case 2: BuscarFactura(); break;
                    case 3: AnularFactura(); break;
                    case 4: ListarFacturas(); break;
                }

            } while (opcion != 5);
        }

        static void CrearFactura(IEnumerable<Factura> listaFacturas)
        {
            Console.Clear();
            Console.WriteLine("=== CREAR FACTURA ===");

            if (listaClientes.Count == 0)
            {
                MostrarError("No hay clientes registrados");
                return;
            }

            if (listaJuegos.Count == 0)
            {
                MostrarError("No hay videojuegos registrados");
                return;
            }

            try
            {
                var factura = new Factura();

                // Número de factura
                factura.NumeroFactura = listaFacturas.Count > 0 ? listaFacturas.Max(f => f.NumeroFactura) + 1 : 1;
                factura.Fecha = DateTime.Now;

                // Seleccionar cliente
                Console.WriteLine("\nClientes disponibles:");
                foreach (var c in listaClientes)
                {
                    Console.WriteLine($"{c.CodigoCliente} - {c.NombreCompleto()}");
                }

                Console.Write("\nID del Cliente: ");
                if (!int.TryParse(Console.ReadLine(), out int idCliente))
                    throw new ArgumentException("ID inválido");

                var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == idCliente);
                if (cliente == null) throw new ArgumentException("Cliente no encontrado");
                factura.Cliente = cliente;

                // Agregar items
                factura.Items = new List<Factura.ItemFactura>();
                char continuar;

                do
                {
                    Console.WriteLine("\nVideojuegos disponibles:");
                    foreach (var j in listaJuegos.Where(j => j.Stock > 0))
                    {
                        Console.WriteLine($"{j.CodigoJuego} - {j.Titulo} (Stock: {j.Stock}) - {j.Precio:C}");
                    }

                    Console.Write("\nCódigo del Videojuego: ");
                    string codigo = Console.ReadLine();
                    var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego.Equals(codigo, StringComparison.OrdinalIgnoreCase));
                    if (juego == null) throw new ArgumentException("Videojuego no encontrado");

                    Console.Write("Cantidad: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0 || cantidad > juego.Stock)
                        throw new ArgumentException("Cantidad inválida");

                    factura.Items.Add(new Factura.ItemFactura
                    {
                        Videojuego = juego,
                        Cantidad = cantidad,
                        PrecioUnitario = juego.Precio
                    });

                    // Reducir stock
                    juego.Stock -= cantidad;

                    Console.Write("\n¿Agregar otro item? (S/N): ");
                    continuar = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                } while (continuar.ToString().ToUpper() == "S");

                factura.Estado = "ACTIVA";
                factura.CalcularTotales();
                object resultadoAgregarFactura = listaFacturas.Add(factura);

                Console.WriteLine("\nFactura creada:");
                factura.MostrarInfo();
                MostrarExito("Factura creada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarFactura()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR FACTURA ===");
            Console.Write("Ingrese número de factura o ID cliente: ");
            string busqueda = Console.ReadLine();

            var resultados = listaFacturas.Where(f =>
                f.NumeroFactura.ToString().Contains(busqueda) ||
                f.Cliente.CodigoCliente.ToString().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron facturas");
                return;
            }

            foreach (var f in resultados)
            {
                f.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void AnularFactura()
        {
            Console.Clear();
            Console.WriteLine("=== ANULAR FACTURA ===");
            Console.Write("Ingrese número de factura: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                MostrarError("Número inválido");
                return;
            }

            var factura = listaFacturas.FirstOrDefault(f => f.NumeroFactura == numero);
            if (factura == null)
            {
                MostrarError("Factura no encontrada");
                return;
            }

            if (factura.Estado == "ANULADA")
            {
                MostrarError("La factura ya está anulada");
                return;
            }

            Console.WriteLine("\nDatos de la factura:");
            factura.MostrarInfo();

            Console.Write("\n¿Confirmar anulación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                // Devolver stock
                foreach (var item in factura.Items)
                {
                    item.Videojuego.Stock += item.Cantidad;
                }

                factura.Estado = "ANULADA";
                MostrarExito("Factura anulada correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarFacturas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE FACTURAS ===");

            if (listaFacturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas");
                return;
            }

            foreach (var f in listaFacturas.OrderByDescending(f => f.Fecha))
            {
                f.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }
        #endregion

        #region Gestión de Pedidos
        static void GestionarPedidos()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE PEDIDOS ===");
                Console.WriteLine("1. Crear Pedido");
                Console.WriteLine("2. Buscar Pedido");
                Console.WriteLine("3. Actualizar Pedido");
                Console.WriteLine("4. Cancelar Pedido");
                Console.WriteLine("5. Listar Pedidos");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: CrearPedido(); break;
                    case 2: BuscarPedido(); break;
                    case 3: ActualizarPedido(); break;
                    case 4: CancelarPedido(); break;
                    case 5: ListarPedidos(); break;
                }

            } while (opcion != 6);
        }

        static void CrearPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR PEDIDO ===");

            if (listaClientes.Count == 0)
            {
                MostrarError("No hay clientes registrados");
                return;
            }

            if (listaJuegos.Count == 0)
            {
                MostrarError("No hay videojuegos registrados");
                return;
            }

            try
            {
                var pedido = new Pedido();

                // ID del pedido
                pedido.IDPedido = listaPedidos.Count > 0 ? listaPedidos.Max(p => p.IDPedido) + 1 : 1;
                pedido.FechaPedido = DateTime.Now;

                // Seleccionar cliente
                Console.WriteLine("\nClientes disponibles:");
                foreach (var c in listaClientes)
                {
                    Console.WriteLine($"{c.CodigoCliente} - {c.NombreCompleto()}");
                }

                Console.Write("\nID del Cliente: ");
                if (!int.TryParse(Console.ReadLine(), out int idCliente))
                    throw new ArgumentException("ID inválido");

                var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == idCliente);
                if (cliente == null) throw new ArgumentException("Cliente no encontrado");
                pedido.Cliente = cliente;

                // Seleccionar videojuego
                Console.WriteLine("\nVideojuegos disponibles:");
                foreach (var j in listaJuegos.Where(j => j.Stock > 0))
                {
                    Console.WriteLine($"{j.CodigoJuego} - {j.Titulo} (Stock: {j.Stock}) - {j.Precio:C}");
                }

                Console.Write("\nCódigo del Videojuego: ");
                string codigo = Console.ReadLine();
                var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego.Equals(codigo, StringComparison.OrdinalIgnoreCase));
                if (juego == null) throw new ArgumentException("Videojuego no encontrado");
                pedido.Videojuego = juego;

                Console.Write("Cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0 || cantidad > juego.Stock)
                    throw new ArgumentException("Cantidad inválida");
                pedido.Cantidad = cantidad;

                pedido.PrecioUnitario = juego.Precio;
                pedido.Estado = "PENDIENTE";
                pedido.CalcularTotal();

                // Reducir stock
                juego.Stock -= cantidad;

                listaPedidos.Add(pedido);

                Console.WriteLine("\nPedido creado:");
                pedido.MostrarInfo();
                MostrarExito("Pedido creado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR PEDIDO ===");
            Console.Write("Ingrese ID de pedido o ID cliente: ");
            string busqueda = Console.ReadLine();

            var resultados = listaPedidos.Where(p =>
                p.IDPedido.ToString().Contains(busqueda) ||
                p.Cliente.CodigoCliente.ToString().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron pedidos");
                return;
            }

            foreach (var p in resultados)
            {
                p.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void ActualizarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR PEDIDO ===");
            Console.Write("Ingrese ID del pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var pedido = listaPedidos.FirstOrDefault(p => p.IDPedido == id);
            if (pedido == null)
            {
                MostrarError("Pedido no encontrado");
                return;
            }

            if (pedido.Estado == "COMPLETADO" || pedido.Estado == "CANCELADO")
            {
                MostrarError($"No se puede actualizar un pedido en estado '{pedido.Estado}'");
                return;
            }

            try
            {
                Console.WriteLine("\nDatos actuales:");
                pedido.MostrarInfo();

                Console.WriteLine("\nOpciones de actualización:");
                Console.WriteLine("1. Cambiar cantidad");
                Console.WriteLine("2. Cambiar estado");
                Console.Write("Seleccione opción: ");

                if (!int.TryParse(Console.ReadLine(), out int opcion))
                    throw new ArgumentException("Opción inválida");

                switch (opcion)
                {
                    case 1:
                        // Cambiar cantidad
                        Console.Write($"\nNueva cantidad (actual: {pedido.Cantidad}, máx: {pedido.Videojuego.Stock + pedido.Cantidad}): ");
                        if (!int.TryParse(Console.ReadLine(), out int nuevaCantidad) || nuevaCantidad <= 0)
                            throw new ArgumentException("Cantidad inválida");

                        // Devolver stock actual
                        pedido.Videojuego.Stock += pedido.Cantidad;

                        if (nuevaCantidad <= pedido.Videojuego.Stock)
                        {
                            pedido.Cantidad = nuevaCantidad;
                            pedido.Videojuego.Stock -= nuevaCantidad;
                            pedido.CalcularTotal();
                            MostrarExito("Cantidad actualizada correctamente");
                        }
                        else
                        {
                            // Restaurar stock original
                            pedido.Videojuego.Stock -= pedido.Cantidad;
                            throw new ArgumentException("No hay suficiente stock");
                        }
                        break;

                    case 2:
                        // Cambiar estado
                        Console.Write("\nNuevo estado (PENDIENTE/EN PROCESO/COMPLETADO): ");
                        string nuevoEstado = Console.ReadLine().ToUpper();

                        if (nuevoEstado != "PENDIENTE" && nuevoEstado != "EN PROCESO" && nuevoEstado != "COMPLETADO")
                            throw new ArgumentException("Estado inválido");

                        pedido.Estado = nuevoEstado;

                        if (nuevoEstado == "COMPLETADO")
                        {
                            // Generar factura automáticamente
                            GenerarFacturaDesdePedido(pedido);
                        }

                        MostrarExito("Estado actualizado correctamente");
                        break;

                    default:
                        throw new ArgumentException("Opción inválida");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void CancelarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CANCELAR PEDIDO ===");
            Console.Write("Ingrese ID del pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var pedido = listaPedidos.FirstOrDefault(p => p.IDPedido == id);
            if (pedido == null)
            {
                MostrarError("Pedido no encontrado");
                return;
            }

            if (pedido.Estado == "COMPLETADO" || pedido.Estado == "CANCELADO")
            {
                MostrarError($"No se puede cancelar un pedido en estado '{pedido.Estado}'");
                return;
            }

            Console.WriteLine("\nDatos del pedido:");
            pedido.MostrarInfo();

            Console.Write("\n¿Confirmar cancelación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                // Devolver stock
                pedido.Videojuego.Stock += pedido.Cantidad;
                pedido.Estado = "CANCELADO";
                MostrarExito("Pedido cancelado correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarPedidos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE PEDIDOS ===");

            if (listaPedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados");
                return;
            }

            foreach (var p in listaPedidos.OrderByDescending(p => p.FechaPedido))
            {
                p.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void GenerarFacturaDesdePedido(Pedido pedido)
        {
            try
            {
                var factura = new Factura
                {
                    NumeroFactura = listaFacturas.Count > 0 ? listaFacturas.Max(f => f.NumeroFactura) + 1 : 1,
                    Fecha = DateTime.Now,
                    Cliente = pedido.Cliente,
                    Estado = "ACTIVA",
                    Items = new List<Factura.ItemFactura>
                    {
                        new Factura.ItemFactura
                        {
                            Videojuego = pedido.Videojuego,
                            Cantidad = pedido.Cantidad,
                            PrecioUnitario = pedido.PrecioUnitario
                        }
                    }
                };

                factura.CalcularTotales();
                listaFacturas.Add(factura);

                Console.WriteLine("\nFactura generada automáticamente:");
                factura.MostrarInfo();
                MostrarExito("Factura generada por pedido completado");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al generar factura: {ex.Message}");
            }
        }
        #endregion

        #region Gestión de Empleados
        static void GestionarEmpleados()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE EMPLEADOS ===");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Buscar Empleado");
                Console.WriteLine("3. Actualizar Empleado");
                Console.WriteLine("4. Desactivar Empleado");
                Console.WriteLine("5. Listar Empleados");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: AgregarEmpleado(); break;
                    case 2: BuscarEmpleado(); break;
                    case 3: ActualizarEmpleado(); break;
                    case 4: DesactivarEmpleado(); break;
                    case 5: ListarEmpleados(); break;
                }

            } while (opcion != 6);
        }

        static void AgregarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR EMPLEADO ===");

            try
            {
                var empleado = new Empleado();

                Console.Write("ID Empleado: ");
                if (!int.TryParse(Console.ReadLine(), out int id) || listaEmpleados.Any(e => e.IDEmpleado == id))
                    throw new ArgumentException("ID inválido o ya existe");
                empleado.IDEmpleado = id;

                Console.Write("Nombre: "); empleado.Nombre = Console.ReadLine();
                Console.Write("Apellido: "); empleado.Apellido = Console.ReadLine();

                Console.Write("Correo: ");
                string correo = Console.ReadLine();
                if (!correo.Contains("@")) throw new ArgumentException("Correo inválido");
                empleado.Correo = correo;

                Console.Write("Teléfono: "); empleado.Telefono = Console.ReadLine();

                Console.Write("Puesto: "); empleado.Puesto = Console.ReadLine();

                Console.Write("Sueldo mensual: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal sueldo)) throw new ArgumentException("Sueldo inválido");
                empleado.SueldoMensual = sueldo;

                Console.Write("Fecha de ingreso (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaIngreso))
                    throw new ArgumentException("Fecha inválida");
                empleado.FechaIngreso = fechaIngreso;

                empleado.Activo = true;
                listaEmpleados.Add(empleado);

                MostrarExito("Empleado agregado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR EMPLEADO ===");
            Console.Write("Ingrese ID, nombre o puesto: ");
            string busqueda = Console.ReadLine();

            var resultados = listaEmpleados.Where(e =>
                e.IDEmpleado.ToString().Contains(busqueda) ||
                e.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                e.Puesto.Contains(busqueda, StringComparison.OrdinalIgnoreCase)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron empleados");
                return;
            }

            foreach (var e in resultados)
            {
                e.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void ActualizarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR EMPLEADO ===");
            Console.Write("Ingrese ID del empleado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var empleado = listaEmpleados.FirstOrDefault(e => e.IDEmpleado == id);
            if (empleado == null)
            {
                MostrarError("Empleado no encontrado");
                return;
            }

            if (!empleado.Activo)
            {
                MostrarError("No se puede actualizar un empleado inactivo");
                return;
            }

            try
            {
                Console.WriteLine("\nDatos actuales:");
                empleado.MostrarInfo();

                Console.WriteLine("\nNuevos datos (deje vacío para mantener):");

                Console.Write($"Nombre ({empleado.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre)) empleado.Nombre = nombre;

                Console.Write($"Apellido ({empleado.Apellido}): ");
                string apellido = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(apellido)) empleado.Apellido = apellido;

                Console.Write($"Correo ({empleado.Correo}): ");
                string correo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@"))
                    empleado.Correo = correo;

                Console.Write($"Teléfono ({empleado.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono)) empleado.Telefono = telefono;

                Console.Write($"Puesto ({empleado.Puesto}): ");
                string puesto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(puesto)) empleado.Puesto = puesto;

                Console.Write($"Sueldo ({empleado.SueldoMensual}): ");
                string sueldoInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(sueldoInput) && decimal.TryParse(sueldoInput, out decimal sueldo))
                    empleado.SueldoMensual = sueldo;

                Console.Write($"Fecha de ingreso ({empleado.FechaIngreso:yyyy-MM-dd}): ");
                string fechaInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(fechaInput) && DateTime.TryParse(fechaInput, out DateTime fecha))
                    empleado.FechaIngreso = fecha;

                MostrarExito("Empleado actualizado correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void DesactivarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== DESACTIVAR EMPLEADO ===");
            Console.Write("Ingrese ID del empleado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarError("ID inválido");
                return;
            }

            var empleado = listaEmpleados.FirstOrDefault(e => e.IDEmpleado == id);
            if (empleado == null)
            {
                MostrarError("Empleado no encontrado");
                return;
            }

            if (!empleado.Activo)
            {
                MostrarError("El empleado ya está inactivo");
                return;
            }

            Console.WriteLine("\nDatos del empleado:");
            empleado.MostrarInfo();

            Console.Write("\n¿Confirmar desactivación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                empleado.Activo = false;
                MostrarExito("Empleado desactivado correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarEmpleados()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE EMPLEADOS ===");

            if (listaEmpleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados");
                return;
            }

            foreach (var e in listaEmpleados.OrderBy(e => e.Activo ? 0 : 1).ThenBy(e => e.Puesto))
            {
                e.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }
        #endregion

        #region Gestión de Tiendas
        static void GestionarTiendas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE TIENDAS ===");
                Console.WriteLine("1. Agregar Tienda");
                Console.WriteLine("2. Buscar Tienda");
                Console.WriteLine("3. Actualizar Tienda");
                Console.WriteLine("4. Eliminar Tienda");
                Console.WriteLine("5. Listar Tiendas");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1: AgregarTienda(); break;
                    case 2: BuscarTienda(); break;
                    case 3: ActualizarTienda(); break;
                    case 4: EliminarTienda(); break;
                    case 5: ListarTiendas(); break;
                }

            } while (opcion != 6);
        }

        static void AgregarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR TIENDA ===");

            try
            {
                var tienda = new Tienda();

                Console.Write("Nombre: "); tienda.Nombre = Console.ReadLine();
                Console.Write("Dirección: "); tienda.Direccion = Console.ReadLine();

                Console.Write("Teléfono (8 dígitos): ");
                string telefono = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefono) || !telefono.All(char.IsDigit) || telefono.Length != 8)
                    throw new ArgumentException("Teléfono inválido (deben ser 8 dígitos)");
                tienda.Telefono = telefono;

                Console.Write("Correo: ");
                string correo = Console.ReadLine();
                if (!correo.Contains("@")) throw new ArgumentException("Correo inválido");
                tienda.Correo = correo;

                Console.Write("Razón Social: "); tienda.RazonSocial = Console.ReadLine();

                Console.Write("RTN (14 dígitos): ");
                string rtn = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(rtn) || !rtn.All(char.IsDigit) || rtn.Length != 14)
                    throw new ArgumentException("RTN inválido (deben ser 14 dígitos)");
                tienda.Rtn = rtn;

                Console.Write("Ciudad: "); tienda.Ciudad = Console.ReadLine();

                listaTiendas.Add(tienda);
                MostrarExito("Tienda agregada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void BuscarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR TIENDA ===");
            Console.Write("Ingrese nombre, ciudad o RTN: ");
            string busqueda = Console.ReadLine();

            var resultados = listaTiendas.Where(t =>
                t.Nombre.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                t.Ciudad.Contains(busqueda, StringComparison.OrdinalIgnoreCase) ||
                t.Rtn.Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                MostrarError("No se encontraron tiendas");
                return;
            }

            foreach (var t in resultados)
            {
                t.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

        static void ActualizarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR TIENDA ===");
            Console.Write("Ingrese RTN de la tienda: ");
            string rtn = Console.ReadLine();

            var tienda = listaTiendas.FirstOrDefault(t => t.Rtn == rtn);
            if (tienda == null)
            {
                MostrarError("Tienda no encontrada");
                return;
            }

            try
            {
                Console.WriteLine("\nDatos actuales:");
                tienda.MostrarInfo();

                Console.WriteLine("\nNuevos datos (deje vacío para mantener):");

                Console.Write($"Nombre ({tienda.Nombre}): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre)) tienda.Nombre = nombre;

                Console.Write($"Dirección ({tienda.Direccion}): ");
                string direccion = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(direccion)) tienda.Direccion = direccion;

                Console.Write($"Teléfono ({tienda.Telefono}): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono) && telefono.All(char.IsDigit) && telefono.Length == 8)
                    tienda.Telefono = telefono;

                Console.Write($"Correo ({tienda.Correo}): ");
                string correo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@"))
                    tienda.Correo = correo;

                Console.Write($"Ciudad ({tienda.Ciudad}): ");
                string ciudad = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ciudad)) tienda.Ciudad = ciudad;

                Console.Write($"Razón Social ({tienda.RazonSocial}): ");
                string razonSocial = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(razonSocial)) tienda.RazonSocial = razonSocial;

                MostrarExito("Tienda actualizada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void EliminarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR TIENDA ===");
            Console.Write("Ingrese RTN de la tienda: ");
            string rtn = Console.ReadLine();

            var tienda = listaTiendas.FirstOrDefault(t => t.Rtn == rtn);
            if (tienda == null)
            {
                MostrarError("Tienda no encontrada");
                return;
            }

            Console.WriteLine("\nDatos de la tienda:");
            tienda.MostrarInfo();

            Console.Write("\n¿Confirmar eliminación? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaTiendas.Remove(tienda);
                MostrarExito("Tienda eliminada correctamente");
            }
            else
            {
                Console.WriteLine("Operación cancelada");
            }
        }

        static void ListarTiendas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE TIENDAS ===");

            if (listaTiendas.Count == 0)
            {
                Console.WriteLine("No hay tiendas registradas");
                return;
            }

            foreach (var t in listaTiendas)
            {
                t.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }
        #endregion
    }

    internal class Factura
    {
        public object NumeroFactura { get; internal set; }
        public Cliente Cliente { get; internal set; }
        public List<Factura.ItemFactura> Items { get; internal set; }
        public DateTime Fecha { get; internal set; }
        public string Estado { get; internal set; }

        internal void CalcularTotales()
        {
            throw new NotImplementedException();
        }

        internal void MostrarInfo()
        {
            throw new NotImplementedException();
        }

        internal class ItemFactura
        {
            public Videojuego Videojuego { get; internal set; }
            public int Cantidad { get; internal set; }
            public decimal PrecioUnitario { get; internal set; }
        }
    }
}