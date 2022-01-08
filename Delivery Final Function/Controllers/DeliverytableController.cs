using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Delivery_Final_Function;

namespace Delivery_Final_Function.Controllers
{
    public class DeliverytableController : Controller
    {
        private DeliveryDataModel db = new DeliveryDataModel();

        // GET: Deliverytable
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "DeliveryPerson")
            {
                return View(db.Deliverytables.Where(x => x.DeliveryPerson == search || search == null).ToList());
            }
            else
            {
                return View(db.Deliverytables.Where(x => x.DeliveredProducts.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Deliverytable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliverytable deliverytable = db.Deliverytables.Find(id);
            if (deliverytable == null)
            {
                return HttpNotFound();
            }
            return View(deliverytable);
        }

        // GET: Deliverytable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliverytable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryID,CustomerID,DeliveryPerson,Amount,Feedback,DeliveryAddress,ProductID,DeliveredProducts")] Deliverytable deliverytable)
        {
            if (ModelState.IsValid)
            {
                db.Deliverytables.Add(deliverytable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliverytable);
        }

        // GET: Deliverytable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliverytable deliverytable = db.Deliverytables.Find(id);
            if (deliverytable == null)
            {
                return HttpNotFound();
            }
            return View(deliverytable);
        }

        // POST: Deliverytable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryID,CustomerID,DeliveryPerson,Amount,Feedback,DeliveryAddress,ProductID,DeliveredProducts")] Deliverytable deliverytable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliverytable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliverytable);
        }

        // GET: Deliverytable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliverytable deliverytable = db.Deliverytables.Find(id);
            if (deliverytable == null)
            {
                return HttpNotFound();
            }
            return View(deliverytable);
        }

        // POST: Deliverytable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deliverytable deliverytable = db.Deliverytables.Find(id);
            db.Deliverytables.Remove(deliverytable);
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
