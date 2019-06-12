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

        private DBModel db ;
        private Cart _carts;

        public void SaveCartDB(int productId,int customerId, int quantity,string color,string size)
        {
            db = new DBModel();

            DbRepository<Cart> repor = new DbRepository<Cart>(db);

            var productDetail = db.Product_Detail.Where(x => x.Color == color && x.Size == size && x.Product_Id == productId).FirstOrDefault();

            var value = db.Cart.Where(x => x.Customer_ID == customerId && x.Product_Detail_Id == productDetail.Product_Detail_Id).FirstOrDefault();

            if (value != null )
            {
              var result = db.Cart.SingleOrDefault(x => x.Product_Detail_Id == productDetail.Product_Detail_Id && x.Customer_ID == customerId);
                result.Quantity += quantity;
                db.SaveChanges();
                return;
            }


                _carts = new Cart()
                {
                    Product_Detail_Id = productDetail.Product_Detail_Id,
                    Customer_ID= customerId,
                    Quantity= quantity                    
                };
                repor.Create(_carts);
                db.SaveChanges();
        }


        public List<CartViewModel> GetListCart(int customerID)
        {

            db = new DBModel();
            DbRepository<Cart> repoCart = new DbRepository<Cart>(db);
            DbRepository<Product> repoProduct = new DbRepository<Product>(db);
            DbRepository<Product_Detail> repoProductDetail = new DbRepository<Product_Detail>(db);

            List<CartViewModel> cartViewModel = new List<CartViewModel>();
            var result =
                 from c in repoCart.GetAll()
                 join pd in repoProductDetail.GetAll() on c.Product_Detail_Id equals pd.Product_Detail_Id
                 join p in repoProduct.GetAll() on pd.Product_Id equals p.Product_Id
                 where c.Customer_ID == customerID 
                 select
                 new CartViewModel
                { CartId = c.Cart_ID, ProductName = p.Product_Name, ProductNo = p.Product_Id, Unitprice = p.UnitPrice, Size = pd.Size, Quantity = c.Quantity, ProductImage = p.Product_Image,Color=pd.Color };

            cartViewModel = result.ToList();
            return cartViewModel;
        }
        public void Delete(int id)
        {   
            db = new DBModel();
            _carts = db.Cart.ToList().Find(x=>x.Cart_ID==id);
            db.Cart.Remove(_carts);
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
            var result = db.Cart.ToList().Find(x => x.Cart_ID == cartID);
            result.Quantity = int.Parse(quantity);
            repoCart.Update(result);
            db.SaveChanges();
        }

        public void SaveOrder(int customerID,string paymentID,string shipperID, string recipient_Name, string recipient_Phone, string recipient_Address)
        {
            DBModel db = new DBModel();

            var result = from c in db.Cart.ToList().FindAll(x => x.Customer_ID == customerID)
                         join pd in db.Product_Detail.ToList()
                         on c.Product_Detail_Id equals pd.Product_Detail_Id
                         join p in db.Product.ToList()
                         on pd.Product_Id equals p.Product_Id
                         where c.Customer_ID == customerID
                         select new { p.Product_Id , c.Quantity, p.UnitPrice,p.Product_Name,pd.Product_Detail_Id };

            var result1 =  result.ToList();



            List<OrderDetail> od = new List<OrderDetail>();
            for(var i = 0; i<result1.Count;i++)
            {
                od.Add(new OrderDetail()
                {
                    Product_Id = result1[i].Product_Id,
                    Product_Detail_Id=result1[i].Product_Detail_Id,
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
                Customer_ID = customerID,
                recipient_Name = recipient_Name,
                recipient_Phone = recipient_Phone,
                recipient_Adress = recipient_Address,
                OrderDetail = od,
                Status="未出貨"
            };

            var allCarts = db.Cart.ToList().FindAll(x => x.Customer_ID == customerID);

            db.Order.Add(order);
            db.Cart.RemoveRange(allCarts);
            db.SaveChanges();
        }
    }
}