namespace Restaurant.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.RestaurantContext context)
        {

            if (!context.Roles.Any())
            {
                var role = new Models.Role { RoleName = "Admin", RoleTitle = "Admin" };
                var user = new User { UserName = "Admin", FullName = "Admin", Role = role, Password = "21232F297A57A5A743894A0E4A801FC3" };
                context.Roles.Add(role);
                context.Users.Add(user);

                var role2 = new Models.Role { RoleName = "Cashier", RoleTitle = "Cashier" };
                var user2 = new User { UserName = "Cashier", FullName = "Cashier", Role = role2, Password = "6AC2470ED8CCF204FD5FF89B32A355CF" };
                context.Roles.Add(role2);
                context.Users.Add(user2);

                var role3 = new Models.Role { RoleName = "Receptor", RoleTitle = "Receptor" };
                var user3 = new User { UserName = "Receptor", FullName = "Receptor", Role = role3, Password = "3387E2E42B368C871C954EDA32EC19EB" };
                context.Roles.Add(role3);
                context.Users.Add(user3);
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
