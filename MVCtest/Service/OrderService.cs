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
            List<OrderTrackingViewModel>  _ordertrackingViewModel;
            var tmp =
                from c in repoOrder.GetAll()
                join p in repoOrderDetail.GetAll()             
                on c.Order_ID equals p.Order_Id
                where c.Customer_ID == customerId
                join pay in repoPayment.GetAll()
                on c.Payment_ID equals pay.Payment_ID
                select
                new OrderTrackingViewModel
                {
                    OrderId = c.Order_ID, ProductName = p.Product_Name, OrderDate = c.Order_Date, Price = p.UnitPrice, Payment = pay.Payment_Name};
            //_ordertrackingViewModel = result.ToList();
            foreach (var item in tmp)
            {
                result.Items.Add(item);
            }
            return result;
           
        }
    }
}