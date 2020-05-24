using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.Entities;
using System.Data.Entity;

namespace EURIS.Service
{
    public class ProductManager
    {
        LocalDbEntities context = new LocalDbEntities(); 

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            
            products = (from item in context.Product
                        select item).ToList();

            return products;
        }

        public List<Product> GetRemainingProducts(Catalog catalog)
        {
            List<Product> products = new List<Product>();

            products = (from item in context.Product
                        select item).ToList();


            List<Product> remainingProducts = (from a in products
                                               join b in catalog.Product on a.Code equals b.Code into subset
                                               from c in subset.DefaultIfEmpty()
                                               where (c == null)
                                               select a).ToList();
            return remainingProducts;
        }
    }
}
