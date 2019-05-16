using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;

namespace MVCtest.Service
{
    public class CartService
    {
       private DBModel db = new DBModel();
       private Product products;
       private Cart carts;

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
        public List<CartViewModel> GetListCart(int customerID)
        {
            List<CartViewModel> cartRepos;
            
           var cartlist = db.Carts.ToList();
           var productlist = db.Products.ToList();
           var result =
                from c in cartlist
                join p in productlist
                on c.Product_ID equals p.Product_Id
                where c.Customer_ID==customerID
                select
                new CartViewModel
                { CartId = c.Cart_ID,ProductName=p.Product_Name ,ProductNo = p.Product_Id,Unitprice=p.UnitPrice,Size = p.Size, Quantity = c.Quantity, ProductImage = p.Product_Image };
            cartRepos = result.ToList();
            return cartRepos;
        }
    }
}