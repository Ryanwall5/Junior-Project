using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingAssistant3._0;
using ShoppingAssistant3._0.Controllers;
using ShoppingAssistant3._0.Data;
using ShoppingAssistant3._0.Models;
using Moq;
using Microsoft.AspNet.Identity;
using System.Web.Script.Serialization;

namespace ShoppingAssistant3._0.Tests.Controllers
{
    /// <summary>
    /// Summary description for ItemControllerTest
    /// </summary>
    [TestClass]
    public class ItemControllerTest : BaseControllerTest
    {

        private ItemController itemcontroller;

        public ItemControllerTest()
        {

            itemcontroller = new ItemController(_dataRepository);

        }

        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllItems()
        {
            var items = _dataRepository.GetAllItems();

            Assert.AreEqual(59, items.Count);
        }

        [TestMethod]
        public void GetAllItemById()
        {
            var items = _dataRepository.GetItem(5);

            Assert.AreEqual(items.Id, 5);
        }

        [TestMethod]
        public void AddItem()
        {
            Item item = new Item { Store = _dataRepository.GetAllStores().FirstOrDefault(s => s.Id == 1), StoreId = 1, Name = "Hot Chocolate", Price = 1.99M, Allergens = "Gluten", Aisle = "1", Section = "cocoa", InStock = true, StockAmount = 50 };
            _dataRepository.AddItem(item);

            var items = _dataRepository.GetItem(60);

            Assert.AreEqual(items.Id, 60);
        }

        [TestMethod]
        public void FindItemToLowerTest()
        {
            var items = _dataRepository.FindItemByNameToLowerCase("Yogurt");
            Assert.AreEqual(items.Name, "Yogurt");

        }

        [TestMethod]
        public void TestIndex()
        {
            var result = itemcontroller.Index() as ViewResult;
            var view = result.Model as List<Item>;
            Assert.AreEqual(view.Count, 59);
        }


        [TestMethod]
        public void ItemSearhTest()
        {
            var result = (RedirectToRouteResult)itemcontroller.ItemSearch(null);
            var routevalues = result.RouteValues;
            var routename = result.RouteName;

            var routevaluesindex = result.RouteValues["action"];
            var routevalueshome = result.RouteValues["controller"];

            Assert.AreEqual("Index", routevaluesindex);
            Assert.AreEqual("Home", routevalueshome);

        }

        [TestMethod]
        public void GetItemInSectionTest()
        {
            var result = (JsonResult)itemcontroller.GetItemsInSection("cakemix");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual(2, values.itemsfound.Count);
        }

        [TestMethod]
        public void GetItemInSectionTestBadSectionNameReturnsJSONErrorMessage()
        {
            var result = (JsonResult)itemcontroller.GetItemsInSection("asfdsafd");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("Did not find any items for that given section", values.error);
        }

        [TestMethod]
        public void GetItemInSectionTestSectionNameIsNullReturnsJSONErrorMessage()
        {
            var result = (JsonResult)itemcontroller.GetItemsInSection(null);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("Section name was null or empty", values.error);
        }
    }
}
