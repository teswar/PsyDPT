using Psydpt.Areas.Patient.ViewModels;
using Psydpt.Business.Exceptions;
using Psydpt.Business.Infrastructure;
using Psydpt.Business.Services;
using Psydpt.Core;
using Psydpt.Data.Entities;
using Psydpt.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Psydpt.Areas.Patient.Controllers
{

    [Authorize(Roles = "Patient")]
    public class HomeController : BaseDataController
    {
        public HomeController()
            : base()
        { }


        public HomeController(IPsydptServices dataServices)
            : base(dataServices)
        { }


        public ActionResult Index()
        {
            return RedirectToAction("PredictDisorder");
        }


        //public ActionResult PatientInfoSideBar(Guid id)
        //{
        //    var response = new Core.ViewModels.DataResponse<PatientInfo>();

        //    try
        //    {
        //        response.Data = this.PatientService.GetPatientInfo(id);
        //    }
        //    catch (Psydpt.Business.Exceptions.BusinessLogicException exp)
        //    {
        //        response.Status = Core.Enums.ResponseStatus.Error;
        //        response.Message = exp.Message;
        //        response.Log = exp.InnerException;
        //    }

        //    return View(response);
        //}

        [HttpGet]
        public ActionResult ManageAccount()
        {
            return View();
        }

          
        [HttpGet]
        public ActionResult PatientInfoPartial()
        {
            var user = Services.UserManager.FindByNameAsync(User.Identity.Name).Result;
            var model = new PatientInfoVM(user, Services.PatientService.GetPatientInfo(user.Id));
            return View("_PatientInfoPartial", model);
        }

          
        [HttpPost]
        public ActionResult PatientInfoPartial(PatientInfoVM viewmodel)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var model = viewmodel.GetDbModel();
                    model.PatientInfoId = Services.UserManager.FindByNameAsync(User.Identity.Name).Result.Id;
                    model = Services.PatientService.SavePatientInfo(model);
                    if (model == null) { throw new InvalidOperationException("Unexpected error occured while saving patient information."); }
                }
                catch (Exception exp)
                {
                    // If the exception if of unexcepted type thorw
                    if (!((exp is ServiceBaseException) || (exp is InvalidOperationException))) { throw exp; }
                    ModelState.AddModelError("", exp.Message ?? ""); 
                }
            }


            return View("_PatientInfoPartial", viewmodel);
        }


        [HttpGet]
        public ActionResult PatientSigeCapPartial()
        {
            var user = Services.UserManager.FindByNameAsync(User.Identity.Name).Result;
            var model = new PatientSigeCapsVM(Services.PatientSigeCapsService.GetPatientSigeCaps(user.Id));
            return View("_PatientSigeCapsPartial", model);
        }


        [HttpPost]
        public ActionResult PatientSigeCapPartial(PatientSigeCapsVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = viewmodel.GetDbModel();
                    model.PatientSigeCapId = Services.UserManager.FindByNameAsync(User.Identity.Name).Result.Id;
                    model = Services.PatientSigeCapsService.SavePatientSigeCaps(model);
                    if (model == null) { throw new InvalidOperationException("Unexpected error occured while saving patient sigecap information."); }
                }
                catch (Exception exp)
                {
                    // If the exception if of unexcepted type thorw
                    if (!((exp is ServiceBaseException) || (exp is InvalidOperationException))) { throw exp; }
                    ModelState.AddModelError("", exp.Message ?? "");
                }
            }


            return View("_PatientSigeCapsPartial", viewmodel);
        }





        public ActionResult PredictDisorder()
        {
            return View();
        }








        public ActionResult PatientInfoSideBar()
        {
            var user = Services.UserManager.FindByNameAsync(User.Identity.Name).Result;
            var model = Services.PatientService.GetPatientInfo(user.Id);
            return View("_PatientInfoSideBar", model);
        }
	}
}