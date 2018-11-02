using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EM.Calc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string r)
        {    
            //ViewBag.Message = "Hello ASP.NET Core";
            ViewBag.Вася = $"{r} "; //все равно не выодит когда About/stroka
            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calc(double? r, string oper)
        {
            //ViewBag.Message = "Your calculator.";


            var pp = new[] { 1.1, 2, 3 };
             var calc = new Core.Calc(); // просит манифест сборки, что нужно сделать кроме ссылки?

            r = calc.Execute(oper, pp);
     
            ViewBag.Calc = $"{r} ";
            return View();
        }
    }
}