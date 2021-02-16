using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemRepository
{
    public class MenuItem
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Ingredients{ get; set; }
        public double Price { get; set; }

        public MenuItem() { }
        public MenuItem(int number, string name, string desc, string ingrediens, double price)
        {
            Number = number;
            Name = name;
            Desc = desc;
            Ingredients = ingrediens;
            Price = price;
        }
    }
}
