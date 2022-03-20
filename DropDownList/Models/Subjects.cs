using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace DropDownList.Models
{
    public class Subjects
    {
       
     
       
        public Subjects()
        {
            SubjectList = new List<SelectListItem>();
        }

        public List<SelectListItem> SubjectList { get; set; }
    }
}