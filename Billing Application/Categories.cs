using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Categories
    {
        /// <summary>
        /// This function creats list of movie using Item class
        /// </summary>
        /// <returns> returns list of movie Item </returns>
        public static List<Item> LoadMovies()
        {
            List<Item> movies = new List<Item>();

            movies.Add(new Item("Captian America", 100, 10));
            movies.Add(new Item("Spider Man", 75, 10));
            movies.Add(new Item("Dr. Strange", 150, 10));
            movies.Add(new Item("Iron Man", 200, 10));
            movies.Add(new Item("Bat Man", 50, 10));
            movies.Add(new Item("Avengers", 200, 10));
            movies.Add(new Item("Baby Boss", 150, 10));
            movies.Add(new Item("One Piece", 500, 10));
            movies.Add(new Item("Naruto", 500, 10));
            movies.Add(new Item("Avengers 2", 250, 10));

            return movies;
        }

        /// <summary>
        /// This function creats list of Books using Item class
        /// </summary>
        /// <returns> returns list of Book Item </returns>
        public static List<Item> LoadBooks()
        {
            List<Item> books = new List<Item>();

            books.Add(new Item("To Paradise", 100, 10));
            books.Add(new Item("Sherlock Holmes", 75, 10));
            books.Add(new Item("In Search of Lost Time", 150, 10));
            books.Add(new Item("Heart of Darkness", 200, 10));
            books.Add(new Item("Invisible Man", 50, 10));
            books.Add(new Item("The Trial", 200, 10));
            books.Add(new Item("The Red and the Black", 150, 10));
            books.Add(new Item("Gulliver's Travels ", 500, 10));
            books.Add(new Item("The Stranger", 500, 10));
            books.Add(new Item("Leaves of Grass ", 250, 10));

            return books;
        }

        /// <summary>
        /// This function creats list of fruits using Item class
        /// </summary>
        /// <returns> returns list of Fruit Item </returns>
        public static List<Item> LoadFruits()
        {
            List<Item> fruits = new List<Item>();

            fruits.Add(new Item("Banana", 50, 10));
            fruits.Add(new Item("Mango", 100, 10));
            fruits.Add(new Item("Apple", 120, 10));
            fruits.Add(new Item("Orange", 80, 10));
            fruits.Add(new Item("Gava", 40, 10));
            fruits.Add(new Item("Lemon", 60, 10));
            fruits.Add(new Item("Dragon Fruit", 150, 10));
            fruits.Add(new Item("Kivi", 200, 10));
            fruits.Add(new Item("Pine Apple", 30, 10));
            fruits.Add(new Item("Grapes", 50, 10));

            return fruits;
        }

        /// <summary>
        /// This function creats list of Games using Item class
        /// </summary>
        /// <returns> returns list of Game Item </returns>
        public static List<Item> LoadGames()
        {
            List<Item> games = new List<Item>();

            games.Add(new Item("Far Cry 6", 5000, 10));
            games.Add(new Item("The Crew 2", 2000, 10));
            games.Add(new Item("Watch Dogs: Legion", 3000, 10));
            games.Add(new Item("Assassin's Creed Valhalla", 6000, 10));
            games.Add(new Item("Just Dance 2021", 2500, 10));
            games.Add(new Item("Monopoly Madness", 1500, 10));
            games.Add(new Item("Assassin's Creed", 1000, 10));
            games.Add(new Item("Prince of Persia", 2000, 10));
            games.Add(new Item("Rainbow Six", 5500, 10));
            games.Add(new Item("Rayman Legends", 2000, 10));

            return games;
        }

        /// <summary>
        /// This function creats list of Sports using Item class
        /// </summary>
        /// <returns> returns list of Sport Item </returns>
        public static List<Item> LoadSports()
        {
            List<Item> sports = new List<Item>();

            sports.Add(new Item("Cricket", 2000, 10));
            sports.Add(new Item("Baseball", 3000, 10));
            sports.Add(new Item("Volleyball", 5000, 10));
            sports.Add(new Item("Basketball", 6100, 10));
            sports.Add(new Item("Football", 2999, 10));
            sports.Add(new Item("Table Tennis", 6500, 10));
            sports.Add(new Item("Archery", 4500, 10));
            sports.Add(new Item("Badminton", 5999, 10));
            sports.Add(new Item("Boxing", 1999, 10));
            sports.Add(new Item("Hockey", 5500, 10));

            return sports;
        }
    }
}
