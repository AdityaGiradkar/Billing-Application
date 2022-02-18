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

            loadFromExcel(1, ref movies);

            return movies;
        }

        /// <summary>
        /// This function creats list of Books using Item class
        /// </summary>
        /// <returns> returns list of Book Item </returns>
        public static List<Item> LoadBooks()
        {
            List<Item> books = new List<Item>();
            
            loadFromExcel(2, ref books);

            return books;
        }

        /// <summary>
        /// This function creats list of fruits using Item class
        /// </summary>
        /// <returns> returns list of Fruit Item </returns>
        public static List<Item> LoadFruits()
        {
            List<Item> fruits = new List<Item>();
            
            loadFromExcel(3, ref fruits);

            return fruits;
        }

        /// <summary>
        /// This function creats list of Games using Item class
        /// </summary>
        /// <returns> returns list of Game Item </returns>
        public static List<Item> LoadGames()
        {
            List<Item> games = new List<Item>();

            loadFromExcel(4, ref games);

            return games;
        }

        /// <summary>
        /// This function creats list of Sports using Item class
        /// </summary>
        /// <returns> returns list of Sport Item </returns>
        public static List<Item> LoadSports()
        {
            List<Item> sports = new List<Item>();

            loadFromExcel(5, ref sports);

            return sports;
        }

        /// <summary>
        /// helper function used to loads data from excel wooksheet into refrence variable
        /// </summary>
        /// <param name="worksheetNumber"> woorksheet number starts with 1 (it specifies from which worksheet we have to read)</param>
        /// <param name="category">It is refrencce variable from the calling function</param>
        private static void loadFromExcel(int worksheetNumber, ref List<Item> category)
        {
            Excel excel = new Excel(@"E:\Ubisoft\Courses\Projects\Billing Application\products.xlsx", worksheetNumber);
            
            int totalColumns = excel.actualColumn;
            int totalRows = excel.actualRow;

            string name;
            double price;
            int quantity;
            for (int i = 2; i <= totalRows; i++)
            {
                name = excel.ReadCell(i, 2);
                price = Convert.ToDouble(excel.ReadCell(i, 3));
                quantity = Convert.ToInt32(excel.ReadCell(i, 4));

                category.Add(new Item(name, price, quantity));
            }

            excel.close();
        }
    }
}
