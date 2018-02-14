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
using System.Web.Routing;

namespace ShoppingAssistant3._0.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    /// 




    [TestClass]
    public class StoreControllerTest : BaseControllerTest
    {
        private StoreController storeController;
        public StoreControllerTest()
        {
            storeController = new StoreController(_dataRepository);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        public void BuildAStoreTestStoreViewDataCount()
        {

            var result = (ViewResult)storeController.BuildAStore();

            var valueofviewdata = result.ViewData.ToList();
            var key = valueofviewdata[0].Key;
            var ValueType = valueofviewdata[0].Value;

            //Assert.AreEqual("My Store", );
            Assert.AreEqual("StoreName", key);
            Assert.AreEqual(1, result.ViewData.Count);
        }


        [TestMethod]
        public void AddSectionToStoreMapTestEmptyStringsReturnSuccessFalse()
        {

            var result = (JsonResult)storeController.AddSectionToStoreMap("", "", 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));


            Assert.IsFalse(values.success);
        }

        [TestMethod]
        public void AddSectionToStoreMapTestNullStringsReturnSuccessFalse()
        {

            var result = (JsonResult)storeController.AddSectionToStoreMap(null, null, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));


            Assert.IsFalse(values.success);
        }

        [TestMethod]
        public void AddSectionToStoreMapTestSuccessIsTrue()
        {

            var result = (JsonResult)storeController.AddSectionToStoreMap("2", "2_2_10_10", 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual(2, values.data.Id);
            Assert.AreEqual("2", values.data.Name);
            Assert.AreEqual(2, values.data.Number);
            Assert.AreEqual(2, values.data.ShelfName);
            Assert.AreEqual(10, values.data.Xcoord);
            Assert.AreEqual(10, values.data.Ycoord);
            Assert.IsTrue(values.success);
        }

        [TestMethod]
        public void CreateStoreMapTestAislesEqualsZero()
        {

            var result = (JsonResult)storeController.CreateStoreMap(0, 4, 5, false, false, false, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("Aisles, Sections and/or Shelves equals zero. They all must be greater than zero.", values.error);
        }

        [TestMethod]
        public void CreateStoreMapTestSectionsEqualsZero()
        {

            var result = (JsonResult)storeController.CreateStoreMap(4, 1, 0, false, false, false, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("Aisles, Sections and/or Shelves equals zero. They all must be greater than zero.", values.error);
        }

        [TestMethod]
        public void CreateStoreMapTestShelvesEqualsZero()
        {

            var result = (JsonResult)storeController.CreateStoreMap(4, 0, 5, false, false, false, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("Aisles, Sections and/or Shelves equals zero. They all must be greater than zero.", values.error);
        }


        [TestMethod]
        public void CreateStoreMapTestStoreIdIsNotInDatabase()
        {

            var result = (JsonResult)storeController.CreateStoreMap(4, 4, 5, false, false, false, 4);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual("The store was not found", values.error);
        }

        [TestMethod]
        public void CreateStoreMapTestStoreSuccessIsTrueAndStoreMapCountIsTwoAndShelvesCountIsSeven()
        {

            var result = (JsonResult)storeController.CreateStoreMap(4, 4, 5, false, false, false, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));
            Assert.AreEqual(2, _dataRepository.GetAllStoreMaps().Count);
            Assert.AreEqual(7, _dataRepository.GetAllShelves().Count);
            Assert.IsTrue(values.success);
        }

        [TestMethod]
        public void CreateStoreMapTestStoreSuccessIsTrueAndCheckAllDataOfCreatedStoreMap()
        {

            var result = (JsonResult)storeController.CreateStoreMap(4, 4, 5, false, false, true, 1);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));
            Assert.AreEqual(4, _dataRepository.GetStoreMapById(2).Aisles);
            Assert.AreEqual(4, _dataRepository.GetStoreMapById(2).ShelvesCount);
            Assert.IsFalse(_dataRepository.GetStoreMapById(2).BackWall);
            Assert.IsFalse(_dataRepository.GetStoreMapById(2).RightSection);
            Assert.IsTrue(_dataRepository.GetStoreMapById(2).LeftSection);

            Assert.IsTrue(values.success);
        }

        [TestMethod]
        public void GetAllStoreNamesReturnsOneStore()
        {

            var result = (JsonResult)storeController.GetAllStoreNames();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForJsonResults values = serializer.Deserialize<ForJsonResults>(serializer.Serialize(result.Data));

            Assert.AreEqual(1, values.storenames.Count);
        }

        [TestMethod]
        public void StoreSearchStoreNameIsEmptyAndRedirectsToActionIndexHome()
        {
            var result = (RedirectToRouteResult)storeController.StoreSearch("");

            var routename = result.RouteName;

            var routevaluesarea = result.RouteValues["area"];
            var routevaluesindex = result.RouteValues["action"];
            var routevalueshome = result.RouteValues["controller"];
               
            Assert.AreEqual("", routevaluesarea);
            Assert.AreEqual("Index", routevaluesindex);
            Assert.AreEqual("Home", routevalueshome);
        }

        [TestMethod]
        public void StoreSearchStoreNameIsNullAndRedirectsToActionIndexHome()
        {
            var result = (RedirectToRouteResult)storeController.StoreSearch(null);

            var routename = result.RouteName;

            var routevaluesarea = result.RouteValues["area"];
            var routevaluesindex = result.RouteValues["action"];
            var routevalueshome = result.RouteValues["controller"];

            Assert.AreEqual("", routevaluesarea);
            Assert.AreEqual("Index", routevaluesindex);
            Assert.AreEqual("Home", routevalueshome);
        }

        
    }
}
