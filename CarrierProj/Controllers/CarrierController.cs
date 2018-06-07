using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrierProj.Models;

namespace CarrierProj.Controllers
{
    public class CarrierController : Controller
    {
        private PracticeDBEntities db = new PracticeDBEntities();

        // GET: Carrier
        public ActionResult Index()
        {
            var carriers = db.Carriers.Include(c => c.State);
            return View(carriers.ToList());
        }
        [OutputCache(Duration =7200, Location =System.Web.UI.OutputCacheLocation.Client, VaryByParam ="none",NoStore =true)]
        public ActionResult Search(String SearchBox)
        {
            //Select * from Carriers c where c.
            var carriers= (from c in db.Carriers
                          where c.Address1.Contains(SearchBox)
                          || c.Address2.Contains(SearchBox)
                          || c.Email.Contains(SearchBox)
                          || c.City.Contains(SearchBox)
                          || c.MCNumber.Contains(SearchBox)
                          || c.State.StateName.Contains(SearchBox)
                          ||c.WebURL.Contains(SearchBox)
                          ||c.Zip.Contains(SearchBox)                          
                          select c).ToList();
            return View("Index",carriers);
        }

        // GET: Carrier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // GET: Carrier/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: Carrier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarrierID,MCNumber,DOTNumber,Address1,Address2,City,StateID,Zip,Email,WebURL,Active,DateCreated,LastModified")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Carriers.Add(carrier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", carrier.StateID);
            return View(carrier);
        }

        // GET: Carrier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", carrier.StateID);
            return View(carrier);
        }

        // POST: Carrier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarrierID,MCNumber,DOTNumber,Address1,Address2,City,StateID,Zip,Email,WebURL,Active,DateCreated,LastModified")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", carrier.StateID);
            return View(carrier);
        }

        // GET: Carrier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrier carrier = db.Carriers.Find(id);
            if (carrier == null)
            {
                return HttpNotFound();
            }
            return View(carrier);
        }

        // POST: Carrier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrier carrier = db.Carriers.Find(id);
            db.Carriers.Remove(carrier);
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
