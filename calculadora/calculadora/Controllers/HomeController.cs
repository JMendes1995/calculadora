using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calculadora.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt)
        {
            double resultado = 0;
            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    ViewBag.bt = bt;
                    break;
                default:
                    bt ="0";
                    ViewBag.bt = bt;
                    break;
            }
            return View();
        }
    }
}