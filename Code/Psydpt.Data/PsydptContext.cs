using Microsoft.AspNet.Identity.EntityFramework;
using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data
{
    public class PsydptContext : IdentityDbContext<AppUser>
    {
        public PsydptContext()
            : base("PsydptConnection")
        {
            //AutomaticMigrationsEnabled = false;
            //Configuration.LazyLoadingEnabled = true;
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
