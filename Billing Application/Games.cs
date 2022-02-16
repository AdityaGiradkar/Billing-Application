using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Games
    {
        /// <summary>
        /// This function creats list of Games using Item class
        /// </summary>
        /// <returns> returns list of Game Item </returns>
        public static List<Item> LoadGames()
        {
            List<Item> games = new List<Item>();

            games.Add(new Item("Far Cry 6",                 5000, 10));
            games.Add(new Item("The Crew 2",                2000, 10));
            games.Add(new Item("Watch Dogs: Legion",        3000, 10));
            games.Add(new Item("Assassin's Creed Valhalla", 6000, 10));
            games.Add(new Item("Just Dance 2021",           2500, 10));
            games.Add(new Item("Monopoly Madness",          1500, 10));
            games.Add(new Item("Assassin's Creed",          1000, 10));
            games.Add(new Item("Prince of Persia",          2000, 10));
            games.Add(new Item("Rainbow Six",               5500, 10));
            games.Add(new Item("Rayman Legends",            2000, 10));

            return games;
        }
    }
}
