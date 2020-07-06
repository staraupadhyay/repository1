using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assignment.src.model;
namespace Assignment.src.service
{
    // Class for mapping Promo offer and price
    public class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, int> ProductInfo { get; set; }
        public decimal PromoPrice { get; set; }

        public Promotion(int _promID, Dictionary<string, int> _prodInfo, decimal _pp)
        {
            this.PromotionID = _promID;
            this.ProductInfo = _prodInfo;
            this.PromoPrice = _pp;
        }
    }

    // store the list of order
    public class Order
    {
        public int OrderID { get; set; }
        public List<Product> Products { get; set; }

        public Order(int _oid, List<Product> _prods)
        {
            this.OrderID = _oid;
            this.Products = _prods;
        }
    }

    public static class GetPromoPrice
    {
        //returns PromotionID and count of promotions
        public static decimal GetTotalPrice(Order ord, Promotion prom)
        {
            decimal promoPrice = 0M;

            //get count of promoted products in order
            var promotProductCount = ord.Products
                .GroupBy(x => x.Id)
                .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();

            //get count of promoted products from promotion
            int ppc = prom.ProductInfo.Sum(kvp => kvp.Value);


            // not promo offer for this product get orignial price

            if(promotProductCount == 0)
            {
                string key = prom.ProductInfo.Keys.ElementAt(0);
                foreach (Product pr in ord.Products)
                {
                    if (key.Equals(pr.Id))
                    {
                        promoPrice += pr.Price;
                        break;
                    }

                }
            }
            // get the promo produce price based on the product count
            while (promotProductCount >= ppc)
            {
                promoPrice += prom.PromoPrice;
                promotProductCount -= ppc;
            }
            // calculate for pending product cound price
            if(promotProductCount > 0)
            {
                string key1 =  prom.ProductInfo.Keys.ElementAt(0);
                foreach(Product pr in ord.Products)
                {
                    if (key1.Equals(pr.Id))
                    {
                        promoPrice += pr.Price * promotProductCount;
                        break;
                    }
                }
            }
            return promoPrice;
        }
    }
}
