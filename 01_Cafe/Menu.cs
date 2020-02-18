using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Cafe
{
    class Menu
    {
        //List<string> ingredients = new List<string>(); 
        List<MenuItem> menu = new List<MenuItem>();


        public void Run()
        {
            SeedMenu();
            MainMenu();
        }
        public void MainMenu()
        {
            Console.WriteLine("What would you like to do (1-3)?\n" +
                "[1] Create a new menu item\n" +
                "[2] Delete a menu item\n" +
                "[3] View all current menu items");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    CreateNewMenuItem();
                    break;
                case "2":
                    Console.Clear();
                    DeleteMenuItem();
                    break;
                case "3":
                    Console.Clear();
                    ViewAllMenuItems();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number (1-3).");
                    break;
            }
        }
        public void CreateNewMenuItem()
        {
            List<string> ingredients = new List<string>();

            Console.Write("Enter is the meal number: ");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the menu item name: ");
            string mealName = Console.ReadLine();
            Console.Write("Enter the description: ");
            string description = Console.ReadLine();
            Console.Write("Enter an ingredient: ");
            ingredients.Add(Console.ReadLine());
            Console.Write("Add another ingredient (y/n)?: ");
            string userInput = Console.ReadLine();
            while (userInput == "y")
            {
                Console.Write("Enter an ingredient: ");
                ingredients.Add(Console.ReadLine());
                Console.Write("Add another ingredient (y/n)?: ");
                userInput = Console.ReadLine();
            }
            Console.Write("Enter the price: ");
            // breaks if you don't enter decimal value
            decimal price = Convert.ToDecimal(Console.ReadLine());
            MenuItem newItem = new MenuItem(mealNumber, mealName, description, ingredients, price);
            menu.Add(newItem);

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        public void DeleteMenuItem()
        {
            Console.Write("Enter the menu item name you want to remove: ");
            string deleteItem = Console.ReadLine();
            MenuItem foundItem = GetMenuItemByName(deleteItem);
            menu.Remove(foundItem);
            // if item not found in menu display message


            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        public void ViewAllMenuItems()
        {
            foreach (MenuItem item in menu)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Item Name: {item.MealName}\n" +
                    $"Description: {item.Description}");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"Ingredients: {ingredient}");
                }
                Console.WriteLine($"Price: ${item.Price}");
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        /*
        public bool DeleteMenuItem (string itemName)
        {
            MenuItem foundItem = GetMenuItemByName(itemName);
            bool deletedResult = menu.Remove(foundItem);
            return deletedResult;
        }
        */
          public MenuItem GetMenuItemByName(string name)
        {
            foreach(MenuItem item in menu)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return item; 
                }
            }
            return null; 
        }
        
        public void SeedMenu()
        {
            List<string> doubleChzIngredients = new List<string>();
            doubleChzIngredients.Add("Sesame Seed Bun");
            doubleChzIngredients.Add("American Cheese");
            doubleChzIngredients.Add("Beef");
            doubleChzIngredients.Add("Salt");
            doubleChzIngredients.Add("Black Pepper");
            doubleChzIngredients.Add("Ketchup");
            doubleChzIngredients.Add("Mustard");
            doubleChzIngredients.Add("Onion");
            doubleChzIngredients.Add("Pickle");

            MenuItem doubleCheeseburger = new MenuItem(1, "Double Cheeseburger", "Two juicy burger patties with two slices of cheese, topped with ketchup, mustard, onion, and pickles", doubleChzIngredients, 4.99m);
            menu.Add(doubleCheeseburger);

            List<string> beefNCheddarIngredients = new List<string>();
            beefNCheddarIngredients.Add("Sesame Seed Bun");
            beefNCheddarIngredients.Add("Roast Beef");
            beefNCheddarIngredients.Add("Cheddar Cheese Sauce");
            beefNCheddarIngredients.Add("Red Ranch Sauce");

            MenuItem beefNCheddar = new MenuItem(2, "Beef N Cheddar", "Thinly sliced roasted beef covered in delicious cheese sauce and red ranch", beefNCheddarIngredients, 5.50m);
            menu.Add(beefNCheddar);

            List<string> buffaloChickenIngredients = new List<string>();
            buffaloChickenIngredients.Add("Brioche Bun");
            buffaloChickenIngredients.Add("Chicken Breast");
            buffaloChickenIngredients.Add("Buffalo Sauce");
            buffaloChickenIngredients.Add("Ranch");

            MenuItem buffaloChicken = new MenuItem(3, "Buffalo Chicken", "Crispy chicken breast tossed in a spicy buffalo sauce and topped with a creamy ranch", buffaloChickenIngredients, 5.25m);
            menu.Add(buffaloChicken);
        }
    }
}
