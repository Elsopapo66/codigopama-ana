using System;
using System.Collections;
using System.Collections.Generic;
using SistemaAlmacen.Model;
using SistemaAlmacen.PModel;

class Program
{
    // Declaraciones Globales
    static Menu menu;
    static List<Producto> listaDeProductos;

    static void Main(string[] args)
    {
        InitComponent();

        bool run = true;
        while (run)
        {
            Console.WriteLine(menu);
            Console.Write("Ingrese una opción: ");
            string txt = Console.ReadLine();

            // Validación básica
            if (!int.TryParse(txt, out int opcion))
            {
                Console.WriteLine("Debe ingresar un número válido.");
                continue;
            }

            Console.Clear();
            int index = ObtenerPosicion(menu.Opciones, opcion);
            if (index == -1)
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            string alternativa = menu.Opciones[index].Label;
            Console.WriteLine($"La opción ingresada es: {opcion} | {alternativa}");

            switch (opcion)
            {
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    run = false;
                    break;

                case 1: // ✅ Agregar Producto
                    Console.WriteLine("Agregar Producto");
                    Producto nuevoProducto = CrearProducto();
                    nuevoProducto.Id = GenerarNuevoId();
                    listaDeProductos.Add(nuevoProducto);
                    Console.WriteLine("Producto agregado con éxito.");
                    break;

                case 2: // Modificar Producto
                    Console.WriteLine("Modificar Producto");
                    ListarProductos();
                    Console.Write("Ingrese el ID del producto a modificar: ");
                    if (int.TryParse(Console.ReadLine(), out int idMod))
                    {
                        int idx = listaDeProductos.FindIndex(p => p.Id == idMod);
                        if (idx != -1)
                        {
                            Producto productoModificado = CrearProducto();
                            productoModificado.Id = idMod; // Mantener ID
                            listaDeProductos[idx] = productoModificado;
                            Console.WriteLine("Producto modificado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 3: // Eliminar Producto
                    Console.WriteLine("Eliminar Producto");
                    ListarProductos();
                    Console.Write("Ingrese el ID del producto a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Producto prodEliminar = listaDeProductos.Find(p => p.Id == idEliminar);
                        if (prodEliminar != null)
                        {
                            listaDeProductos.Remove(prodEliminar);
                            Console.WriteLine("Producto eliminado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un producto con ese ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 4: // Buscar Producto por ID
                    Console.WriteLine("Buscar Producto por ID");
                    Console.Write("Ingrese el ID del producto: ");
                    if (int.TryParse(Console.ReadLine(), out int idBuscar))
                    {
                        Producto encontrado = listaDeProductos.Find(p => p.Id == idBuscar);
                        if (encontrado != null)
                        {
                            Console.WriteLine("Producto encontrado:");
                            Console.WriteLine(encontrado);
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 5: // Listar Productos
                    ListarProductos();
                    break;

                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }

        }
    }

    static int GenerarNuevoId()
    {
        if (listaDeProductos.Count == 0)
            return 1;

        // Busca el ID máximo y le suma 1
        return listaDeProductos.Max(p => p.Id) + 1;
    }



    static void ListarProductos()
    {
        Console.WriteLine("------- Lista de Productos -------");

        if (listaDeProductos.Count == 0)
        {
            Console.WriteLine("El inventario está vacío.");
            return;
        }

        Console.WriteLine("| ID | Nombre | Precio | Stock |");
        foreach (Producto p in listaDeProductos)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("----------------------------------");
    }


    static int ObtenerPosicion(List<Item> lista, int opcion)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].IdOpcion == opcion)
                return i;
        }
        return -1;
    }

    static Producto CrearProducto()
    {
        Producto producto = new Producto();

        Console.Write("Ingrese el nombre del producto: ");
        producto.Nombre = Console.ReadLine();

        Console.Write("Ingrese el precio del producto: ");
        decimal precio; // Declaración fuera del while
        while (!decimal.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Precio inválido. Intente nuevamente: ");
        }
        producto.Precio = precio;

        Console.Write("Ingrese el stock disponible: ");
        int stock; // Declaración fuera del while
        while (!int.TryParse(Console.ReadLine(), out stock))
        {
            Console.Write("Stock inválido. Intente nuevamente: ");
        }
        producto.Stock = stock;

        return producto;
    }


    static void InitComponent()
    {
        menu = new Menu();
        menu.Opciones.Add(new Item(1, "Agregar Producto"));       // ✅ Nuevo
        menu.Opciones.Add(new Item(2, "Modificar Producto"));
        menu.Opciones.Add(new Item(3, "Eliminar Producto"));
        menu.Opciones.Add(new Item(4, "Buscar Producto por ID"));
        menu.Opciones.Add(new Item(5, "Listar Productos"));
        menu.Opciones.Add(new Item(0, "Salir"));

        listaDeProductos = new List<Producto>(); // Asumimos que usás listaDeProductos ahora
    }
}
