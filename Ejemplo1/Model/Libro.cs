using System;

namespace Ejemplo1.Model
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Isbn { get; set; }

        public Libro() { }

        public Libro(int id, string titulo, string autor, string genero, string isbn)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Isbn = isbn;
        }

        public override string ToString()
        {
            return $"| {Id} | {Titulo} | {Autor} | {Genero} | {Isbn} |";
        }
    }
}
