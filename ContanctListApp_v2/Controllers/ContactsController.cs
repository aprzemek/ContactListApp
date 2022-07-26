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
    public class ContactsController : Controller
    {
        private ContactListEntities db = new ContactListEntities();

        // GET: Contacts
        public ActionResult Index()
        {
            var contact = db.Contact.Include(c => c.BuisnessCategory).Include(c => c.Category);
            return View(contact.ToList());
        }
        [Authorize]
        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [Authorize]
        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.BuisnessCategoryId = new SelectList(db.BuisnessCategory, "id", "name");
            ViewBag.categoryId = new SelectList(db.Category, "id", "name");
            return View();
        }
        [Authorize]
        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,surname,email,password,categoryId,anotherCategory,phone,dateOfBirth,BuisnessCategoryId")] Contact contact)
        {
           
                if (ModelState.IsValid)
                {
                    db.Contact.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            

            ViewBag.BuisnessCategoryId = new SelectList(db.BuisnessCategory, "id", "name", contact.BuisnessCategoryId);
            ViewBag.categoryId = new SelectList(db.Category, "id", "name", contact.categoryId);
            return View(contact);
        }
        [Authorize]
        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuisnessCategoryId = new SelectList(db.BuisnessCategory, "id", "name", contact.BuisnessCategoryId);
            ViewBag.categoryId = new SelectList(db.Category, "id", "name", contact.categoryId);
            return View(contact);
        }
        [Authorize]
        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,surname,email,password,categoryId,anotherCategory,phone,dateOfBirth,BuisnessCategoryId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuisnessCategoryId = new SelectList(db.BuisnessCategory, "id", "name", contact.BuisnessCategoryId);
            ViewBag.categoryId = new SelectList(db.Category, "id", "name", contact.categoryId);
            return View(contact);
        }
        [Authorize]
        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [Authorize]
        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contact.Find(id);
            db.Contact.Remove(contact);
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
