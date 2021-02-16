using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemRepository
{
    public class MenuItemRepo
    {
        private List<MenuItem> _menu = new List<MenuItem>();

        // CREATE
        public bool AddMenuItem(MenuItem newMenuItem)
        {
            int startingCount = _menu.Count;
            _menu.Add(newMenuItem);

            bool wasAdded = _menu.Count > startingCount;
            return wasAdded;
        }

        // READ
        public List<MenuItem> GetMenuItems()
        {
            return _menu;
        }

        public MenuItem GetItemByNumber(int number)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if(menuItem.Number == number)
                {
                    return menuItem;
                }
            }
            return null;
        }

        // UPDATE - We don't need to be able to update items right now

        // DELETE
        public bool RemoveMenuItem(int number)
        {
            int startingCount = _menu.Count;
            MenuItem menuItem = GetItemByNumber(number);
            _menu.Remove(menuItem);

            bool wasRemoved = _menu.Count < startingCount;
            return wasRemoved;
        }

    }
}
