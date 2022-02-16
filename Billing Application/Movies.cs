using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Movies
    {
        /// <summary>
        /// This function creats list of movie using Item class
        /// </summary>
        /// <returns> returns list of movie Item </returns>
        public static List<Item> LoadMovies()
        {
            List<Item> movies = new List<Item>();

            movies.Add(new Item("Captian America", 100, 10));
            movies.Add(new Item("Spider Man",      75,  10));
            movies.Add(new Item("Dr. Strange",     150, 10));
            movies.Add(new Item("Iron Man",        200, 10));
            movies.Add(new Item("Bat Man",         50,  10));
            movies.Add(new Item("Avengers",        200, 10));
            movies.Add(new Item("Baby Boss",       150, 10));
            movies.Add(new Item("One Piece",       500, 10));
            movies.Add(new Item("Naruto",          500, 10));
            movies.Add(new Item("Avengers 2",      250, 10));

            return movies;
        }
    }
}
