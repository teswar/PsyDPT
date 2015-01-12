using Microsoft.AspNet.Identity;
using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Business.Infrastructure
{
    public interface IPsydptServices
    {
        UserManager<AppUser> UserManager { get; }

        IPatientService PatientService { get; }

        IPatientSigeCapsService PatientSigeCapsService { get; }

        IPredictionService PredictionService { get; }
    }
}
