using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psydpt.Data;
using Psydpt.Data.Entities;

namespace Psydpt.Business.Infrastructure
{
    public interface IPatientSigeCapsService
    {
        PatientSigeCaps GetPatientSigeCaps(string userId);

        PatientSigeCaps SavePatientSigeCaps(PatientSigeCaps patientInfo);
    }



}
