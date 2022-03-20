using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StepThree.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
namespace StepThree.Controllers
{
    public class HomeController : Controller
    {
      private TxtDbContext txt = new TxtDbContext();
        public ActionResult Index()
        {
            //return View();
            return View(txt.TextBoxs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post([Bind(Include ="ID,Description")] TextAreaBoxClass textAreaBoxClass)
        {
            if (ModelState.IsValid)
            { 
            txt.TextBoxs.Add(textAreaBoxClass);
            txt.SaveChanges();
            return RedirectToAction("Index");
            }

            return View(textAreaBoxClass);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBoxClass = txt.TextBoxs.Find(id);
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

        public ActionResult Edit([Bind(Include="ID,Description")]TextAreaBoxClass textAreaBoxClass)
        {
            if (ModelState.IsValid)
            {
                txt.Entry(textAreaBoxClass).State = EntityState.Modified;
                txt.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textAreaBoxClass);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBox = txt.TextBoxs.Find(id);
            if (textAreaBox == null)
            {
                return HttpNotFound();
            }
            return View(textAreaBox);
        }
        [HttpPost]
        public ActionResult Delete(TextAreaBoxClass textAreaBoxClass)
        {
            if (ModelState.IsValid)
            {
                txt.Entry(textAreaBoxClass).State = EntityState.Deleted;
                txt.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textAreaBoxClass);
        }
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextAreaBoxClass textAreaBoxClass = txt.TextBoxs.Find(id);
            if(textAreaBoxClass == null)
            {
                return HttpNotFound();
            }
            return View(textAreaBoxClass);
        }
    }
}