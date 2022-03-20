using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StepThree.Models
{
    public class TextAreaBoxClass
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
    public class TxtDbContext : DbContext {

        public DbSet<TextAreaBoxClass> TextBoxs { get; set; }
    
    }
}