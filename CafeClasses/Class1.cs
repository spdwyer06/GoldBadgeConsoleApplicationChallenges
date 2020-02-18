using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClasses
{
    public class Class1
    {
        public void Run()
        {
            MainMenu();
        }
        public void MainMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "[1] Create a new menu item\n" +
                "[2] Delete a menu item\n" +
                "[3] View all current menu items");

        }
    }
}
