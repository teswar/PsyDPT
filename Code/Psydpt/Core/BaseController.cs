using Psydpt.Business;
using Psydpt.Business.Infrastructure;
using Psydpt.Data;
using Psydpt.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Psydpt.Core
{
    public class BaseDataController : Controller
    {
        protected IPsydptServices Services;

        public BaseDataController(IPsydptServices dataServices)
            :base()
        {

            if (dataServices == null) { throw new ArgumentNullException("dataServices", "Can not initialize a data controller with invalid dataServices"); }

            this.Services = dataServices;
        }


        public BaseDataController()
            : this(new PsydptServices(new PsydptContext()))
        { }


        protected override void Dispose(bool disposing)
        {
            if (disposing && Services != null) { this.Services = null; }
            base.Dispose(disposing);
        }

    }
}