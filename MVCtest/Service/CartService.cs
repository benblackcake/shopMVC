using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System.Diagnostics;

namespace MVCtest.Service
{
    public class CartService
    {
       private Product products;
       private Cart carts;

        public void SaveCartDB(string productName,int quantity)
        {
            DBModel db = new DBModel();
            if (productName ==null)
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
            DBModel db = new DBModel();
            List<CartViewModel> cartRepos;
            DbRepository<Cart> repoCart = new DbRepository<Cart>(db);
            DbRepository<Product> repoProduct = new DbRepository<Product>(db);


           var result =
                from c in repoCart.GetAll()
                join p in repoProduct.GetAll()
                on c.Product_ID equals p.Product_Id
                where c.Customer_ID==customerID
                select
                new CartViewModel
                { CartId = c.Cart_ID,ProductName=p.Product_Name ,ProductNo = p.Product_Id,Unitprice=p.UnitPrice,Size = p.Size, Quantity = c.Quantity, ProductImage = p.Product_Image };
            cartRepos = result.ToList();
            return cartRepos;
        }

        public void DeleteCart(int CartId)
        {
            DBModel context = new DBModel();
            DbRepository<Cart> repoCart = new DbRepository<Cart>(context);

            Cart cus = repoCart.GetAll().FirstOrDefault((x) => x.Cart_ID == CartId);
            repoCart.Delete(cus);
            context.SaveChanges();

        }
    }
}