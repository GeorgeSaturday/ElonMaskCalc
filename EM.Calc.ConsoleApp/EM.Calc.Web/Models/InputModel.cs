using EM.Calc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Models
{
    public class InputModel
    {
        [Display(Name = "Операция")]
        public string Selected { get; set; }

        
        public IEnumerable<SelectListItem> Operations { get; set; }

      
        [Required(ErrorMessage = "Нужно знать операцию")]
        public string Name { get; set; }

        [Display(Name = "Аргументы")]
        [Required]
        public string Args { get; set; }

        //[Display(Name = "Параметр2")]
        //[Required]
        //public string Args2 { get; set; }

        

    }
}