using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.src.model;

namespace Assignment.src.service
{
   public  class ProductPromotionTest
    {


      public   ProductPromotionTest()
        {
            Dictionary<String, int> d1 = new Dictionary<String, int>();

            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, d1, 130),
                new Promotion(2, d2, 45),
                new Promotion(3, d3, 30)
            };
            //create orders
            List<Order> orders = new List<Order>();
    
            // Test case1
            Order order1 = new Order(1, new List<Product>() {
                new Product("A"),
                 new Product("B"),
                new Product("C") });

          //  testc case2
            Order order2 = new Order(2, new List<Product>() {
                    new Product("A"),
                    new Product("A"),
                    new Product("A"),
                    new Product("A"),
                    new Product("A"),
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),
                    new Product("C") });


            // Test case 3
            Order order3 = new Order(2, new List<Product>() {
                    new Product("A"),
                    new Product("A"),
                    new Product("A"),
                  
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),
                    new Product("B"),

                    new Product("C"),
                    new Product("D")
            });

            orders.AddRange(new Order[] { order1, order2, order3});
            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => GetPromoPrice.GetTotalPrice(ord, promo))
                    .ToList();
                decimal promoprice = promoprices.Sum();
                Console.WriteLine($"After discount final price: {promoprice.ToString("0.00")}");

            }
        }

    }
}
