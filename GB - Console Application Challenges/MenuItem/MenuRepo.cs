using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuRepo
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();
        
        // CREATE
        public bool AddMenuItem(MenuItem newMenuItem)
        {
            int startingCount = _menu.Count;
            _menu.Add(newMenuItem);

            bool wasAdded = _menu.Count > startingCount;
            return wasAdded;
        }
        
        // READ
        public List<MenuItem> GetAllMenuItems()
        {
            return _menu;
        }

        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.Name.ToLower() == name.ToLower())
                {
                    return menuItem;
                }
            }
                return null;
        }

        public MenuItem GetItemByNumber(int number)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.Number == number)
                {
                    return menuItem;
                }
            }
                return null;
        }

        // UPDATE -- We don't need to be able to update items right now.


        // DELETE
        public bool RemoveMenuItemByName(string name)
        {
            MenuItem menuItem = GetItemByName(name);
            if (menuItem == null)
            {
                return false;
            }
            _menu.Remove(menuItem);
            return true;
        }
        public bool RemoveMenuItemByNumber(int number)
        {
            MenuItem menuItem = GetItemByNumber(number);
            if (menuItem == null)
            {
                return false;
            }
            _menu.Remove(menuItem);
            return true;
        }
    }
}
