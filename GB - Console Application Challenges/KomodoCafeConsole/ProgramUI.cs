using MenuItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeConsole
{
    class ProgramUI
    {
        private MenuItemRepo _repo = new MenuItemRepo();
        public void Run()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("KOMODO CAFE MENU MANAGEMENT\n\n" +
                    "Select an option:\n\n" +
                    "1. Add item to menu\n" +
                    "2. Delete item from menu\n" +
                    "3. View menu\n" +
                    "0. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewMenu();
                        break;
                    case "0":
                        Console.WriteLine("Thank you for using Komodo Cafe Menu Management\n" +
                            "Copyright 2021\n" +
                            "Written by R Ross Denman II\n" +
                            "All Rights Reserved\n\n" +
                            "Press any key to exit");
                        Console.ReadKey();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please Press Any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void AddNewMenuItem()
        {
            Console.Clear();
            MenuItem newMenuItem = new MenuItem();

            Console.Write("Enter Meal Number:");
            newMenuItem.Number = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Meal Name:");
            newMenuItem.Name = Console.ReadLine();

            Console.Write("Enter Meal Description:");
            newMenuItem.Desc = Console.ReadLine();

            Console.Write("List All Meal Ingredients\n" +
                "Separate ingredients by \",'s\":");
            newMenuItem.Ingredients = Console.ReadLine();

            Console.Write("Enter Meal Price\n" +
                "No $ (i.e. 9.99, 10.50, 8, etc):");
            newMenuItem.Price = Convert.ToDouble(Console.ReadLine());

            _repo.AddMenuItem(newMenuItem);
        }

        public void ViewMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetMenuItems();

            foreach (MenuItem menuItem in fullMenu)
            {
                Console.WriteLine($"Number: {menuItem.Number}\n" +
                    $"Name: {menuItem.Name}\n" +
                    $"Description: {menuItem.Desc}\n" +
                    $"Ingredients: {menuItem.Ingredients}\n" +
                    $"Price: ${menuItem.Price}\n");
            }

        }

        public void DeleteMenuItem()
        {
            Console.Clear();
            ViewMenu();

            Console.WriteLine("Enter the Menu Number to remove from menu:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Please confirm deletion of Meal Number {number}\n" +
                $"YES / NO");
            string confirmation = Console.ReadLine();
            if (confirmation.ToUpper() == "YES")
            {
                bool wasDeleted = _repo.RemoveMenuItem(number);
                Console.WriteLine("This meal was successfully deleted.");                  
            }
            else
            {
                Console.WriteLine("Deletion Cancelled\n" +
                    "Press any key to continue...");
            }
        }
        public void Seed()
        {
            MenuItem breakfastSpecial = new MenuItem(
                1,
                "Uncle Seth's Veggie Omelet",
                "Three Farm Fresh Eggs folded over sauteed vegetables. This comes with a side of hash browns and 2 slices of toast.",
                "Three eggs, green peppers, diced onions, diced tomatoes, hash browned potatoes, choice of toast",
                10.99);
            MenuItem cornedBeefHash = new MenuItem(
                2,
                "Uncle Andrew's Corned Beef Hash",
                "Two Scrambled Eggs mixed with corned beef hash, sauteed vegetables, and roasted red potatoes. This comes with a choice of crispy bacon or sausage patties and 2 slices of toast.",
                "Two eggs, corned beef hash, green peppers, diced onions, diced tomatoes, roasted red potatoes, choice of bacon or sausage, choice of toast",
                12.99);
            _repo.AddMenuItem(breakfastSpecial);
            _repo.AddMenuItem(cornedBeefHash);
        }
    }
}
