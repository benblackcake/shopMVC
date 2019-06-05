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

        public void SaveCartDB(int productId,int customerId, int quantity)
        {
            db = new DBModel();

            DbRepository<Cart> repor = new DbRepository<Cart>(db);
            //if (productId == null)
            //{
            //    _carts = null;
            //}
            //else
            //{
                //_products = db.Products.ToList().Find(x => x.Product_Name == productName);
                _carts = new Cart()
                {
                    Product_ID = productId,
                    Customer_ID= customerId,
                    Quantity= quantity
                };
                //db.Carts.Add(_carts);
                repor.Create(_carts);
                db.SaveChanges();
            //}
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

        public void UpdateQuantity(int cartID,string quantity)
        {
            DBModel db = new DBModel();
            DbRepository<Cart> repoCart = new DbRepository<Cart>(db);
            var result = db.Carts.ToList().Find(x => x.Cart_ID == cartID);
            result.Quantity = int.Parse(quantity);
            repoCart.Update(result);
            db.SaveChanges();
        }

        public void SaveOrder(int customerID,string paymentID,string shipperID)
        {
            DBModel db = new DBModel();

            var result = from c in db.Carts.ToList().FindAll(x => x.Customer_ID == customerID)
                          join p in db.Products.ToList()
                          on c.Product_ID equals p.Product_Id
                          where c.Customer_ID == customerID
                          select new { c.Product_ID, c.Quantity, p.UnitPrice,p.Product_Name };

            var result1 =  result.ToList();



            List<OrderDetail> od = new List<OrderDetail>();
            for(var i = 0; i<result1.Count;i++)
            {
                od.Add(new OrderDetail()
                {
                    Product_Id = result1[i].Product_ID,
                    Quantity = result1[i].Quantity.ToString(),
                    UnitPrice = result1[i].UnitPrice,
                    Product_Name=result1[i].Product_Name,
                });
            }

            Order order = new Order()
            {
                Order_Date = DateTime.Now,
                Payment_ID = int.Parse(paymentID),
                Shipper_ID = int.Parse(shipperID),
                OrderDetails = od
            };

            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}