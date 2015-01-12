using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Infrastructure
{
    public class PsydptCatalog : ICatalog
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly BaseRepository<PatientInfo, string> _patientInfoRepository;
        protected readonly BaseRepository<PatientSigeCaps, string> _patientSigeCapsRepository;
        protected readonly BaseRepository<Disorder, Guid> _disorderRepository;
        protected readonly BaseRepository<Prediction, Guid> _predictionRepository;
        protected readonly BaseRepository<PredictionPuntuation, Guid> _predictionPuntuationRepository;
        protected readonly BaseRepository<PredictionSetting, Guid> _predictionSettingRepository;


        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public IBaseRepository<PatientInfo, string> PatientInfoRepo
        {
            get { return _patientInfoRepository; }
        }

        public IBaseRepository<PatientSigeCaps, string> PatientSigeCapsRepo
        {
            get { return _patientSigeCapsRepository; }
        }


        public IBaseRepository<Disorder, Guid> DisordersRepo
        {
            get { return _disorderRepository; }
        }

        public IBaseRepository<Prediction, Guid> PredictionRepo
        {
            get { return _predictionRepository; }
        }
        
        public IBaseRepository<PredictionPuntuation, Guid> PredictionPuntuationRepo
        {
            get { return _predictionPuntuationRepository; }
        }

        public IBaseRepository<PredictionSetting, Guid> PredictionSettingRepo
        {
            get { return _predictionSettingRepository; }
        }


        public PsydptCatalog(DbContext context)
        {
            _unitOfWork = new PsydptUnitOfWork(context);
            _patientInfoRepository = new BaseRepository<PatientInfo, string>(_unitOfWork);
            _patientSigeCapsRepository = new BaseRepository<PatientSigeCaps, string>(_unitOfWork);
            _disorderRepository = new BaseRepository<Disorder, Guid>(_unitOfWork);
            _predictionRepository = new BaseRepository<Prediction, Guid>(_unitOfWork);
            _predictionPuntuationRepository = new BaseRepository<PredictionPuntuation, Guid>(_unitOfWork);
            _predictionSettingRepository = new BaseRepository<PredictionSetting, Guid>(_unitOfWork);
        }


        public void Dispose()
        {
            if (_unitOfWork == null) { return; }
            _unitOfWork.Dispose();
        }










    }
}
