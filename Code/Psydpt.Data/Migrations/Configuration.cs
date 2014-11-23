namespace Psydpt.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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
            if (!roleManager.RoleExists("Admin")) { roleManager.Create(new IdentityRole("Admin")); }

            // Adding Admin account
            if (userManager.FindByEmail("admin@admin.com") == null)
            {
                var adminUser = new Entities.AppUser()
                {
                    Email = "admin@admin.com",
                    UserName = "Admin"

                };
                userManager.Create(adminUser, "1qaz2wsx");
                userManager.AddToRole(adminUser.Id, "Admin");
            }

            context.SaveChanges();
        }
    }
}
