using Psydpt.Business.Entities;
using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Business.Infrastructure
{
    public interface IPredictionService
    {
        List<PerdictionMatch> Predict(string symptom);

        List<PerdictionMatch> Predict(AppUser patient, string symptom);

        IEnumerable<Prediction> GetPrediction();

        IEnumerable<Prediction> GetPredictions(AppUser patient);

        Prediction SavePrediction(Prediction prediction);
        
    }
}
