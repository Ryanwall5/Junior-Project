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
    [TestClass]
    public class HomeControllerTest : BaseControllerTest
    {
        private HomeController homecontroller;
        
   
        public HomeControllerTest()
        {      
            homecontroller = new HomeController(_dataRepository);
        }


  
        [TestMethod()]
        public void AddNullItemToDatabaseAndItemDoesNotGetAdded()
        {
            IList<Item> items = new List<Item>();
            _dataRepository.AddItem(new Item());
          

            items = _dataRepository.GetAllItems();

            Assert.AreEqual(59, items.Count);
        }

        [TestMethod()]
        public void GetAllItems()
        {
           
            var items = _dataRepository.GetAllItems();

            Assert.AreEqual(59, items.Count);
        }


        [TestMethod()]
        public void GetAnAddressById()
        {
           Address a = _dataRepository.GetAddressById(1);

      
            Assert.AreEqual(1, a.Id);
        }



        [TestMethod()]
        public void GetAnAddressByIdDoesntFindAddress()
        {
            Address a = _dataRepository.GetAddressById(2);


            Assert.IsNull(a, "Item Was Not Found In The Database");
        }


        [TestMethod()]
        public void GetAUserById()
        {
            ApplicationUser user = _dataRepository.GetCurrentUser("1");


            Assert.AreEqual("ryan.wall@oit.edu", user.UserName);
        }

        [TestMethod()]
        public void GetAUserByIdReturnsNull()
        {
            ApplicationUser user = _dataRepository.GetCurrentUser("2");


            Assert.IsNull(user, "Item Was Not Found In The Database");
        }



        [TestMethod()]
        public void HomeControllerIndex()
        {

            var result =  homecontroller.Index();

            
            //Assert.AreEqual();
        }


        [TestMethod()]
        public void HomeControllerUserIndex()
        {

            var result = (ViewResult)homecontroller.UserIndex();
           
            
            Assert.AreEqual("My Store", result.ViewBag);
        }

        [TestMethod()]
        public void HomeControllerDisplayRandomItems()
        {

            var result = (PartialViewResult)homecontroller.DisplayRandomItems();
            var collection = (List<ItemViewModel>)(result.ViewData.Model);


            Assert.AreEqual(3, collection.Count);
            Assert.AreEqual("_Displaythreeranditems", result.ViewName);
           // Assert.AreEqual("_Displaythreeranditems", result.view);
        }

    }
}
