using PI_2025_II_2P_PROYECTO_02.clases_06;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PI_2025_II_2P_PROYECTO_02
{
    internal class Program
    {
        static List<_01_Clase_Videojuego> listaJuegos = new List<_01_Clase_Videojuego>();
        static List<_02_Clase_Cliente> listaClientes = new List<_02_Clase_Cliente>();
        static List<_03_Clase_Factura> listaFacturas = new List<_03_Clase_Factura>();
        static List<_04_Clase_Pedido> listaPedidos = new List<_04_Clase_Pedido>();
        static List<_05_Clase_Empleado> listaEmpleados = new List<_05_Clase_Empleado>();
        static List<_06_Clase_Tienda> listaTiendas = new List<_06_Clase_Tienda>();

        static void Main(string[] args)
        {
            // Cargar datos al iniciar
            listaClientes = JsonHelper.CargarDesdeJson<_02_Clase_Cliente>("clientes.json");
            listaEmpleados = JsonHelper.CargarDesdeJson<_05_Clase_Empleado>("empleados.json");
            listaJuegos = JsonHelper.CargarDesdeJson<_01_Clase_Videojuego>("videojuegos.json");
            listaFacturas = JsonHelper.CargarDesdeJson<_03_Clase_Factura>("facturas.json");
            listaPedidos = JsonHelper.CargarDesdeJson<_04_Clase_Pedido>("pedidos.json");
            listaTiendas = JsonHelper.CargarDesdeJson<_06_Clase_Tienda>("tiendas.json");
            4
            int opcionPrincipal;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE TIENDA DE VIDEOJUEGOS ===");
                Console.WriteLine("1. Gestión de Videojuegos");
                Console.WriteLine("2. Gestión de Clientes");
                Console.WriteLine("3. Gestión de Facturas");
                Console.WriteLine("4. Gestión de Pedidos");
                Console.WriteLine("5. Gestión de Empleados");
                Console.WriteLine("6. Gestión de Tiendas");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionPrincipal)) continue;

                switch (opcionPrincipal)
                {
                    case 1:
                        GestionarVideojuegos();
                        break;
                    case 2:
                        GestionarClientes();
                        break;
                    case 3:
                        GestionarFacturas();
                        break;
                    case 4:
                        GestionarPedidos();
                        break;
                    case 5:
                        GestionarEmpleados();
                        break;
                    case 6:
                        GestionarTiendas();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcionPrincipal != 7)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcionPrincipal != 7);
        }

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
                    case 1:
                        AgregarVideojuego();
                        break;
                    case 2:
                        BuscarVideojuego();
                        break;
                    case 3:
                        ActualizarVideojuego();
                        break;
                    case 4:
                        EliminarVideojuego();
                        break;
                    case 5:
                        ListarVideojuegos();
                        break;
                }

            } while (opcion != 6);
        }

        static void AgregarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR VIDEOJUEGO ===");

            var juego = new _01_Clase_Videojuego();

            Console.Write("Título: "); juego.Titulo = Console.ReadLine();
            Console.Write("Género: "); juego.Genero = Console.ReadLine();

            decimal precio;
            Console.Write("Precio: ");
            while (!decimal.TryParse(Console.ReadLine(), out precio)) Console.Write("Inválido. Precio: ");
            juego.Precio = precio;

            Console.Write("Clasificación: "); juego.ClasificacionEdad = Console.ReadLine();
            Console.Write("Plataforma: "); juego.Plataforma = Console.ReadLine();

            int stock;
            Console.Write("Stock: ");
            while (!int.TryParse(Console.ReadLine(), out stock)) Console.Write("Inválido. Stock: ");
            juego.Stock = stock;

            Console.Write("Código: "); juego.CodigoJuego = Console.ReadLine();

            listaJuegos.Add(juego);
            Console.WriteLine("\n✅ Videojuego agregado correctamente.");
        }

        static void BuscarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR VIDEOJUEGO ===");
            Console.Write("Ingrese código o título del juego: ");
            string busqueda = Console.ReadLine();

            var resultados = listaJuegos.Where(j =>
                j.CodigoJuego.Contains(busqueda) ||
                j.Titulo.Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron videojuegos.");
                return;
            }

            Console.WriteLine("\nResultados de búsqueda:");
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
            Console.Write("Ingrese código del juego a actualizar: ");
            string codigo = Console.ReadLine();

            var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego == codigo);
            if (juego == null)
            {
                Console.WriteLine("Videojuego no encontrado.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            juego.MostrarInfo();

            Console.WriteLine("\nIngrese nuevos datos (deje en blanco para mantener el valor actual):");

            Console.Write($"Título ({juego.Titulo}): ");
            string nuevoTitulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoTitulo)) juego.Titulo = nuevoTitulo;

            Console.Write($"Género ({juego.Genero}): ");
            string nuevoGenero = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoGenero)) juego.Genero = nuevoGenero;

            Console.Write($"Precio ({juego.Precio}): ");
            string precioInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(precioInput) && decimal.TryParse(precioInput, out decimal nuevoPrecio))
                juego.Precio = nuevoPrecio;

            Console.Write($"Clasificación ({juego.ClasificacionEdad}): ");
            string nuevaClasificacion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaClasificacion)) juego.ClasificacionEdad = nuevaClasificacion;

            Console.Write($"Plataforma ({juego.Plataforma}): ");
            string nuevaPlataforma = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaPlataforma)) juego.Plataforma = nuevaPlataforma;

            Console.Write($"Stock ({juego.Stock}): ");
            string stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int nuevoStock))
                juego.Stock = nuevoStock;

            Console.WriteLine("\n✅ Videojuego actualizado correctamente.");
        }

        static void EliminarVideojuego()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR VIDEOJUEGO ===");
            Console.Write("Ingrese código del juego a eliminar: ");
            string codigo = Console.ReadLine();

            var juego = listaJuegos.FirstOrDefault(j => j.CodigoJuego == codigo);
            if (juego == null)
            {
                Console.WriteLine("Videojuego no encontrado.");
                return;
            }

            Console.WriteLine("\nDatos del videojuego a eliminar:");
            juego.MostrarInfo();

            Console.Write("\n¿Está seguro que desea eliminar este videojuego? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaJuegos.Remove(juego);
                Console.WriteLine("✅ Videojuego eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }

        static void ListarVideojuegos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE VIDEOJUEGOS ===");

            if (listaJuegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos registrados.");
                return;
            }

            foreach (var j in listaJuegos)
            {
                j.MostrarInfo();
                Console.WriteLine("-------------------");
            }
        }

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
                    case 1:
                        AgregarCliente();
                        break;
                    case 2:
                        BuscarCliente();
                        break;
                    case 3:
                        ActualizarCliente();
                        break;
                    case 4:
                        EliminarCliente();
                        break;
                    case 5:
                        ListarClientes();
                        break;
                }

            } while (opcion != 6);
        }

        static void AgregarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR CLIENTE ===");

            var cliente = new _02_Clase_Cliente();

            Console.Write("Nombre: "); cliente.Nombre = Console.ReadLine();
            Console.Write("Apellido: "); cliente.Apellido = Console.ReadLine();

            Console.Write("Correo: ");
            string correo;
            do
            {
                correo = Console.ReadLine();
                if (!correo.Contains("@")) Console.Write("Correo inválido. Intente nuevamente: ");
            } while (!correo.Contains("@"));
            cliente.Correo = correo;

            Console.Write("Teléfono: "); cliente.Telefono = Console.ReadLine();
            Console.Write("Dirección: "); cliente.Direccion = Console.ReadLine();

            int edad;
            Console.Write("Edad: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad < 1)
                Console.Write("Edad inválida. Intente nuevamente: ");
            cliente.Edad = edad;

            int id;
            Console.Write("ID Cliente: ");
            while (!int.TryParse(Console.ReadLine(), out id) || listaClientes.Any(c => c.CodigoCliente == id))
                Console.Write("ID inválido o ya existe. Intente nuevamente: ");
            cliente.CodigoCliente = id;

            listaClientes.Add(cliente);
            Console.WriteLine("\n✅ Cliente agregado correctamente.");
        }

        static void BuscarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR CLIENTE ===");
            Console.Write("Ingrese ID, nombre o apellido: ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = listaClientes.Where(c =>
                c.CodigoCliente.ToString().Contains(busqueda) ||
                c.Nombre.ToLower().Contains(busqueda) ||
                c.Apellido.ToLower().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron clientes.");
                return;
            }

            Console.WriteLine("\nResultados:");
            Console.WriteLine("=========================================");
            foreach (var c in resultados)
            {
                c.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void ActualizarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR CLIENTE ===");
            Console.Write("Ingrese ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            cliente.MostrarInfo();

            Console.WriteLine("\nIngrese nuevos datos (deje vacío para mantener):");

            Console.Write($"Nombre ({cliente.Nombre}): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) cliente.Nombre = nombre;

            Console.Write($"Apellido ({cliente.Apellido}): ");
            string apellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellido)) cliente.Apellido = apellido;

            Console.Write($"Correo ({cliente.Correo}): ");
            string correo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@")) cliente.Correo = correo;

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

            Console.WriteLine("\n✅ Cliente actualizado correctamente.");
        }

        static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR CLIENTE ===");
            Console.Write("Ingrese ID del cliente: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var cliente = listaClientes.FirstOrDefault(c => c.CodigoCliente == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("\nDatos del cliente:");
            cliente.MostrarInfo();

            Console.Write("\n¿Está seguro de eliminar este cliente? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaClientes.Remove(cliente);
                Console.WriteLine("✅ Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE CLIENTES ===");

            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
                return;
            }

            Console.WriteLine("Total de clientes: " + listaClientes.Count);
            Console.WriteLine("=========================================");
            foreach (var c in listaClientes)
            {
                c.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

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
                    case 1:
                        AgregarTienda();
                        break;
                    case 2:
                        BuscarTienda();
                        break;
                    case 3:
                        ActualizarTienda();
                        break;
                    case 4:
                        EliminarTienda();
                        break;
                    case 5:
                        ListarTiendas();
                        break;
                }

            } while (opcion != 6);
        }

        static void AgregarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR TIENDA ===");

            var tienda = new _06_Clase_Tienda();

            Console.Write("Nombre: "); tienda.Nombre = Console.ReadLine();
            Console.Write("Dirección: "); tienda.Direccion = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefono;
            do
            {
                telefono = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefono))
                    Console.Write("Teléfono no puede estar vacío. Intente nuevamente: ");
            } while (string.IsNullOrWhiteSpace(telefono));
            tienda.Telefono = telefono;

            Console.Write("Correo: ");
            string correo;
            do
            {
                correo = Console.ReadLine();
                if (!correo.Contains("@")) Console.Write("Correo inválido. Intente nuevamente: ");
            } while (!correo.Contains("@"));
            tienda.Correo = correo;

            Console.Write("Ciudad: "); tienda.Ciudad = Console.ReadLine();

            Console.Write("RTN: ");
            string rtn;
            do
            {
                rtn = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(rtn))
                    Console.Write("RTN no puede estar vacío. Intente nuevamente: ");
            } while (string.IsNullOrWhiteSpace(rtn));
            tienda.Rtn = rtn;

            Console.Write("Razón Social: "); tienda.RazonSocial = Console.ReadLine();

            listaTiendas.Add(tienda);
            Console.WriteLine("\n✅ Tienda agregada correctamente.");
        }

        static void BuscarTienda()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR TIENDA ===");
            Console.Write("Ingrese nombre, ciudad o RTN: ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = listaTiendas.Where(t =>
                t.Nombre.ToLower().Contains(busqueda) ||
                t.Ciudad.ToLower().Contains(busqueda) ||
                t.Rtn.ToLower().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron tiendas.");
                return;
            }

            Console.WriteLine("\nResultados:");
            Console.WriteLine("=========================================");
            foreach (var t in resultados)
            {
                t.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
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
                Console.WriteLine("Tienda no encontrada.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            tienda.MostrarInfo();

            Console.WriteLine("\nIngrese nuevos datos (deje vacío para mantener):");

            Console.Write($"Nombre ({tienda.Nombre}): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) tienda.Nombre = nombre;

            Console.Write($"Dirección ({tienda.Direccion}): ");
            string direccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(direccion)) tienda.Direccion = direccion;

            Console.Write($"Teléfono ({tienda.Telefono}): ");
            string telefono = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefono)) tienda.Telefono = telefono;

            Console.Write($"Correo ({tienda.Correo}): ");
            string correo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@")) tienda.Correo = correo;

            Console.Write($"Ciudad ({tienda.Ciudad}): ");
            string ciudad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ciudad)) tienda.Ciudad = ciudad;

            Console.Write($"Razón Social ({tienda.RazonSocial}): ");
            string razonSocial = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(razonSocial)) tienda.RazonSocial = razonSocial;

            Console.WriteLine("\n✅ Tienda actualizada correctamente.");
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
                Console.WriteLine("Tienda no encontrada.");
                return;
            }

            Console.WriteLine("\nDatos de la tienda:");
            tienda.MostrarInfo();

            Console.Write("\n¿Está seguro de eliminar esta tienda? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                listaTiendas.Remove(tienda);
                Console.WriteLine("✅ Tienda eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }

        static void ListarTiendas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE TIENDAS ===");

            if (listaTiendas.Count == 0)
            {
                Console.WriteLine("No hay tiendas registradas.");
                return;
            }

            Console.WriteLine("Total de tiendas: " + listaTiendas.Count);
            Console.WriteLine("=========================================");
            foreach (var t in listaTiendas)
            {
                t.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void GestionarFacturas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE FACTURAS ===");
                Console.WriteLine("1. Crear Factura");
                Console.WriteLine("2. Buscar Factura");
                Console.WriteLine("3. Actualizar Factura");
                Console.WriteLine("4. Anular Factura");
                Console.WriteLine("5. Listar Facturas");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        CrearFactura();
                        break;
                    case 2:
                        BuscarFactura();
                        break;
                    case 3:
                        ActualizarFactura();
                        break;
                    case 4:
                        AnularFactura();
                        break;
                    case 5:
                        ListarFacturas();
                        break;
                }

            } while (opcion != 6);
        }

        static void CrearFactura()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR FACTURA ===");

            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados. Debe registrar al menos un cliente primero.");
                return;
            }

            if (listaJuegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos registrados. Debe registrar al menos un videojuego primero.");
                return;
            }

            int numeroFactura;
            Console.Write("Número de Factura: ");
            while (!int.TryParse(Console.ReadLine(), out numeroFactura) || listaFacturas.Any(f => f.NumeroFactura == numeroFactura))
                Console.Write("Número inválido o ya existe. Ingrese nuevamente: ");

            Console.WriteLine("\nClientes disponibles:");
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"{cliente.CodigoCliente} - {cliente.Nombre} {cliente.Apellido}");
            }
            int idCliente;
            Console.Write("\nID del Cliente: ");
            while (!int.TryParse(Console.ReadLine(), out idCliente))
                Console.Write("ID inválido. Ingrese nuevamente: ");

            var clienteFactura = listaClientes.FirstOrDefault(c => c.CodigoCliente == idCliente);
            if (clienteFactura == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            var items = new List<_03_Clase_Factura.ItemFactura>();
            char continuar;

            do
            {
                Console.WriteLine("\nVideojuegos disponibles:");
                foreach (var juego in listaJuegos.Where(j => j.Stock > 0))
                {
                    Console.WriteLine($"{juego.CodigoJuego} - {juego.Titulo} (Stock: {juego.Stock}) - ${juego.Precio}");
                }

                Console.Write("\nCódigo del Videojuego: ");
                string codigoJuego = Console.ReadLine();
                var juegoSeleccionado = listaJuegos.FirstOrDefault(j => j.CodigoJuego == codigoJuego);
                if (juegoSeleccionado == null)
                {
                    Console.WriteLine("Videojuego no encontrado.");
                    continue;
                }

                int cantidad;
                Console.Write("Cantidad: ");
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad > juegoSeleccionado.Stock)
                    Console.Write($"Cantidad inválida (máx. {juegoSeleccionado.Stock}). Ingrese nuevamente: ");

                items.Add(new _03_Clase_Factura.ItemFactura
                {
                    Videojuego = juegoSeleccionado,
                    Cantidad = cantidad,
                    PrecioUnitario = juegoSeleccionado.Precio
                });

                juegoSeleccionado.Stock -= cantidad;

                Console.Write("\n¿Desea agregar otro item? (S/N): ");
                continuar = Console.ReadKey().KeyChar;
                Console.WriteLine();

            } while (continuar.ToString().ToUpper() == "S");

            var factura = new _03_Clase_Factura
            {
                NumeroFactura = numeroFactura,
                Fecha = DateTime.Now,
                Cliente = clienteFactura,
                Items = items,
                Estado = "ACTIVA"
            };

            factura.CalcularTotales();
            listaFacturas.Add(factura);

            Console.WriteLine("\n✅ Factura creada exitosamente:");
            factura.MostrarInfo();
        }

        static void BuscarFactura()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR FACTURA ===");
            Console.Write("Ingrese número de factura, ID cliente o estado (ACTIVA/ANULADA): ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = listaFacturas.Where(f =>
                f.NumeroFactura.ToString().Contains(busqueda) ||
                f.Cliente.CodigoCliente.ToString().Contains(busqueda) ||
                f.Estado.ToLower().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron facturas.");
                return;
            }

            Console.WriteLine("\nResultados:");
            Console.WriteLine("=========================================");
            foreach (var f in resultados)
            {
                f.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void ActualizarFactura()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR FACTURA ===");
            Console.Write("Ingrese número de factura: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroFactura))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            var factura = listaFacturas.FirstOrDefault(f => f.NumeroFactura == numeroFactura);
            if (factura == null)
            {
                Console.WriteLine("Factura no encontrada.");
                return;
            }

            if (factura.Estado == "ANULADA")
            {
                Console.WriteLine("No se puede actualizar una factura anulada.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            factura.MostrarInfo();

            Console.WriteLine("\nOpciones de actualización:");
            Console.WriteLine("1. Agregar items");
            Console.WriteLine("2. Cambiar estado");
            Console.Write("Seleccione opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion)) return;

            char continuar;

            switch (opcion)
            {
                case 1:
                    do
                    {

                        Console.WriteLine("\nVideojuegos disponibles:");
                        foreach (var juego in listaJuegos.Where(j => j.Stock > 0))
                        {
                            Console.WriteLine($"{juego.CodigoJuego} - {juego.Titulo} (Stock: {juego.Stock}) - ${juego.Precio}");
                        }

                        Console.Write("\nCódigo del Videojuego: ");
                        string codigoJuego = Console.ReadLine();
                        var juegoSeleccionado = listaJuegos.FirstOrDefault(j => j.CodigoJuego == codigoJuego);
                        if (juegoSeleccionado == null)
                        {
                            Console.WriteLine("Videojuego no encontrado.");
                            continue;
                        }

                        int cantidad;
                        Console.Write("Cantidad: ");
                        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad > juegoSeleccionado.Stock)
                            Console.Write($"Cantidad inválida (máx. {juegoSeleccionado.Stock}). Ingrese nuevamente: ");

                        factura.Items.Add(new _03_Clase_Factura.ItemFactura
                        {
                            Videojuego = juegoSeleccionado,
                            Cantidad = cantidad,
                            PrecioUnitario = juegoSeleccionado.Precio
                        });

                        juegoSeleccionado.Stock -= cantidad;

                        Console.Write("\n¿Desea agregar otro item? (S/N): ");
                        continuar = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                    }
                    while (continuar.ToString().ToUpper() == "S");

                    factura.CalcularTotales();
                    Console.WriteLine("\n✅ Items agregados correctamente.");
                    break;

                case 2:
                    Console.Write("\nNuevo estado (ACTIVA/ANULADA): ");
                    string nuevoEstado = Console.ReadLine().ToUpper();
                    if (nuevoEstado == "ACTIVA" || nuevoEstado == "ANULADA")
                    {
                        factura.Estado = nuevoEstado;
                        Console.WriteLine("\n✅ Estado actualizado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("\nEstado inválido.");
                    }
                    break;

                default:
                    Console.WriteLine("\nOpción inválida.");
                    break;
            }
        }

        static void AnularFactura()
        {
            Console.Clear();
            Console.WriteLine("=== ANULAR FACTURA ===");
            Console.Write("Ingrese número de factura: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroFactura))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            var factura = listaFacturas.FirstOrDefault(f => f.NumeroFactura == numeroFactura);
            if (factura == null)
            {
                Console.WriteLine("Factura no encontrada.");
                return;
            }

            if (factura.Estado == "ANULADA")
            {
                Console.WriteLine("La factura ya está anulada.");
                return;
            }

            Console.WriteLine("\nDatos de la factura:");
            factura.MostrarInfo();

            Console.Write("\n¿Está seguro que desea anular esta factura? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                foreach (var item in factura.Items)
                {
                    item.Videojuego.Stock += item.Cantidad;
                }

                factura.Estado = "ANULADA";
                Console.WriteLine("\n✅ Factura anulada correctamente.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
        }

        static void ListarFacturas()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE FACTURAS ===");

            if (listaFacturas.Count == 0)
            {
                Console.WriteLine("No hay facturas registradas.");
                return;
            }

            Console.WriteLine($"Total de facturas: {listaFacturas.Count}");
            Console.WriteLine($"Facturas activas: {listaFacturas.Count(f => f.Estado == "ACTIVA")}");
            Console.WriteLine($"Facturas anuladas: {listaFacturas.Count(f => f.Estado == "ANULADA")}");
            Console.WriteLine("=========================================");

            foreach (var f in listaFacturas.OrderByDescending(f => f.Fecha))
            {
                f.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

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
                    case 1:
                        CrearPedido();
                        break;
                    case 2:
                        BuscarPedido();
                        break;
                    case 3:
                        ActualizarPedido();
                        break;
                    case 4:
                        CancelarPedido();
                        break;
                    case 5:
                        ListarPedidos();
                        break;
                }

            } while (opcion != 6);
        }

        static void CrearPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CREAR PEDIDO ===");

            if (listaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados. Debe registrar al menos un cliente primero.");
                return;
            }

            if (listaJuegos.Count == 0)
            {
                Console.WriteLine("No hay videojuegos registrados. Debe registrar al menos un videojuego primero.");
                return;
            }

            int idPedido;
            Console.Write("ID del Pedido: ");
            while (!int.TryParse(Console.ReadLine(), out idPedido) || listaPedidos.Any(p => p.IDPedido == idPedido))
                Console.Write("ID inválido o ya existe. Ingrese nuevamente: ");

            Console.WriteLine("\nClientes disponibles:");
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"{cliente.CodigoCliente} - {cliente.Nombre} {cliente.Apellido}");
            }
            int idCliente;
            Console.Write("\nID del Cliente: ");
            while (!int.TryParse(Console.ReadLine(), out idCliente))
                Console.Write("ID inválido. Ingrese nuevamente: ");

            var clientePedido = listaClientes.FirstOrDefault(c => c.CodigoCliente == idCliente);
            if (clientePedido == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.WriteLine("\nVideojuegos disponibles:");
            foreach (var juego in listaJuegos.Where(j => j.Stock > 0))
            {
                Console.WriteLine($"{juego.CodigoJuego} - {juego.Titulo} (Stock: {juego.Stock}) - ${juego.Precio}");
            }

            Console.Write("\nCódigo del Videojuego: ");
            string codigoJuego = Console.ReadLine();
            var juegoPedido = listaJuegos.FirstOrDefault(j => j.CodigoJuego == codigoJuego);
            if (juegoPedido == null)
            {
                Console.WriteLine("Videojuego no encontrado.");
                return;
            }

            int cantidad;
            Console.Write("Cantidad: ");
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0 || cantidad > juegoPedido.Stock)
                Console.Write($"Cantidad inválida (máx. {juegoPedido.Stock}). Ingrese nuevamente: ");

            Console.Write("Estado (PENDIENTE/EN PROCESO/COMPLETADO): ");
            string estado = Console.ReadLine().ToUpper();
            if (estado != "PENDIENTE" && estado != "EN PROCESO" && estado != "COMPLETADO")
            {
                estado = "PENDIENTE";
                Console.WriteLine("Estado inválido. Se asignará 'PENDIENTE' por defecto.");
            }

            var pedido = new _04_Clase_Pedido
            {
                IDPedido = idPedido,
                FechaPedido = DateTime.Now,
                Cliente = clientePedido,
                Videojuego = juegoPedido,
                Cantidad = cantidad,
                PrecioUnitario = juegoPedido.Precio,
                Estado = estado
            };
            pedido.CalcularTotal();

            juegoPedido.Stock -= cantidad;

            listaPedidos.Add(pedido);
            Console.WriteLine("\n✅ Pedido creado exitosamente:");
            pedido.MostrarInfo();
        }

        static void BuscarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR PEDIDO ===");
            Console.Write("Ingrese ID de pedido, ID cliente o estado (PENDIENTE/EN PROCESO/COMPLETADO): ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = listaPedidos.Where(p =>
                p.IDPedido.ToString().Contains(busqueda) ||
                p.Cliente.CodigoCliente.ToString().Contains(busqueda) ||
                p.Estado.ToLower().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron pedidos.");
                return;
            }

            Console.WriteLine("\nResultados:");
            Console.WriteLine("=========================================");
            foreach (var p in resultados)
            {
                p.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void ActualizarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR PEDIDO ===");
            Console.Write("Ingrese ID del pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var pedido = listaPedidos.FirstOrDefault(p => p.IDPedido == idPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }

            if (pedido.Estado == "COMPLETADO" || pedido.Estado == "CANCELADO")
            {
                Console.WriteLine($"No se puede actualizar un pedido en estado '{pedido.Estado}'.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            pedido.MostrarInfo();

            Console.WriteLine("\nOpciones de actualización:");
            Console.WriteLine("1. Cambiar cantidad");
            Console.WriteLine("2. Cambiar estado");
            Console.Write("Seleccione opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion)) return;

            switch (opcion)
            {
                case 1:
                    Console.Write($"\nNueva cantidad (actual: {pedido.Cantidad}, máx: {pedido.Videojuego.Stock + pedido.Cantidad}): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaCantidad) && nuevaCantidad > 0)
                    {
                        pedido.Videojuego.Stock += pedido.Cantidad;

                        if (nuevaCantidad <= pedido.Videojuego.Stock)
                        {
                            pedido.Cantidad = nuevaCantidad;
                            pedido.Videojuego.Stock -= nuevaCantidad;
                            pedido.CalcularTotal();
                            Console.WriteLine("\n✅ Cantidad actualizada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("\nNo hay suficiente stock disponible.");
                            pedido.Videojuego.Stock -= pedido.Cantidad;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCantidad inválida.");
                        pedido.Videojuego.Stock -= pedido.Cantidad;
                    }
                    break;

                case 2:
                    Console.Write("\nNuevo estado (PENDIENTE/EN PROCESO/COMPLETADO): ");
                    string nuevoEstado = Console.ReadLine().ToUpper();
                    if (nuevoEstado == "PENDIENTE" || nuevoEstado == "EN PROCESO" || nuevoEstado == "COMPLETADO")
                    {
                        pedido.Estado = nuevoEstado;
                        Console.WriteLine("\n✅ Estado actualizado correctamente.");

                        if (nuevoEstado == "COMPLETADO")
                        {
                            GenerarFacturaDesdePedido(pedido);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nEstado inválido.");
                    }
                    break;

                default:
                    Console.WriteLine("\nOpción inválida.");
                    break;
            }
        }

        static void CancelarPedido()
        {
            Console.Clear();
            Console.WriteLine("=== CANCELAR PEDIDO ===");
            Console.Write("Ingrese ID del pedido: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var pedido = listaPedidos.FirstOrDefault(p => p.IDPedido == idPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }

            if (pedido.Estado == "COMPLETADO" || pedido.Estado == "CANCELADO")
            {
                Console.WriteLine($"No se puede cancelar un pedido en estado '{pedido.Estado}'.");
                return;
            }

            Console.WriteLine("\nDatos del pedido:");
            pedido.MostrarInfo();

            Console.Write("\n¿Está seguro que desea cancelar este pedido? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                pedido.Videojuego.Stock += pedido.Cantidad;
                pedido.Estado = "CANCELADO";
                Console.WriteLine("\n✅ Pedido cancelado correctamente.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
        }

        static void ListarPedidos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE PEDIDOS ===");

            if (listaPedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }

            Console.WriteLine($"Total de pedidos: {listaPedidos.Count}");
            Console.WriteLine($"Pedidos pendientes: {listaPedidos.Count(p => p.Estado == "PENDIENTE")}");
            Console.WriteLine($"Pedidos en proceso: {listaPedidos.Count(p => p.Estado == "EN PROCESO")}");
            Console.WriteLine($"Pedidos completados: {listaPedidos.Count(p => p.Estado == "COMPLETADO")}");
            Console.WriteLine($"Pedidos cancelados: {listaPedidos.Count(p => p.Estado == "CANCELADO")}");
            Console.WriteLine("=========================================");

            foreach (var p in listaPedidos.OrderByDescending(p => p.FechaPedido))
            {
                p.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void GenerarFacturaDesdePedido(_04_Clase_Pedido pedido)
        {
            int numeroFactura = listaFacturas.Count > 0 ? listaFacturas.Max(f => f.NumeroFactura) + 1 : 1;

            var factura = new _03_Clase_Factura
            {
                NumeroFactura = numeroFactura,
                Fecha = DateTime.Now,
                Cliente = pedido.Cliente,
                Estado = "ACTIVA",
                Items = new List<_03_Clase_Factura.ItemFactura>
                {
                    new _03_Clase_Factura.ItemFactura
                    {
                        Videojuego = pedido.Videojuego,
                        Cantidad = pedido.Cantidad,
                        PrecioUnitario = pedido.PrecioUnitario
                    }
                }
            };
            factura.CalcularTotales();
            listaFacturas.Add(factura);

            Console.WriteLine("\n✅ Factura generada automáticamente por pedido completado:");
            factura.MostrarInfo();
        }

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
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        BuscarEmpleado();
                        break;
                    case 3:
                        ActualizarEmpleado();
                        break;
                    case 4:
                        DesactivarEmpleado();
                        break;
                    case 5:
                        ListarEmpleados();
                        break;
                }

            } while (opcion != 6);
        }

        static void AgregarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR EMPLEADO ===");

            var empleado = new _05_Clase_Empleado();

            int id;
            Console.Write("ID Empleado: ");
            while (!int.TryParse(Console.ReadLine(), out id) || listaEmpleados.Any(e => e.IDEmpleado == id))
                Console.Write("ID inválido o ya existe. Ingrese nuevamente: ");
            empleado.IDEmpleado = id;

            Console.Write("Nombre: "); empleado.Nombre = Console.ReadLine();
            Console.Write("Apellido: "); empleado.Apellido = Console.ReadLine();

            Console.Write("Correo: ");
            string correo;
            do
            {
                correo = Console.ReadLine();
                if (!correo.Contains("@")) Console.Write("Correo inválido. Intente nuevamente: ");
            } while (!correo.Contains("@"));
            empleado.Correo = correo;

            Console.Write("Teléfono: "); empleado.Telefono = Console.ReadLine();

            Console.Write("Puesto (VENDEDOR/GERENTE/ALMACEN): ");
            string puesto;
            do
            {
                puesto = Console.ReadLine().ToUpper();
                if (puesto != "VENDEDOR" && puesto != "GERENTE" && puesto != "ALMACEN")
                    Console.Write("Puesto inválido (VENDEDOR/GERENTE/ALMACEN). Intente nuevamente: ");
            } while (puesto != "VENDEDOR" && puesto != "GERENTE" && puesto != "ALMACEN");
            empleado.Puesto = puesto;

            decimal sueldo;
            Console.Write("Sueldo mensual: ");
            while (!decimal.TryParse(Console.ReadLine(), out sueldo) || sueldo <= 0)
                Console.Write("Sueldo inválido. Ingrese nuevamente: ");
            empleado.SueldoMensual = sueldo;

            Console.Write("Fecha de ingreso (yyyy-MM-dd): ");
            DateTime fechaIngreso;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaIngreso))
                Console.Write("Fecha inválida. Ingrese nuevamente (yyyy-MM-dd): ");
            empleado.FechaIngreso = fechaIngreso;

            empleado.Activo = true;
            listaEmpleados.Add(empleado);

            Console.WriteLine("\n✅ Empleado agregado correctamente:");
            empleado.MostrarInfo();
        }

        static void BuscarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR EMPLEADO ===");
            Console.Write("Ingrese ID, nombre, apellido o puesto: ");
            string busqueda = Console.ReadLine().ToLower();

            var resultados = listaEmpleados.Where(e =>
                e.IDEmpleado.ToString().Contains(busqueda) ||
                e.Nombre.ToLower().Contains(busqueda) ||
                e.Puesto.ToLower().Contains(busqueda)).ToList();

            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron empleados.");
                return;
            }

            Console.WriteLine("\nResultados:");
            Console.WriteLine("=========================================");
            foreach (var e in resultados)
            {
                e.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }

        static void ActualizarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR EMPLEADO ===");
            Console.Write("Ingrese ID del empleado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var empleado = listaEmpleados.FirstOrDefault(e => e.IDEmpleado == id);
            if (empleado == null)
            {
                Console.WriteLine("Empleado no encontrado.");
                return;
            }

            if (!empleado.Activo)
            {
                Console.WriteLine("No se puede actualizar un empleado inactivo.");
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            empleado.MostrarInfo();

            Console.WriteLine("\nIngrese nuevos datos (deje vacío para mantener):");

            Console.Write($"Nombre ({empleado.Nombre}): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) empleado.Nombre = nombre;

            Console.Write($"Apellido ({empleado.Apellido}): ");
            string apellido = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(apellido)) empleado.Apellido = apellido;

            Console.Write($"Correo ({empleado.Correo}): ");
            string correo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(correo) && correo.Contains("@")) empleado.Correo = correo;

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

            Console.WriteLine("\n✅ Empleado actualizado correctamente.");
        }

        static void DesactivarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("=== DESACTIVAR EMPLEADO ===");
            Console.Write("Ingrese ID del empleado: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var empleado = listaEmpleados.FirstOrDefault(e => e.IDEmpleado == id);
            if (empleado == null)
            {
                Console.WriteLine("Empleado no encontrado.");
                return;
            }

            if (!empleado.Activo)
            {
                Console.WriteLine("El empleado ya está inactivo.");
                return;
            }

            Console.WriteLine("\nDatos del empleado:");
            empleado.MostrarInfo();

            Console.Write("\n¿Está seguro que desea desactivar este empleado? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S")
            {
                empleado.Activo = false;
                Console.WriteLine("\n✅ Empleado desactivado correctamente.");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
        }

        static void ListarEmpleados()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE EMPLEADOS ===");

            if (listaEmpleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            Console.WriteLine($"Total de empleados: {listaEmpleados.Count}");
            Console.WriteLine($"Empleados activos: {listaEmpleados.Count(e => e.Activo)}");
            Console.WriteLine($"Empleados inactivos: {listaEmpleados.Count(e => !e.Activo)}");
            Console.WriteLine("=========================================");

            foreach (var e in listaEmpleados.OrderByDescending(e => e.Activo).ThenBy(e => e.Puesto))
            {
                e.MostrarInfo();
                Console.WriteLine("-----------------------------------------");
            }
        }
    }
}