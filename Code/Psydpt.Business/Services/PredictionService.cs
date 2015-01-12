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
using System.Web;
using edu.stanford.nlp.tagger.maxent;
using com.sun.tools.javac.util;
using System.Text.RegularExpressions;
using Psydpt.Business.Entities;
using Psydpt.Business.Exceptions;

namespace Psydpt.Business.Services
{
   

    public class PredictionService : BaseService, IPredictionService
    {
        protected UserManager<AppUser> _userManager;


        public PredictionService(ICatalog dataCatalog, ref UserManager<AppUser> userManager)
            :base(dataCatalog)
        {
            _userManager = userManager;
        }


        public List<PerdictionMatch> Predict(string symptom)
        {
            if (string.IsNullOrWhiteSpace(symptom)) { throw new BusinessLogicException("Invalid symptom description."); }

            var taggedPgh = Utility.Tagger.TagParaghraph(symptom);
            var tagsToUse = _dataCatalog.PredictionPuntuationRepo.Get().Where(m => (m.IsActive))
                .Select(m => m.Code).ToList();

            taggedPgh.RemoveTags(tagsToUse, true);

            var predicationMatchs = _dataCatalog.DisordersRepo.Get()
                .Select(m => PerdictionMatch.Evaluate(taggedPgh, m))
                .Where(m => m.Matches != null && m.Matches.Count > 0)
                .OrderByDescending(m => m.Matches.Count).ToList();

           

            return predicationMatchs;
        }


        public List<PerdictionMatch> Predict(AppUser patient, string symptom)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Prediction> GetPrediction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prediction> GetPredictions(AppUser patient)
        {
            throw new NotImplementedException();
        }

        public Prediction SavePrediction(Prediction prediction)
        {
            #region Validating [Thorwing Exception]

            if (prediction == null) { throw new Exceptions.BusinessLogicException("Prediction can't be null"); }
        
            // Check if a patient entity with the id exists, else throw exception
            var user = _userManager.FindById(prediction.PatientId);
            if (user == null) { throw new Exceptions.BusinessLogicException("Unavailable to find matching patient record"); }

            var disorder = _dataCatalog.DisordersRepo.GetById(prediction.DisorderId);
            if (disorder == null) { throw new Exceptions.BusinessLogicException("Unavailable to find matching disorder record"); }

            #endregion



            var dbmodel = _dataCatalog.PredictionRepo.GetById(prediction.Id);
            if (dbmodel == null)
            {
                dbmodel = prediction;
                _dataCatalog.PredictionRepo.Create(dbmodel);
            }
            else
            {
                dbmodel.Symptoms = prediction.Symptoms;
                dbmodel.DisorderId = prediction.DisorderId;
                _dataCatalog.PredictionRepo.Update(dbmodel);
            }

            _dataCatalog.UnitOfWork.SaveChanges();
            return dbmodel;
        }
    }



}
