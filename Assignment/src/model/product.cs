using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.src.model
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public Product(string productId)
        {

            this.Id = productId;
            SetPriceByProductId(productId);
        }

        private void SetPriceByProductId(string productId)
        {

            switch (this.Id.ToUpper())
            {
                case "A":
                    this.Price = 50;

                    break;
                case "B":
                    this.Price = 30;

                    break;
                case "C":
                    this.Price = 20;

                    break;
                case "D":
                    this.Price = 15;
                    break;

            }
        }
    }
}
