using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropDownList.Models;

namespace DropDownList.Controllers
{
    public class DropDownController : Controller
    {
        // GET: DropDown
        public ActionResult Index()
        {
            Subjects subjectName = new Subjects();
            subjectName.SubjectList.Add(new SelectListItem {Text="Physics",Value="1"});
            subjectName.SubjectList.Add(new SelectListItem { Text = "Chemistry", Value = "2" });

            return View(subjectName);
        }
    }
}