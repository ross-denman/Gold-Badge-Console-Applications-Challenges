using CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuConsole
{
    class ProgramUI
    {
        private readonly MenuRepo _repo = new MenuRepo();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            SeedMenu();
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\tKOMODO CAFE\n\n" +
                    "Select an option below:\n" +
                    "1. Add New Menu Item\n" +
                    "2. View Entire Menu\n" +
                    "3. Delete Menu Item\n" +
                    "0. EXIT\n\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "0":
                        Console.WriteLine("Thank You for using Komodo Cafe Menu Control\n" +
                            "Copyright 2021\n" +
                            "Created by R. Ross Denman\n" +
                            "Press Any Key to Exit");
                        Console.ReadKey();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }
        public void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.WriteLine("Enter Meal Number:");
            int number = Convert.ToInt32(Console.ReadLine());
            newMenuItem.Number = number;

            Console.WriteLine("Enter Meal Name:");
            newMenuItem.Name = Console.ReadLine();

            Console.WriteLine("Enter Meal Description:");
            newMenuItem.Desc = Console.ReadLine();

            Console.WriteLine("Enter Meal Ingredients:\n" +
                "(Seperate ingredients by commas)");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter Meal Price:\n" +
                "(as numbers without $ i.e. 9.99, 8.00");
            newMenuItem.Price = Convert.ToDecimal(Console.ReadLine());

            _repo.AddMenuItem(newMenuItem);
        }
        public void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> entireMenu = _repo.GetAllMenuItems();
            foreach (MenuItem menuItem in entireMenu)
            {
                Console.WriteLine($"Number: {menuItem.Number}\n" +
                $"Name: {menuItem.Name}\n" +
                $"Description: {menuItem.Desc}\n" +
                $"Ingredients: {menuItem.Ingredients}\n" +
                $"Price: ${menuItem.Price}\n\n");
            }
            Console.WriteLine("Press any key to Continue...");
            Console.ReadKey();
        }
        public void DeleteMenuItem()
        {
            Console.Clear();
            ViewMenu();

            Console.Write("Enter the Number of the item to remove from the menu:");
            int deleteNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Confirm\n" +
                $" Delete Item Number {deleteNumber}\n" +
                $"YES / NO");
            string confirmation = Console.ReadLine();
            if(confirmation.ToUpper() == "YES")
            {
                _repo.RemoveMenuItemByNumber(deleteNumber);
                Console.WriteLine("This Meal was successfully deleted.");
                Console.ReadKey();
            }
            
        }
        private void SeedMenu()
        {
            MenuItem breakfastSpecial = new MenuItem(1, "Breakfast Special", "Two Farm Fresh Eggs cooked to order with side of bacon or sausage patty and two slices of bread option.", "2 Eggs, bacon or sausage patty, 2 slices of bread", 7.95m);
            MenuItem cornedBeefHashSkillet = new MenuItem(2, "Uncle Andrew's Corned Beef Hash Skillet", "Three Scrambled Eggs with corned beef, grilled veggies, roasted potatoes, and shredded cheese. Choose from side of bacon or sausage and 2 slices of bread.", "Three Eggs, Corned Beef Hash, Bell Peppers, Diced Onions, Diced Tomatoes, Roasted Red Potatoes, Bacon or Sausage, Choice of Bread", 11.99m);
            _repo.AddMenuItem(breakfastSpecial);
            _repo.AddMenuItem(cornedBeefHashSkillet);
        }
    }
}
