using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_Application
{
    class Item
    {
        //Private data Members
        private string _name;
        private double _price;
        private int _quantity;

        //public properties
        public string name { get { return _name; } }
        public double price { get { return _price; } }
        public int quantity { get { return _quantity; } }


        //public methods

        /// <summary>
        /// It is constructor to creat single item
        /// </summary>
        /// <param name="Name"> Stores Name of Product </param>
        /// <param name="Price"> Stores Price of single unit in INR </param>
        /// <param name="Quantity"> Stores quantity of Item </param>
        public Item(string Name, double Price, int Quantity)
        {
            _name = Name;
            _price = Price;
            _quantity = Quantity;
        }

        public void updateQuantity(int newQuantity)
        {
            _quantity = newQuantity;
        }
    }
}
