using MenuItemRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuItemTests
{
    [TestClass]
    public class CRUDTests
    {
        private readonly MenuItemRepo _repo = new MenuItemRepo();

        [TestInitialize]
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

        // CREATE Method Test
        [TestMethod]
        public void AddMenuItemsTest()
        {
            // ARRANGE
            MenuItem pancackes = new MenuItem(
                3,
                "Scott Jones' Millionaire Hotcakes",
                "Three Pancakes topped with blueberries and whipped cream. This comes with a side of hash browns and choice of crispy bacon or sausage patties.",
                "Pancackes, blueberries, whipped cream, hash browned potatoes, choice of bacon or sausage",
                11.99);

            // ACT
            bool wasAdded = _repo.AddMenuItem(pancackes);

            // ASSERT
            Assert.IsTrue(wasAdded);
        }

        // READ Method Test
        [TestMethod]
        public void GetMenuItemsTest()
        {
            // ARRANGE - seeded from test initialize

            // ACT
            List<MenuItem> all = _repo.GetMenuItems();

            // ASSERT
            Assert.AreEqual(2, all.Count);
        }

        // DELETE Method Test
        [TestMethod]
        public void RemoveMenuItemTest()
        {
            // ARRANGE - seeded from test initialize

            // ACT
            bool wasRemoved = _repo.RemoveMenuItem(1);

            // ASSERT
            Assert.IsTrue(wasRemoved);
        }
    }
}
