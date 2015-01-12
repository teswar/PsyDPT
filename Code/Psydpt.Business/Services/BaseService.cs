using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Psydpt.Data;
using Psydpt.Data.Entities;
using Psydpt.Business.Infrastructure;
using Psydpt.Data.Infrastructure;

namespace Psydpt.Business.Services
{
    public abstract class BaseService 
    {
        protected readonly ICatalog _dataCatalog;

        public BaseService(ICatalog dataCatalog)
        {
            if (dataCatalog == null) { throw new ArgumentNullException("unitOfWork", "Cant initialize service with invalid UnifOfWork"); }

            _dataCatalog = dataCatalog;
        }

    }



}
