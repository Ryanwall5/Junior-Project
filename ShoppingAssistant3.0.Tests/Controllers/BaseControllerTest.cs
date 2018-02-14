using ShoppingAssistant3._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingAssistant3._0;
using ShoppingAssistant3._0.Controllers;
using ShoppingAssistant3._0.Models;
using Moq;
using Microsoft.AspNet.Identity;


namespace ShoppingAssistant3._0.Tests.Controllers
{

    public class ForJsonResults
    {
        public bool success;
        public string error;
        public Section data;
        public List<Store> storenames;
        public List<Item> itemsfound;
    }

    [TestClass]
    public abstract class BaseControllerTest
    {
        public virtual IDataRepository _dataRepository { get; private set; }


        public BaseControllerTest()
        {
            Initialize();
        }


        public virtual void Initialize()
        {
            var db = new Mock<IDataRepository>();


            var email = "ryan.wall@oit.edu";
            var password = "Beavers522!";

            var passwordhasher = new PasswordHasher();
            var hashed = passwordhasher.HashPassword(password);





            //----------------------------------address start--------------------------------------------------------------------------

            // addresses list
            var addresses = new List<Address>()
            {
                new Address {
                    Id = 1,
                Street = "123 N Street Way",
                City = "Canby",
                State = "Oregon",
                Zip = 97013,
                Latitude = "45.2664",
                Longitude = "-122.6767"
                }
            };
            // get all addresses
            db.Setup(address => address.GetAllAddresses()).Returns(addresses);
            _dataRepository = db.Object;


            //get address by ID
            db.Setup(x => x.GetAddressById(It.IsAny<int>()))
                .Returns((int id) => { return addresses.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;

            //----------------------------------address end--------------------------------------------------------------------------



            //----------------------------------stores start--------------------------------------------------------------------------
            // stores list
            var stores = new List<Store>()
            {
                new Store{ Id= 1, Name = "My Store", PhoneNumber = "503-118-2222", EmailAddress = "mystore@mystore.com", AddressId = 1, Address = _dataRepository.GetAllAddresses().Where(x => x.Id == 1).First() }
            };




            // get all stores
            db.Setup(store => store.GetAllStores()).Returns(stores);
            _dataRepository = db.Object;


            // add store
            db.Setup(store => store.AddStore(It.IsAny<Store>()))
                   .Callback((Store store) =>
                   {
                       if (store == null)
                       {

                       }
                       else
                       {
                           Store s = new Store();

                           s = store;

                           stores.Add(s);
                       }
                   });
            _dataRepository = db.Object;

            //get store by id
            db.Setup(x => x.GetStoreById(It.IsAny<int>()))
               .Returns((int id) => { return stores.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;

            //----------------------------------stores end --------------------------------------------------------------------------


            //----------------------------------items--------------------------------------------------------------------------

            var items = new List<Item>()
            {

            new Item { Id = 1, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Hot Chocolate", Price = 1.99M, Allergens = "Gluten", Aisle = "1", Section = "cocoa", InStock = true, StockAmount = 50 },
            new Item { Id = 2, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Hot Dogs", Price = 1.99M, Allergens = "Gluten", Aisle = "backwall", Section = "hotdogs", InStock = true, StockAmount = 50 },
            new Item { Id = 3, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), Name = "2% Milk", Price = 3.59M, Allergens = "Milk", Aisle = "backwall", Section = "milk", InStock = true, StockAmount = 50 },
            new Item { Id = 4, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Yogurt", Price = 3.59M, Allergens = "Milk", Aisle = "backwall", Section = "yogurt", InStock = true, StockAmount = 50 },
            new Item { Id = 5, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Coffee Creamer", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "coffeecreamer", InStock = true, StockAmount = 50 },
            new Item { Id = 6, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Mozarella Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            new Item { Id = 7, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Medium Cheddar Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            new Item { Id = 8, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Italian Blend Cheese", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "cheese", InStock = true, StockAmount = 50 },
            new Item { Id = 9, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chocolate Pudding", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "pudding", InStock = true, StockAmount = 50 },
            new Item { Id = 10, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Vanilla Pudding", Price = 3.59M, Allergens = "Gluten", Aisle = "backwall", Section = "pudding", InStock = true, StockAmount = 50 },
            new Item { Id = 11, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Tea", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "tea", InStock = true, StockAmount = 50 },
            new Item { Id = 12, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Folgers Coffee", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "coffee", InStock = true, StockAmount = 50 },
            new Item { Id = 13, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Starbucks Coffee", Price = 3.59M, Allergens = "Gluten", Aisle = "1", Section = "coffee", InStock = true, StockAmount = 50 },
            new Item { Id = 14, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chocolate chip Granola bar", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "granolabars", InStock = true, StockAmount = 50 },
            new Item { Id = 15, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Peanut butter Granola bar", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "granolabars", InStock = true, StockAmount = 50 },

            new Item { Id = 16, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Syrup", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pancakesupplies", InStock = true, StockAmount = 50 },
            new Item { Id = 17, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Peanut Butter", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pbandj", InStock = true, StockAmount = 50 },
            new Item { Id = 18, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Strawberry Jam", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "pbandj", InStock = true, StockAmount = 50 },
            new Item { Id = 19, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Captain Crunch", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal1", InStock = true, StockAmount = 50 },
            new Item { Id = 20, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Wheaties", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal2", InStock = true, StockAmount = 50 },
            new Item { Id = 21, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Frosted flakes", Price = 3.59M, Allergens = "Gluten", Aisle = "2", Section = "cereal3", InStock = true, StockAmount = 50 },
            new Item { Id = 22, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Olive oil", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "oliveandvegoil", InStock = true, StockAmount = 50 },
            new Item { Id = 23, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Vegtable oil", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "oliveandvegoil", InStock = true, StockAmount = 50 },
            new Item { Id = 24, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Sugar cubes", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            new Item { Id = 25, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Sugar", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            new Item { Id = 26, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Flour", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            new Item { Id = 27, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Baking Soda", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "sugarandflour", InStock = true, StockAmount = 50 },
            new Item { Id = 28, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Seasoning Salt", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            new Item { Id = 29, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Steak Seasoning", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            new Item { Id = 30, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "chocolate cake mix", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "cakemix", InStock = true, StockAmount = 50 },
            new Item { Id = 31, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "brownie mix", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "cakemix", InStock = true, StockAmount = 50 },

            new Item { Id = 32, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Pepper", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "spices", InStock = true, StockAmount = 50 },
            new Item { Id = 33, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Foreign Foods", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "foreign", InStock = true, StockAmount = 50 },
            new Item { Id = 34, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Marshmellows", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "bakingsupplies", InStock = true, StockAmount = 50 },
            new Item { Id = 35, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chocolate Chips", Price = 3.59M, Allergens = "Gluten", Aisle = "3", Section = "bakingsupplies", InStock = true, StockAmount = 50 },
            new Item { Id = 36, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Fruit Cocktail", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            new Item { Id = 37, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Peaches", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            new Item { Id = 38, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Corn", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            new Item { Id = 39, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Green Beans", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "fruitandveggies", InStock = true, StockAmount = 50 },
            new Item { Id = 40, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "fajita Seasoning mix", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "seasoningpackets", InStock = true, StockAmount = 50 },
            new Item { Id = 41, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chili mix", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "seasoningpackets", InStock = true, StockAmount = 50 },
            new Item { Id = 42, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Corn Tortillas", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            new Item { Id = 43, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Wheat Tortillas", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            new Item { Id = 44, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Mexican rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            new Item { Id = 45, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Spanish rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            new Item { Id = 46, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chicken rice", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "tortillasandrice", InStock = true, StockAmount = 50 },
            new Item { Id = 47, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Fettucini Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            new Item { Id = 48, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Spaghetti Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            new Item { Id = 49, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Pizza Sauce", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "sauce", InStock = true, StockAmount = 50 },
            new Item { Id = 50, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Wheat Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            new Item { Id = 51, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Vegtable Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            new Item { Id = 52, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Lasagna Noodles", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "packagednoodles", InStock = true, StockAmount = 50 },
            new Item { Id = 53, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Refried Beans", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "mexandspanish", InStock = true, StockAmount = 50 },
            new Item { Id = 54, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Mexican seasonings", Price = 3.59M, Allergens = "Gluten", Aisle = "4", Section = "mexandspanish", InStock = true, StockAmount = 50 },
            new Item { Id = 55, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chicken Noodle", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedsoup", InStock = true, StockAmount = 50 },
            new Item { Id = 56, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Beef Ravioli", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedmeals", InStock = true, StockAmount = 50 },
            new Item { Id = 57, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Chili", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedmeals", InStock = true, StockAmount = 50 },
            new Item { Id = 58, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Clam Chowder", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "cannedsoup", InStock = true, StockAmount = 50 },
            new Item { Id = 59, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Tuna", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "tunaandfish", InStock = true, StockAmount = 50 }
            };

            


            // get all items 
            db.Setup(item => item.GetAllItems()).Returns(items);
            _dataRepository = db.Object;

            // add item
            db.Setup(item => item.AddItem(It.IsAny<Item>()))
                 .Callback((Item item) =>
                 {
                     if (item.Aisle == null && item.Allergens == null && item.Id == 0 &&
                        item.InStock == false && item.ItemAndLists.Count == 0 && item.Name == null &&
                        item.Price == 0 && item.Section == null && item.StockAmount == 0 &&
                        item.Store == null && item.StoreId == 0)
                     {

                     }
                     else
                     {
                         item.Id = _dataRepository.GetAllItems().Last().Id + 1;

                         Item i = new Item();
                         
                         i = item;
                         
                         items.Add(i);
                     }
                 });

            //get item by id
            db.Setup(x => x.GetItem(It.IsAny<int>()))
               .Returns((int id) => { return items.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;

            //find item tolower
            db.Setup(x => x.FindItemByNameToLowerCase(It.IsAny<string>()))
                .Returns((string s) => { return items.SingleOrDefault(r => r.Name == s); });
            _dataRepository = db.Object;
            //----------------------------------items end--------------------------------------------------------------------------


            //----------------------------------users--------------------------------------------------------------------------

            var users = new List<ApplicationUser>()
            {
               new ApplicationUser{Id = "1", HomeStore = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), HomeStoreId = 1, RecentlySearchedItems = new List<Item>(), UserName = email, Email = email, PasswordHash =  hashed}
            };

            db.Setup(user => user.GetAllUsers()).Returns(users);
            _dataRepository = db.Object;

            //get user by id
            db.Setup(user => user.GetCurrentUser(It.IsAny<String>()))
               .Returns((string id) => { return users.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;

            //---------------------------------users end------------------------------------------------------------


            // ---------------------sections -------------------------------------------

            var sections = new List<Section>()
            {
                //shelf one leftside
                new Section("1", "1_1_10_10_50_50") { Id = 1 },
                new Section("2", "1_2_10_20_50_50") { Id = 2 },
                new Section("3", "1_3_10_30_50_50") { Id = 3 },
                new Section("4", "1_4_10_40_50_50") { Id = 4 },
                new Section("5", "1_5_10_50_50_50") { Id = 5 },

                //shelf one rightside
                new Section("6", "1_6_20_10_50_50") { Id = 6 },
                new Section("7", "1_7_20_20_50_50") { Id = 7 },
                new Section("8", "1_8_20_30_50_50") { Id = 8 },
                new Section("9", "1_9_20_40_50_50") { Id = 9 },
                new Section("10", "1_10_20_50_50_50") { Id = 10 },
     

                //shelf two leftside
                new Section("1", "2_1_40_10_50_50") { Id = 11 },
                new Section("2", "2_2_40_20_50_50") { Id = 12 },
                new Section("3", "2_3_40_30_50_50") { Id = 13 },
                new Section("4", "2_4_40_40_50_50") { Id = 14 },
                new Section("5", "2_5_40_50_50_50") { Id = 15 },
               

                //shelf two rightside
                new Section("6", "2_6_50_10_50_50") { Id = 16 },
                new Section("7", "2_7_50_20_50_50") { Id = 17 },
                new Section("8", "2_8_50_30_50_50") { Id = 18 },
                new Section("9", "2_9_50_40_50_50") { Id = 19 },
                new Section("10", "2_10_50_50_50_50") { Id = 20 },
            
                //shelf three leftside
                new Section("1", "3_1_70_10_50_50") { Id = 21 },
                new Section("2", "3_2_70_20_50_50") { Id = 22},
                new Section("3", "3_3_70_30_50_50") { Id = 23 },
                new Section("4", "3_4_70_40_50_50") { Id = 24 },
                new Section("5", "3_5_70_50_50_50") { Id = 25 },
             

                   //shelf three rightside
                new Section("6", "3_6_70_10_50_50") { Id = 26 },
                new Section("7", "3_7_70_20_50_50") { Id = 27 },
                new Section("8", "3_8_70_30_50_50") { Id = 28 },
                new Section("9", "3_9_70_40_50_50") { Id = 29 },
                new Section("10", "3_10_70_50_50_50") { Id = 30 },
            };

            db.Setup(section => section.GetAllSections()).Returns(sections);
            _dataRepository = db.Object;


            db.Setup(sec => sec.AddSection(It.IsAny<Section>()))
                 .Callback((Section section) =>
                 {

                     section.Id = _dataRepository.GetAllSections().Last().Id + 1;

                     Section s = new Section();

                     s = section;

                     sections.Add(s);

                 });

            _dataRepository = db.Object;
            // ---------------------sections end -------------------------------------------
     
            // ---------------------Shelves -------------------------------------------

            var shelves = new List<Shelf>()
            {
                new Shelf("1", 5) { Id = 1 },
                new Shelf("2", 5) { Id = 2 },
                new Shelf("3", 5) { Id = 3 },
            }; 

            db.Setup(section => section.GetAllShelves()).Returns(shelves);
            _dataRepository = db.Object;


            db.Setup(sec => sec.AddShelf(It.IsAny<Shelf>()))
                 .Callback((Shelf shelf) =>
                 {

                     shelf.Id = _dataRepository.GetAllShelves().Last().Id + 1;

                     Shelf s = new Shelf(shelf.Name, shelf.SectionCount);

                     s = shelf;

                     shelves.Add(s);

                 });

            _dataRepository = db.Object;
            // ---------------------Shelves end -------------------------------------------

         


            // ---------------------Store Maps -------------------------------------------

            var storemaps = new List<StoreMap>()
            {
                new StoreMap(4, 3, false, false, false) { Id = 1 },

            };

       

            db.Setup(section => section.GetAllStoreMaps()).Returns(storemaps);
            _dataRepository = db.Object;


            db.Setup(sec => sec.CreateStoreMapWithShelves(It.IsAny<StoreMap>(), It.IsAny<int>(), It.IsAny<Store>()))
                 .Callback((StoreMap map, int secs, Store store) =>
                 {
                     map.Id = storemaps.Last().Id + 1;
                     var count = 1;
                     for (int i = 0; i < map.ShelvesCount; i++)
                     {
                         Shelf shelf = new Shelf(count.ToString(), secs);
                         shelves.Add(shelf);
                         map.Shelves.Add(shelf);
                         count++;
                     }


                     if (map.BackWall)
                     {
                         Shelf shelf = new Shelf("backwall", secs);
                         shelves.Add(shelf);
                         map.Shelves.Add(shelf);
                     }
                     if (map.RightSection)
                     {
                         Shelf shelf = new Shelf("Right", secs);
                         shelves.Add(shelf);
                         map.Shelves.Add(shelf);
                     }
                     if (map.LeftSection)
                     {
                         Shelf shelf = new Shelf("Left", secs);
                         shelves.Add(shelf);
                         map.Shelves.Add(shelf);
                     }

                     storemaps.Add(map);
                 });

            _dataRepository = db.Object;

            db.Setup(x => x.GetStoreMapById(It.IsAny<int>()))
               .Returns((int id) => { return storemaps.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;


            // ---------------------Store Maps end -------------------------------------------

            // ---------------------Tags -------------------------------------------
            var tag = new List<Tag>()
            {
                new Tag { Id = 2, Name = "Dairy" }
            };
            var tagitem = new Item { Id = 60, Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Milk", Price = 3.59M, Allergens = "Gluten", Aisle = "5", Section = "tunaandfish", InStock = true, StockAmount = 50 };
            var it = new List<ItemAndTag>()
            {
               new ItemAndTag { Id = 1, Item = tagitem , Tag = tag.FirstOrDefault(), ItemId = 60}
            };
           // tagitem.ItemAndTags.Add(it.FirstOrDefault());

            db.Setup(x => x.GetTagById(It.IsAny<int>()))
                .Returns((int id) => { return tag.SingleOrDefault(r => r.Id == id); });
            _dataRepository = db.Object;

            db.Setup(x => x.GetTagByName(It.IsAny<string>()))
                .Returns((string name) => { return tag.SingleOrDefault(r => r.Name == name); });
            // ---------------------Tags end -------------------------------------------

            // ---------------------Shopping List -------------------------------------------

            var shoppinglist = new List<ShoppingList>()
            {
                new ShoppingList {}
            };

        }
    }
}
