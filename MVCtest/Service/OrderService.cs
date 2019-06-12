using MVCtest.Models;
using MVCtest.Repository;
using MVCtest.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MVCtest.Service
{
    public class OrderService
    {

        //private DBModel db;
        //private OrderDetail _orderDetail;
        //private Order _order;

        public SaleQuantityListViewModel GetSaleQuantity() {
            SaleQuantityListViewModel result = new SaleQuantityListViewModel();
            result.Item = new List<SaleQuantityViewModel>();
            DBModel context = new DBModel();
            //DbRepository<Order> repo = new DbRepository<Order>(context);
            var tmp = context.Database.SqlQuery<SaleQuantityViewModel>(@"select MONTH( Order_Date)Month, COUNT(*)Quantity
                                                FROM[dbo].[Order]
                                                Group By MONTH(Order_Date);"
                                              );


            foreach(var i in tmp){
                SaleQuantityViewModel sqv = new SaleQuantityViewModel()
                {
                    Month = i.Month,
                    Quantity = i.Quantity

                };
                result.Item.Add(sqv);

            }
            return result;

            //foreach(var i in result.Item)
            //{
            //    Debug.Print(i.Month.ToString()+" "+i.Quantity.ToString());
            //}
        }
        public OrderTrackingListViewModel GetListOrder(int customerId) {

            DBModel db = new DBModel();
            OrderTrackingListViewModel result = new OrderTrackingListViewModel();
            result.Items = new List<OrderTrackingViewModel>();
            DbRepository<Order> repoOrder = new DbRepository<Order>(db);
            DbRepository<OrderDetail> repoOrderDetail = new DbRepository<OrderDetail>(db);
            DbRepository<Payment> repoPayment = new DbRepository<Payment>(db);


            var tmp =
                from o in repoOrder.GetAll()
                join od in repoOrderDetail.GetAll()
                on o.Order_ID equals od.Order_Id
                where o.Customer_ID == customerId
                join pay in repoPayment.GetAll()
                on o.Payment_ID equals pay.Payment_ID
                group od by new { o.Order_ID, o.Order_Date, o.Status, pay.Payment_Name } into g
                select new OrderTrackingViewModel
                {
                    OrderId = g.Key.Order_ID,
                    OrderDate = g.Key.Order_Date,
                    Price = (g.Sum(od => od.Quantity * od.UnitPrice)).ToString(),
                    Payment = g.Key.Payment_Name,
                    OrderState = g.Key.Status
                };

            foreach (var item in tmp)
            {
                result.Items.Add(item);
            }
            return result;
           
        }
        //public bool UpdateStatus(int Order_ID,string Status)
        //{
        //    DBModel context = new DBModel();
        //    DbRepository<Order> repo = new DbRepository<Order>(context);          
        //    repo.Update2(Order_ID,Status);
           
        //    context.SaveChanges();
            
        //    return true;
            
        //}
    }
}