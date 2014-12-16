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
    public class PatientService : BaseService, IPatientService
    {
        protected UserManager<AppUser> _userManager;

        public PatientService(ICatalog dataCatalog, ref UserManager<AppUser> userManager)
            :base(dataCatalog)
        {
            _userManager = userManager;
        }


        public PatientInfo GetPatientInfo(string userId)
        {
            if (userId == null) { throw new Exceptions.BusinessLogicException("Invalid userId"); }
            return  DataCatalog.PatientInfoRepository.GetById(userId);
        }

        /// <summary>
        /// Creates for modifies patient information.
        /// </summary>
        /// <param name="patientInfo">data model</param>
        /// <returns>created/updated model</returns>
        /// <exception cref="Exceptions.BusinessLogicException">If data has any vilotaions.</exception>
        public PatientInfo SavePatientInfo(PatientInfo patientInfo)
        {
            #region Validating [Thorwing Exception]

            if (patientInfo == null) { throw new Exceptions.BusinessLogicException("Patient Information can't be null"); }
            if (patientInfo.PatientInfoId == null) { throw new Exceptions.BusinessLogicException("PatientInfoId can not be empty/null"); }

            // Check if a patient entity with the id exists, else throw exception
            var user = _userManager.FindById(patientInfo.PatientInfoId);
            if (user == null) { throw new Exceptions.BusinessLogicException("Unavailable to find matching patient record"); }

            #endregion

            var patientInfoDbmodel = GetPatientInfo(patientInfo.PatientInfoId);
            if (patientInfoDbmodel == null) 
            {
                patientInfoDbmodel = patientInfo;
                DataCatalog.PatientInfoRepository.Create(patientInfoDbmodel); 
            }
            else 
            {
                patientInfoDbmodel.PatientInfoId = patientInfo.PatientInfoId;
                patientInfoDbmodel.DateofBirth = patientInfo.DateofBirth;
                patientInfoDbmodel.Gender = patientInfo.Gender;
                patientInfoDbmodel.MatialStatus = patientInfo.MatialStatus;
                patientInfoDbmodel.BloodType = patientInfo.BloodType;
                patientInfoDbmodel.NumberOfChildren = patientInfo.NumberOfChildren;
                patientInfoDbmodel.DescriptionAboutSelf = patientInfo.DescriptionAboutSelf;
                patientInfoDbmodel.WeightInKg = patientInfo.WeightInKg;
                patientInfoDbmodel.HeightInCm = patientInfo.HeightInCm;
            }

            DataCatalog.UnitOfWork.SaveChanges();
            return patientInfoDbmodel;
        }
    }



}
