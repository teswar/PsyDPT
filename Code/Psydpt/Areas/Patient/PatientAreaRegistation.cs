using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Psydpt.Areas.Patient
{
    public class PatientAreaRegistation: AreaRegistration
    {
        private readonly string _areaName;
        public override string AreaName
        {
            get
            {
                return _areaName;
            }
        }




        public PatientAreaRegistation(string areaName)
            : base()
        {
            _areaName = areaName;
        }


        public PatientAreaRegistation()
            : this(Psydpt.Core.Contants.Areas.PATIENT)
        { }


        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(     
                name: (_areaName + "_Default"),
                url: (_areaName + "/{controller}/{action}/{id}"),
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Psydpt.Areas.Patient.Controllers" });
        }
    }
}