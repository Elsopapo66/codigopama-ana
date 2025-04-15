using System;
using System.Collections.Generic;
using Ejemplo1.Model;
using Ejemplo1.PModel;

class Program
{
    // Declaraciones Globales
    static Menu menu;
    static List<Libro> listaDeLibros;

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
                    Console.WriteLine("Saliendo del programa...");
                    run = false;
                    break;
                case 1:
                    Console.WriteLine("Agregar Libro");
                    Libro libro = crearLibro();
                    libro.Id = GenerarNuevoId();
                    listaDeLibros.Add(libro);
                    Console.WriteLine("Libro agregado con éxito.");
                    break;
                case 2:
                    Console.WriteLine("Eliminar Libro");
                    listarLibros();
                    Console.Write("Ingrese el ID del libro que desea eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar))
                    {
                        Libro libroEliminar = listaDeLibros.Find(l => l.Id == idEliminar);
                        if (libroEliminar != null)
                        {
                            listaDeLibros.Remove(libroEliminar);
                            Console.WriteLine("Libro eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un libro con ese ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Modificar Libro");
                    listarLibros();
                    Console.Write("Ingrese el ID del libro a modificar: ");
                    if (int.TryParse(Console.ReadLine(), out int idModificar))
                    {
                        int idx = listaDeLibros.FindIndex(l => l.Id == idModificar);
                        if (idx != -1)
                        {
                            Libro nuevoLibro = crearLibro();
                            nuevoLibro.Id = idModificar; // Mantener el mismo ID
                            listaDeLibros[idx] = nuevoLibro;
                            Console.WriteLine("Libro modificado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Libro no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;
                case 4:
                    listarLibros();
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        }
    }

    static void listarLibros()
    {
        Console.WriteLine("------- Lista de Libros -------");
        Console.WriteLine("| ID | Título | Autor | Género | ISBN |");

        foreach (Libro libro in listaDeLibros)
        {
            Console.WriteLine(libro);
        }

        Console.WriteLine("--------------------------------");
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

    static Libro crearLibro()
    {
        Libro libro = new Libro();

        Console.Write("Ingrese el título del libro: ");
        libro.Titulo = Console.ReadLine();

        Console.Write("Ingrese el autor del libro: ");
        libro.Autor = Console.ReadLine();

        Console.Write("Ingrese el género del libro: ");
        libro.Genero = Console.ReadLine();

        Console.Write("Ingrese el ISBN del libro: ");
        libro.Isbn = Console.ReadLine();

        return libro;
    }

    static void InitComponent()
    {
        menu = new Menu();
        menu.Opciones.Add(new Item(1, "Agregar"));
        menu.Opciones.Add(new Item(2, "Eliminar"));
        menu.Opciones.Add(new Item(3, "Modificar"));
        menu.Opciones.Add(new Item(4, "Listar"));
        menu.Opciones.Add(new Item(0, "Salir"));

        listaDeLibros = new List<Libro>
        {
            new Libro(1, "Kamasutra", "Vatsyayana, Mallanaga", "Educativo", "9783868200355")
        };
    }

    static int GenerarNuevoId()
    {
        if (listaDeLibros.Count == 0)
            return 1;
        else
            return listaDeLibros[^1].Id + 1;
    }
}
