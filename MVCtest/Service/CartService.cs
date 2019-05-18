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
//<<<<<<< HEAD
//       private Product products;
//       private Cart carts;

//        public void SaveCartDB(string productName,int quantity)
//        {
//            DBModel db = new DBModel();
//=======

        private DBModel db ;
        private Product _products;
        private Cart _carts;

        public void SaveCartDB(string productName,int quantity)
        {
            db = new DBModel();


            if (productName ==null)
            {
                _carts = null;
            }
            else
            {
                _products = db.Products.ToList().Find(x => x.Product_Name == productName);
                _carts = new Cart()
                {
                    Product_ID = _products.Product_Id,
                    Customer = _products.Customer,
                    Quantity = quantity
                };
                db.Carts.Add(_carts);
                db.SaveChanges();
            }
        }
        public List<CartViewModel> GetListCart(int customerID)
        {
            //<<<<<<< HEAD
            //List<CartViewModel> cartRepos;
            db = new DBModel();
            DbRepository<Cart> repoCart = new DbRepository<Cart>(db);
            DbRepository<Product> repoProduct = new DbRepository<Product>(db);
            //=======
            
            List<CartViewModel> cartViewModel;
           var result =
                from c in repoCart.GetAll()
                join p in repoProduct.GetAll()
                on c.Product_ID equals p.Product_Id
                where c.Customer_ID==customerID
                select
                new CartViewModel
                { CartId = c.Cart_ID,ProductName=p.Product_Name ,ProductNo = p.Product_Id,Unitprice=p.UnitPrice,Size = p.Size, Quantity = c.Quantity, ProductImage = p.Product_Image };
            cartViewModel = result.ToList();
            return cartViewModel;
        }
        public void Delete(int id)
        {
            db = new DBModel();
            _carts = db.Carts.ToList().Find(x=>x.Cart_ID==id);
            db.Carts.Remove(_carts);
            db.SaveChanges();
        }
        //Testing Use
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