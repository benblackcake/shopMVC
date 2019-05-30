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
    }
}