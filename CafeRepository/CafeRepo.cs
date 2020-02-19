using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class CafeRepo
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();

       public bool AddNewMenuItem(MenuItem item)
        {
            int menuLength = _menu.Count();
            _menu.Add(item);
            bool wasAdded = menuLength + 1 == _menu.Count();
            return wasAdded;
        }
        public bool RemoveMenuItem(MenuItem item)
        {
            int menuLength = _menu.Count();
            _menu.Remove(item);
            bool wasRemoved = menuLength - 1 == _menu.Count();
            return wasRemoved;
        }
        public void DisplayAllMenuItems()
        {
            foreach (MenuItem item in _menu)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Item Name: {item.MealName}\n" +
                    $"Description: {item.Description}");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"Ingredients: {ingredient}");
                }
                Console.WriteLine($"Price: ${item.Price}\n" +
                    $"");
            }
        }
        public MenuItem GetMenuItemByName(string name)
        {
            foreach (MenuItem item in _menu)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
