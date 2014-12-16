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

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public IBaseRepository<PatientInfo, string> PatientInfoRepository
        {
            get { return _patientInfoRepository; }
        }

        public IBaseRepository<PatientSigeCaps, string> PatientSigeCapsRepository
        {
            get { return _patientSigeCapsRepository; }
        }


        public PsydptCatalog(DbContext context)
        {
            _unitOfWork = new PsydptUnitOfWork(context);
            _patientInfoRepository = new BaseRepository<PatientInfo, string>(_unitOfWork);
            _patientSigeCapsRepository = new BaseRepository<PatientSigeCaps, string>(_unitOfWork);
        }


        public void Dispose()
        {
            if (_unitOfWork == null) { return; }
            _unitOfWork.Dispose();
        }





      
    }
}
