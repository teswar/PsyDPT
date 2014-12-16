using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Psydpt.Business.Infrastructure;
using Psydpt.Data.Entities;
using Psydpt.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Business
{
    public class PsydptServices: IPsydptServices
    {
        protected ICatalog _dataCatalog;
        protected UserManager<AppUser> _userManager;
        protected IPatientService _patientService;
        protected IPatientSigeCapsService _patientSigeCapsService;

        public UserManager<AppUser> UserManager
        {
            get { return _userManager; }
        }


        public IPatientService PatientService
        {
            get { return _patientService; }
        }



        public IPatientSigeCapsService PatientSigeCapsService
        {
            get { return _patientSigeCapsService; }
        }


        public PsydptServices(DbContext dbContext)
        {
            _dataCatalog = new PsydptCatalog(dbContext);
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(dbContext));
            _patientService = new Services.PatientService(_dataCatalog, ref _userManager);
            _patientSigeCapsService = new Services.PatientSigeCapsService(_dataCatalog, ref _userManager);
        }


    }
}
