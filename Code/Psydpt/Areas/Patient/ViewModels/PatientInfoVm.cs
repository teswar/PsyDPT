﻿using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psydpt.Areas.Patient.ViewModels
{
    public class PatientInfoVM : Data.Entities.PatientInfo
    {
        public string Name { get; set; }

        public PatientInfoVM()
            :this(null, null)
        { }

        public PatientInfoVM(AppUser userEntity, PatientInfo patientInfoEntity)
        {
            if (patientInfoEntity == null) { return; }
            this.Gender = patientInfoEntity.Gender;
            this.BloodType = patientInfoEntity.BloodType;
            this.DateofBirth = patientInfoEntity.DateofBirth;
            this.HeightInCm = patientInfoEntity.HeightInCm;
            this.MatialStatus = patientInfoEntity.MatialStatus;
            this.WeightInKg = patientInfoEntity.WeightInKg;
            this.PatientInfoId = patientInfoEntity.PatientInfoId;

            if (userEntity == null) { return; }
            this.Name = userEntity.Name;
        }

        public Data.Entities.PatientInfo GetDbModel() 
        {
            if (this == null) { return null; }
            return new PatientInfo()
            {
                Gender = this.Gender,
                BloodType = this.BloodType,
                DateofBirth = this.DateofBirth,
                HeightInCm = this.HeightInCm,
                MatialStatus = this.MatialStatus,
                WeightInKg = this.WeightInKg,
                PatientInfoId = this.PatientInfoId
            };
        }


    }
}