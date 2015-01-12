using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Psydpt.Data.Infrastructure
{
    public interface ICatalog : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        IBaseRepository<PatientInfo, string> PatientInfoRepo { get; }
        IBaseRepository<PatientSigeCaps, string> PatientSigeCapsRepo { get; }
        IBaseRepository<Disorder, Guid> DisordersRepo { get; }
        IBaseRepository<Prediction, Guid> PredictionRepo { get; }
        IBaseRepository<PredictionPuntuation, Guid> PredictionPuntuationRepo { get; }
        IBaseRepository<PredictionSetting, Guid> PredictionSettingRepo { get; }
    }
}
