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
            Console.WriteLine("Item is added to your Cart.");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }


        public void printCart()
        {
            if (!isCartEmpty())
            {
                int serialNumber = 1;

                Console.WriteLine("Sr. No.\t Item Name\t Quantity\t Price(Per Item)\t Total Price");
                foreach (var cartItem in _cart)
                {
                    Console.WriteLine("{0}.\t {1}\t {2}\t {3}\t {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                }
            }
            else
            {
                Console.WriteLine("Currently cart is empty. Please select some Item from the list.");
            }
            
        }


        public void generateBill()
        {
            if (!isCartEmpty())
            {
                int serialNumber = 1;
                double totalPrice = 0;

                Console.WriteLine("Sr. No.\t Item Name\t Quantity\t Price(Per Item)\t Total Price");
                foreach (var cartItem in _cart)
                {
                    Console.WriteLine("{0}.\t {1}\t {2}\t {3}\t {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                    totalPrice += cartItem.price * cartItem.quantity;
                }
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("Total Price \t\t\t\t\t\t {0}", totalPrice);
            }
            else
            {
                Console.WriteLine("Currently cart is empty. Please select some Item before generating bill.");
            }
        }

    }
}
