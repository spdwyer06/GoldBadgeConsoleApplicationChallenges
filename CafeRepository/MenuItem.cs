using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem() { }
        public MenuItem(int number, string name, string description, List<string> ingredients, decimal price)
        {
            MealNumber = number;
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
