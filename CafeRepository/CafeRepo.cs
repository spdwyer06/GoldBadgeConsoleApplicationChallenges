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
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menu = new List<MenuItem>();

            foreach(MenuItem item in _menu)
            {
                menu.Add(item);
            }
            return menu; 
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
