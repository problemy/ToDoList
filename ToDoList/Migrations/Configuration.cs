namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ToDoList.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoList.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //SeedUzytkownicy(context);
            
            AddUsers(context);
        }

        void AddUsers(ToDoList.Models.ApplicationDbContext context)
        {
            //var user = new ApplicationUser { UserName = "user1@gmail.com" };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            //um.Create(user, "password");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            const string name = "admin@admin.pl";
            const string password = "Admin123?";
            const string roleName = "Admin";

            var user = um.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = um.Create(user, password);
            }

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var rolesForUser = um.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = um.AddToRole(user.Id, role.Name);
            }

        }
       
        


    }
}
