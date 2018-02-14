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

namespace ShoppingAssistant3._0.Tests.Controllers
{
    /// <summary>
    /// Summary description for TagsControllerTest
    /// </summary>
    [TestClass]
    public class TagsControllerTest : BaseControllerTest
    {

        private TagsController tagcontroller;

        public TagsControllerTest()
        {      
            tagcontroller = new TagsController(_dataRepository);
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
        public void GetTagByIdTest()
        {
            var item =_dataRepository.GetTagById(2);
            Assert.AreEqual(item.Id, 2);
        }

        [TestMethod]
        public void GetTagByNameTest()
        {
            var item = _dataRepository.GetTagByName("Dairy");
            Assert.AreEqual(item.Name, "Dairy");
        }

        [TestMethod]
        public void TestIndex()
        {
            //var result = tagcontroller.Index() as ViewResult;
            //var view = result.Model as List<Item>;
            //Assert.AreEqual(view.Count, 59);
        }
    }
}
