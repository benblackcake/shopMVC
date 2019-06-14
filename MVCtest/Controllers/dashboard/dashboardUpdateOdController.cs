using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCtest.Models;
using MVCtest.ViewModels;

namespace MVCtest.Controllers.dashboard
{
    public class dashboardUpdateOdController : Controller
    {
        //// GET: dashboardUpdateOd
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string orderId)
        {
            DBModel db = new DBModel();
            List<OrderDetailViewModel> result = new List<OrderDetailViewModel>();
            List<int> result1 = new List<int>();
            var value =
                from o in db.OrderDetail.ToList()
                join pd in db.Product_Detail.ToList()
                on o.Product_Detail_Id equals pd.Product_Detail_Id
                where o.Order_Id == int.Parse(orderId)
                select
                new OrderDetailViewModel
                {
                    orderId = o.OrderDetail_Id,
                    productName = o.Product_Name,
                    unitPrice = o.UnitPrice,
                    quantity = o.Quantity,
                    productId = o.Product_Id,
                    productDetailList = db.Product_Detail.Where(x=>x.Product_Id ==o.Product_Id).ToList(),
                    pdId = o.Product_Detail_Id
                    
                    //size = pd.Size,
                    //color = pd.Color
                };

            result.AddRange(value.ToList());
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateOrderDrtail(string odId,string pdId, string quantity)
        {
            DBModel db = new DBModel();
            var OrderDetail_Id = int.Parse(odId);
            var value = db.OrderDetail.Where(x => x.OrderDetail_Id == OrderDetail_Id).FirstOrDefault();

            value.Product_Detail_Id = int.Parse(pdId);
            value.Quantity = int.Parse(quantity);
            db.SaveChanges();
            return RedirectToAction("Index","dashboardUpdateOd");

        }

        public ActionResult DeleteOrderDetail(int odId)
        {
            DBModel db = new DBModel();
            var reuslt =  db.OrderDetail.Where(x => x.OrderDetail_Id == odId).FirstOrDefault();
            db.OrderDetail.Remove(reuslt);
            db.SaveChanges();
            return RedirectToAction("Index", "dashboardUpdateOd");
        }
    }
}