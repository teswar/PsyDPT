using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psydpt.Data;
using Psydpt.Data.Entities;
using Psydpt.Business.Infrastructure;
using Psydpt.Data.Infrastructure;
using Microsoft.AspNet.Identity;

namespace Psydpt.Business.Services
{
    public class PatientSigeCapsService : BaseService, IPatientSigeCapsService
    {
        protected UserManager<AppUser> _userManager;

        public PatientSigeCapsService(ICatalog dataCatalog, ref UserManager<AppUser> userManager)
            : base(dataCatalog)
        {
            _userManager = userManager;
        }


        public PatientSigeCaps GetPatientSigeCaps(string userId)
        {
            if (userId == null) { throw new Exceptions.BusinessLogicException("Invalid userId"); }
            return DataCatalog.PatientSigeCapsRepository.GetById(userId);
        }


        public PatientSigeCaps SavePatientSigeCaps(PatientSigeCaps patientSigeCaps)
        {

            #region Validating [Thorwing Exception]

            if (patientSigeCaps == null) { throw new Exceptions.BusinessLogicException("Patient SigeCaps can't be null"); }
            if (patientSigeCaps.PatientSigeCapId == null) { throw new Exceptions.BusinessLogicException("Patient SigeCaps can not be empty/null"); }

            // Check if a patient entity with the id exists, else throw exception
            var user = _userManager.FindById(patientSigeCaps.PatientSigeCapId);
            if (user == null) { throw new Exceptions.BusinessLogicException("Unavailable to find matching patient record"); }

            #endregion

            var dbmodel = GetPatientSigeCaps(patientSigeCaps.PatientSigeCapId);
            if (dbmodel == null)
            {
                dbmodel = patientSigeCaps;
                DataCatalog.PatientSigeCapsRepository.Create(dbmodel);
            }
            else
            {
                dbmodel.Sleepiness = patientSigeCaps.Sleepiness;
                dbmodel.Interest = patientSigeCaps.Interest;
                dbmodel.EnergyLevel = patientSigeCaps.EnergyLevel;
                dbmodel.Concentration = patientSigeCaps.Concentration;
                dbmodel.Appetite = patientSigeCaps.Appetite;
                dbmodel.Agitation = patientSigeCaps.Agitation;
                dbmodel.GuiltyFeelings = patientSigeCaps.GuiltyFeelings;
                dbmodel.SucidalThoughts = patientSigeCaps.SucidalThoughts;
            }

            DataCatalog.UnitOfWork.SaveChanges();
            return dbmodel;
        }
    }



}


