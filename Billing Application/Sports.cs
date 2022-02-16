using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Sports
    {
        /// <summary>
        /// This function creats list of Sports using Item class
        /// </summary>
        /// <returns> returns list of Sport Item </returns>
        public static List<Item> LoadSports()
        {
            List<Item> sports = new List<Item>();

            sports.Add(new Item("Cricket",      2000, 10));
            sports.Add(new Item("Baseball",     3000, 10));
            sports.Add(new Item("Volleyball",   5000, 10));
            sports.Add(new Item("Basketball",   6100, 10));
            sports.Add(new Item("Football",     2999, 10));
            sports.Add(new Item("Table Tennis", 6500, 10));
            sports.Add(new Item("Archery",      4500, 10));
            sports.Add(new Item("Badminton",    5999, 10));
            sports.Add(new Item("Boxing",       1999, 10));
            sports.Add(new Item("Hockey",       5500, 10));

            return sports;
        }
    }
}
