using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem() { }
        public MenuItem(int number, string name, string desc, string ingredients, decimal price )
        {
            Number = number;
            Name = name;
            Desc = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
