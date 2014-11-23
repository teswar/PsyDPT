using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Infrastructure
{
    public class PsydptUnitOfWork: IUnitOfWork
    {
       protected readonly DbContext _context;
       private DbContextTransaction _transaction;
       private bool _ownsConnection;


       public DbContext Context
       {
           get { return _context; }
       }


        public PsydptUnitOfWork(DbContext context)
        { 
            _context = context;
            _transaction = _context.Database.BeginTransaction();
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_context == null) { throw new InvalidOperationException("Context has already been disposed !"); }
            _context.Dispose();
        }


    }
}
