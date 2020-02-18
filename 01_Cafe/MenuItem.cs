﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Cafe
{
    class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price {get; set;}

        public MenuItem() { }
        public MenuItem(int number, string name, string description, List<string> ingredients, decimal price)
        {
            MealNumber = number;
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price; 
        }

        //List<string> ingredients = new List<string>();
    }
}
