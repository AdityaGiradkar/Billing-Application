using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Program
    {
        private static BillGeneration _bill = new BillGeneration();

        static int Main(string[] args)
        {
            Console.WriteLine(" Loading...\n Please wait.");
            List<Item> books = Categories.LoadBooks();
            List<Item> fruits = Categories.LoadFruits();
            List<Item> games = Categories.LoadGames();
            List<Item> movies = Categories.LoadMovies();
            List<Item> sports = Categories.LoadSports();

            List<string> categoryChoices = new List<string>()
                                        {
                                            "Books",
                                            "Fruits",
                                            "Games",
                                            "Movies",
                                            "Sports",
                                            "View Cart",
                                            "Generate Bill",
                                            "Exit Program"
                                        };

            int choice = 0;
            while (true)
            {
                printCategoryChoices(ref categoryChoices);

                Console.Write("\tEnter the Choice: ");
                if (!isInt(Console.ReadLine(), ref choice))
                {
                    continue;
                }
                
                
                switch (choice)
                {
                    case 1:
                        printSubCategoryChoices(ref books);
                        selectAndAddToCart(ref books, 2);
                        break;
                    case 2:
                        printSubCategoryChoices(ref fruits);
                        selectAndAddToCart(ref fruits, 3);
                        break;
                    case 3:
                        printSubCategoryChoices(ref games);
                        selectAndAddToCart(ref games, 4);
                        break;
                    case 4:
                        printSubCategoryChoices(ref movies);
                        selectAndAddToCart(ref movies, 1);
                        break;
                    case 5:
                        printSubCategoryChoices(ref sports);
                        selectAndAddToCart(ref sports, 5);
                        break;
                    case 6:
                        _bill.printCart();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\tPress Enter to continue.");
                        Console.ReadLine();
                        break;
                    case 7:
                        _bill.generateBill();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\tPress Enter to continue.");
                        Console.ReadLine();
                        break;
                    case 8:         //exit code
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\tInvalid Choice. Please Enter valid choice from above");
                        Console.WriteLine("\t\tPress Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }


        /// <summary>
        /// Check if input is able to convert into integer
        /// </summary>
        /// <param name="strNumber"> Input string </param>
        /// <param name="number"> refrence variable used to hold converted int from string </param>
        /// <returns> true - input string is succesfully converted to int else false </returns>
        private static bool isInt(string strNumber, ref int number)
        {
            if (!int.TryParse(strNumber, out number))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\tPlease enter a number.");
                Console.WriteLine("\t\tPress Enter to continue");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }


        /// <summary>
        /// Prints main category wich is present in main program
        /// </summary>
        /// <param name="categoryChoice"> refrence variable containing main categories </param>
        private static void printCategoryChoices(ref List<string> categoryChoice) 
        {
            Console.Clear();
            int serialNumber = 1;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("\t\t\tWelcome to the Grocery");
            Console.WriteLine("**********************************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var choice in categoryChoice)
            {
                Console.WriteLine(" {0}. {1, -20}", serialNumber++, choice);
            }

            Console.WriteLine("----------------------------------------------------------------------------------\n");
        }


        /// <summary>
        /// Prints all the items inside a perticular category
        /// </summary>
        /// <param name="subCategoryChoice"></param>
        private static void printSubCategoryChoices(ref List<Item> subCategoryChoice)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Sr. No.\t Item Name\t\t      Quantity\t Price(Per Item)");
            int serialNumber = 1;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in subCategoryChoice)
            {
                Console.WriteLine("   {0}.\t \t {1, -30}\t {2, -7}\t {3, -5}", serialNumber++, item.name, item.quantity, item.price);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   {0}.\t \t Return to Main Menu.", serialNumber++);
            Console.WriteLine("   {0}.\t \t Exit", serialNumber++);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------\n");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryItems"></param>
        /// <param name="worksheetNumber"></param>
        private static void selectAndAddToCart(ref List<Item> categoryItems, int worksheetNumber)
        {
            while (true)            //This loop will run until "Return to Main Menu" selected 
            {
                int selectedItem = -1;
                while (true)        //This loop will run until entered choice of item is valid.
                {
                    Console.Write("\tEnter item number you want to buy: ");

                    if(!isInt(Console.ReadLine(), ref selectedItem))        //check if entered string is number or not
                    {
                        printSubCategoryChoices(ref categoryItems);
                        continue;
                    }

                    if (selectedItem > categoryItems.Count + 2 || selectedItem <= 0)  //+2 because 2 extra choices can be made - 1.return 2.exit
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\t\tInvalid Choice, Please select valid item.");
                        Console.WriteLine("\t\tPress Enter to continue");
                        Console.ReadLine();
                        printSubCategoryChoices(ref categoryItems);
                    }
                    else
                    {
                        if (selectedItem == categoryItems.Count + 1)
                        {
                            return;         //return to main menu
                        }
                        else if (selectedItem == categoryItems.Count + 2)
                        {
                            System.Environment.Exit(0);     //End the program
                        }
                        break;
                    }
                }

                Item selectedItemDetails = categoryItems.ElementAt(selectedItem - 1);

                Console.Write("\tEnter the quantity you require: ");
                int quantityRequired = -1;

                if (!isInt(Console.ReadLine(), ref quantityRequired))
                {
                    printSubCategoryChoices(ref categoryItems);
                    continue;
                }


                if (selectedItemDetails.quantity >= quantityRequired && quantityRequired > 0)
                {

                    _bill.addItem(new Item(selectedItemDetails.name, selectedItemDetails.price, quantityRequired));

                    int newQuantity = selectedItemDetails.quantity - quantityRequired;

                    selectedItemDetails.updateQuantity(newQuantity);

                    //update in excel
                    updateInExcel(selectedItem + 1, 4, worksheetNumber, newQuantity);
                    
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\t\tItem is added to your Cart.");
                    Console.WriteLine("\t\tPress Enter to continue");
                    Console.ReadLine();


                    printSubCategoryChoices(ref categoryItems);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\t\tSorry the quantity you require is not available right now or it is invalid.");
                    Console.WriteLine("\t\tPress Enter to continue");
                    Console.ReadLine();
                    printSubCategoryChoices(ref categoryItems);
                }
            }
            
        }

        private static void updateInExcel(int row, int column, int worksheetNumber, int newQuantity)
        {
            Excel excel = new Excel(@"E:\Ubisoft\Courses\Projects\Billing Application\products.xlsx", worksheetNumber);
            excel.updateQuantityCell(row, column, newQuantity);
            excel.save();
            excel.close();
        }
    }
}
