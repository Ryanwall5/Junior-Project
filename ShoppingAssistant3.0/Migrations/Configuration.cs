namespace ShoppingAssistant3._0.Migrations
{
    using ShoppingAssistant3._0.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingAssistant3._0.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ShoppingAssistant3._0.Models.ApplicationDbContext context)
        {

            //context.Addresses.AddOrUpdate(
            //Address => Address.Id,
            //new Address { Street = "123 N Street Way", Zip = 97013, City = "Canby", State = "Oregon", Latitude = "45.2664", Longitude = "-122.6767" }
            //);

            //context.Stores.AddOrUpdate(
            //store => store.Id,
            //new Store { Name = "My Store", PhoneNumber = "503-118-2222", EmailAddress = "mystore@mystore.com", AddressId = 1, Address = context.Addresses.Where(x => x.Id == 1).First() }
            //);


            //context.Items.AddOrUpdate(
            //item => item.Id,
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Hot Chocolate", Price = 1.99M, Allergens = "Gluten", Aisle = "1", Section = "cocoa", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Hot Dogs", Price = 1.99M, Allergens = "Gluten", Aisle = "backwall", Section = "hotdogs", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "2% Milk", Price = 3.59M, Allergens = "Milk", Aisle = "backwall", Section = "milk", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Yogurt", Price = 3.59M, Allergens = "Milk", Aisle = "backwall", Section = "yogurt", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Coffee Creamer", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "coffeecreamer", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Mozarella Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Medium Cheddar Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Italian Blend Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chocolate Pudding", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "pudding", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Vanilla Pudding", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "pudding", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Tea", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "tea", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Folgers Coffee", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "coffee", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Starbucks Coffee", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "coffee", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chocolate chip Granola bar", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "granolabars", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Peanut butter Granola bar", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "granolabars", InStock = true, StockAmount = 50 },

            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Syrup", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pancakesupplies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Peanut Butter", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pbandj", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Strawberry Jam", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pbandj", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Captain Crunch", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal1", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Wheaties", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal2", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Frosted flakes", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal3", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Olive oil", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "oliveandvegoil", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Vegtable oil", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "oliveandvegoil", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Sugar cubes", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Sugar", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Flour", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Baking Soda", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Seasoning Salt", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Steak Seasoning", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "chocolate cake mix", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "cakemix", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "brownie mix", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "cakemix", InStock = true, StockAmount = 50 },

            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Pepper", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Foreign Foods", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "foreign", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Marshmellows", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "bakingsupplies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chocolate Chips", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "bakingsupplies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Fruit Cocktail", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Peaches", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Corn", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Green Beans", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "fajita Seasoning mix", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "seasoningpackets", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chili mix", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "seasoningpackets", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Corn Tortillas", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Wheat Tortillas", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Mexican rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Spanish rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chicken rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Fettucini Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Spaghetti Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Pizza Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Wheat Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Vegtable Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Lasagna Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Refried Beans", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "mexandspanish", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Mexican seasonings", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "mexandspanish", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chicken Noodle", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedsoup", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Beef Ravioli", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedmeals", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Chili", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedmeals", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Clam Chowder", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedsoup", InStock = true, StockAmount = 50 },
            //new Item { Store = context.Stores.Where(x => x.Id == 1).First(), StoreId = 1, Name = "Tuna", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "tunaandfish", InStock = true, StockAmount = 50 }
            //);
        }
    }
}
