using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Books
    {
        /// <summary>
        /// This function creats list of Books using Item class
        /// </summary>
        /// <returns> returns list of Book Item </returns>
        public static List<Item> LoadBooks()
        {
            List<Item> books = new List<Item>();

            books.Add(new Item("To Paradise",            100, 10));
            books.Add(new Item("Sherlock Holmes",        75,  10));
            books.Add(new Item("In Search of Lost Time", 150, 10));
            books.Add(new Item("Heart of Darkness",      200, 10));
            books.Add(new Item("Invisible Man",          50,  10));
            books.Add(new Item("The Trial",              200, 10));
            books.Add(new Item("The Red and the Black",  150, 10));
            books.Add(new Item("Gulliver's Travels ",    500, 10));
            books.Add(new Item("The Stranger",           500, 10));
            books.Add(new Item("Leaves of Grass ",       250, 10));

            return books;
        }
    }
}
