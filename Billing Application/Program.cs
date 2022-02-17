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
            Console.WriteLine("Welcome to the Grocery");
            List<Item> books = Books.LoadBooks();
            List<Item> fruits = Fruits.LoadFruits();
            List<Item> games = Games.LoadGames();
            List<Item> movies = Movies.LoadMovies();
            List<Item> sports = Sports.LoadSports();


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
                        selectAndAddToCart(ref books);
                        break;
                    case 2:
                        printSubCategoryChoices(ref fruits);
                        selectAndAddToCart(ref fruits);
                        break;
                    case 3:
                        printSubCategoryChoices(ref games);
                        selectAndAddToCart(ref games);
                        break;
                    case 4:
                        printSubCategoryChoices(ref movies);
                        selectAndAddToCart(ref movies);
                        break;
                    case 5:
                        printSubCategoryChoices(ref sports);
                        selectAndAddToCart(ref sports);
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


        private static void selectAndAddToCart(ref List<Item> categoryItems)
        {
            while (true)            //this will loop will run untill selected to go back to main menu 
            {
                int selectedItem = -1;
                while (true)        //This will loop will run until entered choice of item is valid.
                {
                    Console.Write("\tEnter item number you want to buy: ");

                    if(!isInt(Console.ReadLine(), ref selectedItem))
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

                    selectedItemDetails.updateQuantity(selectedItemDetails.quantity - quantityRequired);
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
    }
}
