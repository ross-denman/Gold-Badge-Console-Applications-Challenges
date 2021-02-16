using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuTests
{
    [TestClass]
    public class UnitTCRUDTests
    {
        private MenuRepo _repo = new MenuRepo();
        private MenuItem breakfastSpecial;

        [TestInitialize]
        public void Seed()
        {
            breakfastSpecial = new MenuItem(1, "Breakfast Special", "Two Farm Fresh Eggs cooked to order with side of bacon or sausage patty and two slices of bread option.", "2 Eggs, bacon or sausage patty, 2 slices of bread", 7.95m);
        }
        // TEST AddMenuItem
        [TestMethod]
        public void AddMenuItemTest()
        {
            // ARRANGE
            MenuItem newMenuItem = new MenuItem(2, "Uncle Andrew's Corned Beef Hash Skillet", "Three Scrambled Eggs with corned beef, grilled veggies, roasted potatoes, and shredded cheese. Choose from side of bacon or sausage and 2 slices of bread.", "Three Eggs, Corned Beef Hash, Bell Peppers, Diced Onions, Diced Tomatoes, Roasted Red Potatoes, Bacon or Sausage, Choice of Bread", 11.99m);

            // ACT
            bool wasAdded = _repo.AddMenuItem(newMenuItem);

            // ASSERT
            Assert.IsTrue(wasAdded);
        }

        // TEST GetAllMenuItems
        [TestMethod]
        public void GetAllMenuItemsTest()
        {
            // ARRANGE
            AddMenuItemTest();

            // ACT
            List<MenuItem> Menu = _repo.GetAllMenuItems();

            // Assert
            foreach (MenuItem menuItem in Menu)
            {
            Console.WriteLine(menuItem.Name);
            }
            Assert.AreEqual(Menu.Count, 1);
        }

        // TEST RemoveMenuItemByName
        [TestMethod]
        public void RemoveMenuItemByNameTest()
        {
            // ARRANGE
            AddMenuItemTest();

            // ACT
            bool wasRemoved = _repo.RemoveMenuItemByName("Uncle Andrew's Corned Beef Hash Skillet");

            // ASSERT
            Assert.IsTrue(wasRemoved);
        }

        // TEST RemoveMenuItemByNumber
        [TestMethod]
        public void RemoveMenuItemByNumber()
        {
            // ARRANGE
            AddMenuItemTest();

            // ACT
            bool wasRemoved = _repo.RemoveMenuItemByNumber(2);

            // ASSERT
            Assert.IsTrue(wasRemoved);
        }        
    }
}
