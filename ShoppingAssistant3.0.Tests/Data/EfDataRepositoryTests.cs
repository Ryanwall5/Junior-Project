using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingAssistant3._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingAssistant3;
using ShoppingAssistant3._0.Models;

namespace ShoppingAssistant3._0.Data.Tests
{
    [TestClass()]
    public class EfDataRepositoryTests
    {
        private IDataRepository _dataRepository;
        public EfDataRepositoryTests(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [TestMethod()]
        public void AddItemTest()
        {
            _dataRepository.AddItem(new Item() { Store = _dataRepository.GetStoreById(1), StoreId = 1, Name = "Cake Mix", Price = 3.57M, Allergens = "Gluten", Aisle = "3", Section = "cakemix", InStock = true, StockAmount = 50 });

            Assert.AreEqual(_dataRepository.GetItem(60).Name, "Cake Mix");
        }

        [TestMethod()]
        public void GetAllItemsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllStoresTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAddressesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAddressByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveItemAndShoppingListLinkTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LookUpItemAndShoppingListGivenItemIdAndShoppingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LookUpShoppingListByNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateShoppingListForUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCurrentUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindItemByNameToLowerCaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindUserShoppingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddItemToItemAndListTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddShoppingListToItemAndListTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddItemToUserRecentlySearchedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetItemTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetShoppingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUsersShoppingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LookUpInUsersListToFindAItemThatsAlreadyInItTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStoreTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStoreTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditStoreTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditStoreTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStoreByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStoreTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveuserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveStoreTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}