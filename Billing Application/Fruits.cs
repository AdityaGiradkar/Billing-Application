using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Fruits
    {
        /// <summary>
        /// This function creats list of fruits using Item class
        /// </summary>
        /// <returns> returns list of Fruit Item </returns>
        public static List<Item> LoadFruits()
        {
            List<Item> fruits = new List<Item>();

            fruits.Add(new Item("Banana",       50,  10));
            fruits.Add(new Item("Mango",        100, 10));
            fruits.Add(new Item("Apple",        120, 10));
            fruits.Add(new Item("Orange",       80,  10));
            fruits.Add(new Item("Gava",         40,  10));
            fruits.Add(new Item("Lemon",        60,  10));
            fruits.Add(new Item("Dragon Fruit", 150, 10));
            fruits.Add(new Item("Kivi",         200, 10));
            fruits.Add(new Item("Pine Apple",   30,  10));
            fruits.Add(new Item("Grapes",       50,  10));

            return fruits;
        }
    }
}
