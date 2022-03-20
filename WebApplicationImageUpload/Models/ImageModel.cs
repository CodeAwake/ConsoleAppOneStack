using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationImageUpload.Models
{
    public class ImageModel
    {
        [DataType(DataType.Upload)]
        [Display(Name ="Upload File")]
        [Required(ErrorMessage ="Error in uploaded file")]
       public string file { get; set; }
    }
}