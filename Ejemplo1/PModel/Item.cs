using System;

namespace SistemaAlmacen.PModel
{
    public class Item
    {
        public int IdOpcion { get; set; }
        public string Label { get; set; }

        public Item() { }

        public Item(int id, string label)
        {
            IdOpcion = id;
            Label = label;
        }

        public override string ToString()
        {
            return $"| {IdOpcion} | {Label} |";
        }
    }
}