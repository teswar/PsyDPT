using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
        protected readonly UserManager<Entities.AppUser> _userManager;

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public Microsoft.AspNet.Identity.UserManager<Entities.AppUser> UserManager
        {
            get { return _userManager; }
        }

        public PsydptCatalog(DbContext context)
        {
            _unitOfWork = new PsydptUnitOfWork(context);
            _userManager = new UserManager<Entities.AppUser>(new UserStore<Entities.AppUser>(context));
        }


        public void Dispose()
        {
            if (_unitOfWork == null) { return; }
            _userManager.Dispose();
            _unitOfWork.Dispose();
        }
    }
}
