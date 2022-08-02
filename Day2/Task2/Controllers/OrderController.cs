using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class OrderController : Controller
    {
        private AssignmentDBEntities db = new AssignmentDBEntities();

        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order Order = db.Orders.Find(id);
            if (Order == null)
            {
                return HttpNotFound();
            }
            return View(Order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerName,OrderAmount,OrderDate")] Order Order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Order);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order Order = db.Orders.Find(id);
            if (Order == null)
            {
                return HttpNotFound();
            }
            return View(Order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerName,OrderAmount,OrderDate")] Order Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Order);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order Order = db.Orders.Find(id);
            if (Order == null)
            {
                return HttpNotFound();
            }
            return View(Order);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order sample = db.Orders.Find(id);
            db.Orders.Remove(sample);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}