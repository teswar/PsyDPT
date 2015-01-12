using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Psydpt.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
            :base()
        {}

        public ActionResult Index()
        {
            return View();
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
        public ActionResult Tokenize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tokenize(string data)
        {
            List<string> result = new List<string>();

            //if (!string.IsNullOrWhiteSpace(data))
            //{
            //    result = Psydpt.Business.Services.Tokenizer.Tokenize(data);
            //}

            ViewBag.Result = result;
            return View();
        }

    }
}