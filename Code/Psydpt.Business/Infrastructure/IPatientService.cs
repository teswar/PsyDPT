using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psydpt.Data;
using Psydpt.Data.Entities;

namespace Psydpt.Business.Infrastructure
{
    public interface IPatientService
    {
        PatientInfo GetPatientInfo(string userId);

        PatientInfo SavePatientInfo(PatientInfo patientInfo);
    }



}
