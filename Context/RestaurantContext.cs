﻿using Models;
using Restaurant.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RestaurantContext, Configuration>());
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<MiniOrder> MiniOrders { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Offer> Offers { get; set; }
    }
}
