namespace Psydpt.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Psydpt.Data.Entities;
    using Psydpt.Data.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Psydpt.Data.PsydptContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Psydpt.Data.PsydptContext";
        }

        protected override void Seed(Psydpt.Data.PsydptContext context)
        {
            //  This method will be called after migrating to the latest version.
            var userManager = new UserManager<Entities.AppUser>(new UserStore<Entities.AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Adding Roles
            #region Roles

            var roles = new List<IdentityRole>();
            roles.Add(new IdentityRole(UserRole.Admin.ToString()));
            roles.Add(new IdentityRole(UserRole.Patient.ToString()));
   
            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role.Name)) { roleManager.Create(role); }
            }

            #endregion


            // Adding Admin account
            #region Users

            if (userManager.FindByEmail("admin@psydpt.com") == null)
            {
                var adminUser = new Entities.AppUser()
                {
                    Email = "admin@psydpt.com",
                    UserName = "Admin"
                };
                userManager.Create(adminUser, "1qaz2wsx");
                userManager.AddToRole(adminUser.Id, UserRole.Admin.ToString());
            }

            if (userManager.FindByEmail("patient@psydpt.com") == null)
            {
                var adminUser = new Entities.AppUser()
                {
                    Email = "patient@psydpt.com",
                    UserName = "Patient"
                };
                userManager.Create(adminUser, "1qaz2wsx");
                userManager.AddToRole(adminUser.Id, UserRole.Patient.ToString());
            }

            #endregion

            context.SaveChanges();
        }
    }
}
