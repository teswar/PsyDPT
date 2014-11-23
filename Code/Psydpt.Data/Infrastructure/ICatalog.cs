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
        UserManager<AppUser> UserManager { get; }
    }
}
