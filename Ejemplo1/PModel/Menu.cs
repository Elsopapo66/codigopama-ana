using System;
using System.Collections.Generic;

namespace Ejemplo1.PModel
{
    public class Menu
    {
        public List<Item> Opciones { get; set; }

        public Menu()
        {
            Opciones = new List<Item>();
        }

        public override string ToString()
        {
            string linea = "+-------------------------+";
            string titulo = "|      Menu de Libros     |";
            string salto = "\n";

            string res = linea + salto;
            res += titulo + salto;
            res += linea + salto;

            foreach (var opcion in Opciones)
            {
                res += opcion.ToString() + salto;
            }

            res += linea + salto;

            return res;
        }
    }
}
