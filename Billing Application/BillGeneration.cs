using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class BillGeneration
    {
        private List<Item> _cart;

        private bool isCartEmpty()
        {
            return (_cart.Count == 0);
        }

        public BillGeneration()
        {
            _cart = new List<Item>();
        }


        public void addItem(Item selectedItem)
        {
            _cart.Add(selectedItem);
        }


        public void printCart()
        {
            if (!isCartEmpty())
            {
                int serialNumber = 1;
                Console.WriteLine("\n");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine(" Sr. No.\t Item Name\t\t      Quantity\t Price(Per Item)   Total Price");
                Console.WriteLine("----------------------------------------------------------------------------------");
                foreach (var cartItem in _cart)
                {
                    Console.WriteLine("   {0}.\t \t {1, -30}\t {2, -7}\t {3, -5}        {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\tCurrently cart is empty. Please select some Item from the list.");
            }
            
        }


        public void generateBill()
        {
            if (!isCartEmpty())
            {
                int serialNumber = 1;
                double totalPrice = 0;

                Console.WriteLine("\n");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine(" Sr. No.\t Item Name\t\t      Quantity\t Price(Per Item)   Total Price");
                Console.WriteLine("----------------------------------------------------------------------------------");
                foreach (var cartItem in _cart)
                {
                    Console.WriteLine("   {0}.\t \t {1, -30}\t {2, -7}\t {3, -5}        {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                    totalPrice += cartItem.price * cartItem.quantity;
                }
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("\tTotal Price \t\t\t\t\t\t\t  Rs. {0}", totalPrice);
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\tCurrently cart is empty. Please select some Item before generating bill.");
            }
        }

    }
}
