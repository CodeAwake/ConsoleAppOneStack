using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StepThree.Models;

namespace StepThree.Controllers
{
    public class TestController : Controller
    {
        private TxtDbContext db = new TxtDbContext();

        // GET: Test
        public ActionResult Index()
        {
            return View(db.TextBoxs.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBoxClass = db.TextBoxs.Find(id);
            if (textAreaBoxClass == null)
            {
                return HttpNotFound();
            }
            return View(textAreaBoxClass);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] TextAreaBoxClass textAreaBoxClass)
        {
            if (ModelState.IsValid)
            {
                db.TextBoxs.Add(textAreaBoxClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textAreaBoxClass);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBoxClass = db.TextBoxs.Find(id);
            if (textAreaBoxClass == null)
            {
                return HttpNotFound();
            }
            return View(textAreaBoxClass);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripton")] TextAreaBoxClass textAreaBoxClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textAreaBoxClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(textAreaBoxClass);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBoxClass = db.TextBoxs.Find(id);
            if (textAreaBoxClass == null)
            {
                return HttpNotFound();
            }
            return View(textAreaBoxClass);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextAreaBoxClass textAreaBoxClass = db.TextBoxs.Find(id);
            db.TextBoxs.Remove(textAreaBoxClass);
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
