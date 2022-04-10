using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Product
    {
        private double price;
        public void SetPrice(double value)
        {
            if (value > 0)
            {
                price = value;
            }
            else
            {
                throw new ArgumentException("Fiyat, negatif olamaz");
            }

        }
        public double GetPrice()
        {
            return price;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int stock;
        public int StockCount
        {
            get
            {
                return stock;
            }
            set
            {
                if (value <= 0)
                {
                    stock = 0;
                    IsProductFoundInStock = false;
                }
            }
        }

        public bool IsProductFoundInStock { get; private set; }
        public double Discount { get; set; }
        public string Description { get; set; }

    }
}
