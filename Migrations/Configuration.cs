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

                var receipt1 = new Models.Receipt { ReceiptDate = DateTime.ParseExact("2023-09-13 22:46:44.373", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture), Address = "meydan moalem", CustomerNumber = "091000000000", BirunBar = true, Confirm = true, TotalPrice = 704000 };
                var receipt2 = new Models.Receipt { ReceiptDate = DateTime.ParseExact("2023-09-13 22:48:04.923", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture), Address = "piruzi", CustomerNumber = "092000000000", BirunBar = true, Confirm = true, TotalPrice = 374000 };
                var receipt4 = new Models.Receipt { ReceiptDate = DateTime.ParseExact("2023-09-13 23:19:30.893", "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture), Address = "", CustomerNumber = "", BirunBar = false, Confirm = false, TotalPrice = 35200 };
                context.Receipts.Add(receipt1);
                context.Receipts.Add(receipt2);
                context.Receipts.Add(receipt4);

                var offer1 = new Models.Offer { OfferTitle = "tax", OfferCode = null, OfferPercent = 110, OfferDiscount = 0, IsOptional = false };
                var offer2 = new Models.Offer { OfferTitle = "eid", OfferCode = "asd", OfferPercent = 80, OfferDiscount = 0, IsOptional = true };
                context.Offers.Add(offer1);
                context.Offers.Add(offer2);

                var category1 = new Models.FoodCategory { Name = "pizzas" };
                var category3 = new Models.FoodCategory { Name = "preserves" };
                var category4 = new Models.FoodCategory { Name = "juices" };
                context.FoodCategories.Add(category1);
                context.FoodCategories.Add(category3);
                context.FoodCategories.Add(category4);


                var food1 = new Models.Food { Category = category1, Name = "peperoni", Image = "f977e238-541d-4b6e-a95f-87d8f2ce575b.jpg", IsActive = true, Amount = 21, Price = 150000 };
                var food2 = new Models.Food { Category = category1, Name = "gharch o panir", Image = "b87ec3dd-3a27-43e4-85cc-0767f5e0342a.jpg", IsActive = true, Amount = 28, Price = 90000 };
                var food3 = new Models.Food { Category = category3, Name = "jelly", Image = "bdd57ded-7332-403e-987e-3b5bf9cfcf03.jpg", IsActive = true, Amount = 92, Price = 25000 };
                var food4 = new Models.Food { Category = category4, Name = "ab hendune", Image = "a0cb0eea-8736-4772-8b4e-45e74edff846.jpg", IsActive = true, Amount = 47, Price = 20000 };
                var food5 = new Models.Food { Category = category3, Name = "salad shirazi", Image = "e4a7e02d-00b1-4563-8225-60ca6de68663.jpg", IsActive = true, Amount = 61, Price = 30000 };
                context.Foods.Add(food1);
                context.Foods.Add(food2);
                context.Foods.Add(food3);
                context.Foods.Add(food4);
                context.Foods.Add(food5);


                var miniOrder1 = new Models.MiniOrder { Food = food1, quantity = 2, Receipt = receipt1 };
                var miniOrder2 = new Models.MiniOrder { Food = food2, quantity = 3, Receipt = receipt1 };
                var miniOrder3 = new Models.MiniOrder { Food = food3, quantity = 4, Receipt = receipt1 };
                var miniOrder4 = new Models.MiniOrder { Food = food5, quantity = 1, Receipt = receipt1 };
                var miniOrder5 = new Models.MiniOrder { Food = food4, quantity = 5, Receipt = receipt1 };
                var miniOrder6 = new Models.MiniOrder { Food = food1, quantity = 2, Receipt = receipt2 };
                var miniOrder10 = new Models.MiniOrder { Food = food4, quantity = 2, Receipt = receipt2 };
                var miniOrder20 = new Models.MiniOrder { Food = food4, quantity = 2, Receipt = receipt4 };
                context.MiniOrders.Add(miniOrder1);
                context.MiniOrders.Add(miniOrder2);
                context.MiniOrders.Add(miniOrder3);
                context.MiniOrders.Add(miniOrder4);
                context.MiniOrders.Add(miniOrder5);
                context.MiniOrders.Add(miniOrder6);
                context.MiniOrders.Add(miniOrder10);
                context.MiniOrders.Add(miniOrder20);



                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
