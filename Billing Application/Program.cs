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

            int choice;
            while (true)
            {
                printCategoryChoices(ref categoryChoices);

                Console.Write("Enter the Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                
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
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;
                    case 7:
                        _bill.generateBill();
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;
                    case 8:         //exit code
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice. Please Enter valid choice from above");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }

            

        }

        private static void printCategoryChoices(ref List<string> categoryChoice) 
        {
            Console.Clear();
            int serialNumber = 1;
            foreach(var choice in categoryChoice)
            {
                Console.WriteLine("{0}.\t {1}", serialNumber++, choice);
            }
        }

        private static void printSubCategoryChoices(ref List<Item> subCategoryChoice)
        {
            Console.Clear();
            Console.WriteLine("Sr. No.\t Item Name\t Quantity\t Price(Per Item)");
            int serialNumber = 1;
            foreach (var item in subCategoryChoice)
            {
                Console.WriteLine("{0}.\t {1}\t {2}\t {3}", serialNumber++, item.name, item.quantity, item.price);
            }
            
            Console.WriteLine("{0}.\t Return to Main Menu.", serialNumber++);
            Console.WriteLine("{0}.\t Exit", serialNumber++);
        }

        private static void selectAndAddToCart(ref List<Item> categoryItems)
        {
            while (true)            //this will loop will run untill selected to go back to main menu 
            {
                int selectedItem;
                while (true)        //This will loop will run until entered choice of item is valid.
                {
                    Console.Write("Enter item number you want to buy: ");
                    selectedItem = Convert.ToInt32(Console.ReadLine());

                    if (selectedItem > categoryItems.Count + 2 || selectedItem <= 0)  //+2 because 2 extra choices can be made - 1.return 2.exit
                    {
                        Console.WriteLine("Invalid Choice, Please select valid item.");
                        Console.WriteLine("Press Enter to continue");
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

                Console.Write("Enter the quantity you require: ");
                int quantityRequired = Convert.ToInt32(Console.ReadLine());


                if (selectedItemDetails.quantity >= quantityRequired)
                {
                    _bill.addItem(new Item(selectedItemDetails.name, selectedItemDetails.price, quantityRequired));

                    selectedItemDetails.updateQuantity(selectedItemDetails.quantity - quantityRequired);
                    printSubCategoryChoices(ref categoryItems);
                }
                else
                {
                    Console.WriteLine("Sorry the quantity you require is not available right now.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    printSubCategoryChoices(ref categoryItems);
                }
            }
            
        }
    }
}
