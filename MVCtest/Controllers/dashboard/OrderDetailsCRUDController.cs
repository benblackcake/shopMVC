using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers.dashboard
{
    public class OrderDetailsCRUDController : Controller
    {
        //private OdContext db = new OdContext();
        private DBModel db = new DBModel();
        // GET: OrderDetailsCRUD

        public ActionResult Index()
        {

            //var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            var orderDetails = db.OrderDetails.ToList();
            return View(orderDetails);
        }

        // GET: OrderDetailsCRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetailsCRUD/Create
        public ActionResult Create()
        {
            ViewBag.Order_Id = new SelectList(db.Orders, "Order_ID", "Order_ID");
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name");
            return View();
        }

        // POST: OrderDetailsCRUD/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Order_Id,Product_Id,Product_Name,Product_Detail,UnitPrice,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Order_Id = new SelectList(db.Orders, "Order_ID", "Order_ID", orderDetail.Order_Id);
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", orderDetail.Product_Id);
            return View(orderDetail);
        }

        // GET: OrderDetailsCRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Order_Id = new SelectList(db.Orders, "Order_ID", "Order_ID", orderDetail.Order_Id);
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", orderDetail.Product_Id);
            return View(orderDetail);
        }

        // POST: OrderDetailsCRUD/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Order_Id,Product_Id,Product_Name,Product_Detail,UnitPrice,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Order_Id = new SelectList(db.Orders, "Order_ID", "Order_ID", orderDetail.Order_Id);
            ViewBag.Product_Id = new SelectList(db.Products, "Product_Id", "Product_Name", orderDetail.Product_Id);
            return View(orderDetail);
        }

        // GET: OrderDetailsCRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetailsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetail);
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
