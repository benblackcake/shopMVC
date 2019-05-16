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
            db = new DBModel();
            List<CartViewModel> cartViewModel;
            
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
            cartViewModel = result.ToList();
            return cartViewModel;
        }
        public void Delete(int id)
        {
            _carts = db.Carts.ToList().Find(x=>x.Cart_ID==id);
            db.Carts.Remove(_carts);
            db.SaveChanges();
        }
    }
}