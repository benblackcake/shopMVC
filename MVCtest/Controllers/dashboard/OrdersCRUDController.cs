using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCtest.Fiter;
using MVCtest.Models;
using MVCtest.Service;

namespace MVCtest.Controllers.dashboard
{
    public class OrdersCRUDController : Controller
    {
        public DBModel db = new DBModel();

        // GET: OrdersCUUD
        [AuthorizeMaster]
        public ActionResult Index()
        {

            var orders = db.Orders;

            return View(orders.ToList());
        }

        [HttpPost]
        public ActionResult EditStatus(Order order)
        {
            //OrderService os = new OrderService();

            //ViewBag.RowsAffected = db.Database.ExecuteSqlCommand("UPDATE Order SET Status = '已出貨' WHERE Order_ID=", Order_ID);
            //int Id = od.Order_ID;
            //string name = od.Customer.Customer_Name;
            //string payment = od.Payment.Payment_Name;
            //string shipper = od.Shipper.Shipper_Method_Name;
            //DateTime? date = od.Order_Date;
            //string status = od.Status;

            //if (os.UpdateStatus(Order_ID, Status))
            //{
            //    return RedirectToAction("Index", "OrdersCRUD");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "OrdersCRUD");
            //}

            if (ModelState.IsValid)
            {
                Order od = db.Orders.Find(order.Order_ID);
                if (od != null)
                {
                    od.Status = order.Status;
                    db.Entry(od).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(order);

        }


        // GET: OrdersCUUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: OrdersCUUD/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name");
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Payment_Name");
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_Id", "Shipper_Method_Name");
            return View();
        }

        // POST: OrdersCUUD/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_ID,Order_Date,Customer_ID,Shipper_ID,Payment_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", order.Customer_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Payment_Name", order.Payment_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_Id", "Shipper_Method_Name", order.Shipper_ID);
            return View(order);
        }

        // GET: OrdersCUUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", order.Customer_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Payment_Name", order.Payment_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_Id", "Shipper_Method_Name", order.Shipper_ID);
            return View(order);
        }

        // POST: OrdersCUUD/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_ID,Order_Date,Customer_ID,Shipper_ID,Payment_ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", order.Customer_ID);
            ViewBag.Payment_ID = new SelectList(db.Payments, "Payment_ID", "Payment_Name", order.Payment_ID);
            ViewBag.Shipper_ID = new SelectList(db.Shippers, "Shipper_Id", "Shipper_Method_Name", order.Shipper_ID);
            return View(order);
        }

        // GET: OrdersCUUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: OrdersCUUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
