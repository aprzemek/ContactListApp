using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContanctListApp_v2.Models;

namespace ContanctListApp_v2.Controllers
{
    [Authorize]
    public class BuisnessCategoriesController : Controller
    {
        private ContactListEntities db = new ContactListEntities();

        // GET: BuisnessCategories
        public ActionResult Index()
        {
            return View(db.BuisnessCategory.ToList());
        }

        // GET: BuisnessCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuisnessCategory buisnessCategory = db.BuisnessCategory.Find(id);
            if (buisnessCategory == null)
            {
                return HttpNotFound();
            }
            return View(buisnessCategory);
        }

        // GET: BuisnessCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuisnessCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] BuisnessCategory buisnessCategory)
        {
            if (ModelState.IsValid)
            {
                db.BuisnessCategory.Add(buisnessCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buisnessCategory);
        }

        // GET: BuisnessCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuisnessCategory buisnessCategory = db.BuisnessCategory.Find(id);
            if (buisnessCategory == null)
            {
                return HttpNotFound();
            }
            return View(buisnessCategory);
        }

        // POST: BuisnessCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] BuisnessCategory buisnessCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buisnessCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buisnessCategory);
        }

        // GET: BuisnessCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuisnessCategory buisnessCategory = db.BuisnessCategory.Find(id);
            if (buisnessCategory == null)
            {
                return HttpNotFound();
            }
            return View(buisnessCategory);
        }

        // POST: BuisnessCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuisnessCategory buisnessCategory = db.BuisnessCategory.Find(id);
            db.BuisnessCategory.Remove(buisnessCategory);
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
