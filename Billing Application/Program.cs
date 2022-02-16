using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grocery");
            List<Item> books = Books.LoadBooks();
            List<Item> fruits = Fruits.LoadFruits();
            List<Item> games = Games.LoadGames();
            List<Item> movies = Movies.LoadMovies();
            List<Item> sports = Sports.LoadSports();


            List<string> category = new List<string>()
                                        {
                                            "Books",
                                            "Fruits",
                                            "Games",
                                            "Movies",
                                            "Sports"
                                        };

 

            //foreach (var book in books)
            //{
            //    Console.WriteLine("{0} book having price {1}. {2} copies available.", book.name, book.price, book.quantity);
            //}
            //Console.ReadLine();
        }
    }
}
