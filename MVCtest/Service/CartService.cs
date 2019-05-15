using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;

namespace MVCtest.Service
{
    public class CartService
    {
       private DBModel db = new DBModel();
       private List<Product> products;

        public List<Product> GetProducts(int? productID)
        {
            if(productID ==null)
            {
                products = null;
            }
            else
            {
                products = db.Products.Where(x => x.Product_Id == productID).ToList();
            }
            return products;
        }
    }
}