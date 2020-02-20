using System;
using System.Collections.Generic;
using System.Linq;
using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {

        [TestMethod]
        public void AddNewMenuItem_ShouldReturnTrue()
        {
            MenuItem item = new MenuItem();
            CafeRepo repo = new CafeRepo();

            bool wasAdded = repo.AddNewMenuItem(item);

            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void RemoveMenuItem_ShouldReturnTrue()
        {
            var item = new MenuItem();
            var repo = new CafeRepo();

            repo.AddNewMenuItem(item);
            bool wasRemoved = repo.RemoveMenuItem(item);

            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void GetAllMenuItems_ShouldReturnNotNull()
        {
            var repo = new CafeRepo();
            var item = new MenuItem();

            repo.AddNewMenuItem(item);
            List<MenuItem> getMenu = repo.GetAllMenuItems();

            Assert.IsNotNull(getMenu);

        }
        [TestMethod]
        public void GetMenuItemByName_ShouldReturnCorrectItem()
        {
            CafeRepo repo = new CafeRepo();
            MenuItem pizza = new MenuItem(1, "Pizza", "pizza", new List<string>(), 1.00m);

            repo.AddNewMenuItem(pizza);
            MenuItem searchResult = repo.GetMenuItemByName("Pizza");

            Assert.AreEqual(pizza, searchResult);
        }
    }
}
