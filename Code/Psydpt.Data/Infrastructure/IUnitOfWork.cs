using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Infrastructure
{
    public interface IUnitOfWork: IDisposable
    {
        DbContext Context { get; }

        int SaveChanges();
        void DiscardChanges();
    }

}
