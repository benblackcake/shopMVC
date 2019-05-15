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
       private Product products;
       private Cart carts;
       private List<Cart> listcart;


        public void SaveCartDB(string productName,int quantity)
        {
            if(productName ==null)
            {
                carts = null;
            }
            else
            {
                products = db.Products.Where(x => x.Product_Name == productName).FirstOrDefault();
                carts = new Cart()
                {
                    Product_ID = products.Product_Id,
                    Customer = products.Customer,
                    Quantity = quantity
                };
                db.Carts.Add(carts);
                db.SaveChanges();
            }
        }
        public List<Cart> GetListCart()
        {
            listcart = db.Carts.ToList();
            return listcart;
        }
    }
}