using Psydpt.Business.Infrastructure;
using Psydpt.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Psydpt.Areas.Admin.Controllers
{
        
    [Authorize(Roles = "Admin")]
    public class HomeController : Core.BaseDataController
    {
        public HomeController()
            : base()
        { }


        public HomeController(IPsydptServices dataServices)
            : base(dataServices)
        { }


        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            return View();
        }



	}
}