using System;
using System.Collections.Generic;
using System.IO;
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
                double priceAfterDiscount = 0;
                List<string> lines = new List<string>();
                string item = "";
                //StreamWriter File = new StreamWriter("Bill.txt");

                //Console.WriteLine("\n");
                //Console.WriteLine("----------------------------------------------------------------------------------");
                //Console.WriteLine("----------------------------------------------------------------------------------");
                //Console.WriteLine(" Sr. No.\t Item Name\t\t      Quantity\t Price(Per Item)   Total Price");
                //Console.WriteLine("----------------------------------------------------------------------------------");

                lines.Add(" Sr. No.\t Item Name\t\t\t      Quantity\t Price(Per Item)   Total Price");
                lines.Add("----------------------------------------------------------------------------------");
                foreach (var cartItem in _cart)
                {
                    //Console.WriteLine("   {0}.\t \t {1, -30}\t {2, -7}\t {3, -5}        {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                    item = string.Format("   {0}.\t \t {1, -25}\t {2, -7}\t {3, -5}        {4}", serialNumber++, cartItem.name, cartItem.quantity, cartItem.price, cartItem.quantity * cartItem.price);
                    //lines.Add($"   {serialNumber++}.\t \t {cartItem.name}\t {cartItem.quantity} \t{cartItem.price}\t {cartItem.quantity * cartItem.price}");
                    lines.Add(item);
                    totalPrice += cartItem.price * cartItem.quantity;
                    
                }
                //Console.WriteLine("----------------------------------------------------------------------------------");
                //Console.WriteLine("\t\t \t\t\t\t\t\t\t  Rs. {0}", totalPrice);
                lines.Add("----------------------------------------------------------------------------------");
                lines.Add($"\t\t \t\t\t\t\t\t\t\t   Rs. {totalPrice}");
                //Console.WriteLine("\n");

                Excel excel = new Excel(@"E:\Ubisoft\Courses\Projects\Billing Application\products.xlsx", 6);
                double discount = Convert.ToDouble(excel.ReadCell(1, 2));
                excel.close();
                priceAfterDiscount = totalPrice - (discount / 100) * totalPrice;

                //Console.WriteLine("\tDiscount \t\t\t\t\t\t\t       -{0}%", discount);
                //Console.WriteLine("----------------------------------------------------------------------------------");
                //Console.WriteLine("\tTotal Price \t\t\t\t\t\t\t  Rs. {0}", priceAfterDiscount);
                lines.Add($"\tDiscount \t\t\t\t\t\t\t\t       -{discount}%");
                lines.Add("----------------------------------------------------------------------------------");
                lines.Add($"\tTotal Price \t\t\t\t\t\t\t\t  Rs. {priceAfterDiscount}");
                writeFileAsync(lines);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t\tbill Generated");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\t\tCurrently cart is empty. Please select some Item before generating bill.");
            }
        }

        private void writeFileAsync(List<string> lines)
        {
            File.WriteAllLines("bill.txt", lines);  
            
        }

    }
}
