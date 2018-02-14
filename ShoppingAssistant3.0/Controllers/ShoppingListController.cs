using Microsoft.AspNet.Identity;
using ShoppingAssistant3._0.Data;
using ShoppingAssistant3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingAssistant3._0.Controllers
{
    public class ShoppingListController : Controller
    {
       // private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly IDataRepository _dataRepository;

        public ShoppingListController(IDataRepository datarepository)
        {
            _dataRepository = datarepository;
        }


        // GET: ShoppingList
        public ActionResult AddToShoppingList(string item, int listId)
        {

            var currentuserid = User.Identity.GetUserId();
            var user = _dataRepository.GetCurrentUser(currentuserid);

            var errormsg = "";

            var items = _dataRepository.GetAllItems();


            if (!String.IsNullOrEmpty(item) && _dataRepository.FindItemByNameToLowerCase(item) != null)
            {

               
                var theitem = _dataRepository.FindItemByNameToLowerCase(item);

                var thelist = _dataRepository.FindUserShoppingList(user ,listId);
                //var thelist = user.ShoppingLists.Where(sl => sl.Id == listId).First();

                if (thelist.ItemsAndLists.FirstOrDefault(x => x.Item.Name == theitem.Name) != null)
                {
                    errormsg += item + " was already added to the " + thelist.Name + " list.";
                    return Json(new { found = false, error = errormsg }, JsonRequestBehavior.AllowGet);
                }

                ItemAndShoppingList iands = new ItemAndShoppingList
                {
                    Item = theitem,
                    ItemId = theitem.Id,
                    ShoppingList = thelist,
                    ShoppingListId = thelist.Id,
                    QuantityBought = 1
                };


                ItemViewModel i = new ItemViewModel
                {
                    Id = theitem.Id,
                    Name = theitem.Name,
                    Price = theitem.Price,
                    InStock = theitem.InStock,
                    StockAmount = theitem.StockAmount,
                    Aisle = theitem.Aisle,
                    Section = theitem.Section,
                    Allergens = theitem.Allergens
                };

                _dataRepository.AddItemToItemAndListTable(theitem, iands);

                _dataRepository.AddShoppingListToItemAndListTable(thelist, iands);
                //thelist.ItemsAndLists.Add(iands);
                //theitem.ItemAndLists.Add(iands);


                //_db.SaveChanges();

                return Json(new { found = true, itemfound = theitem.Name, sectionofitem = theitem.Section, list = thelist.Name }, JsonRequestBehavior.AllowGet);
                //return Json(new { found = true, itemfound = theitem.Name, list = thelist.Name }, JsonRequestBehavior.AllowGet);
            }
            errormsg += item + " was not found in our database";
            return Json(new { found = false, error = errormsg }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddToShoppingListWithItemId(int theitemid, int listId)
        {

            var currentuserid = User.Identity.GetUserId();
            var user = _dataRepository.GetCurrentUser(currentuserid);

            var errormsg = "";
            
            if (_dataRepository.GetItem(theitemid) != null)
            {
                var theitem = _dataRepository.GetItem(theitemid);
                var thelist = _dataRepository.FindUserShoppingList(user, listId);
                //var thelist = user.ShoppingLists.Where(sl => sl.Id == listId).First();

                

                if (_dataRepository.LookUpInUsersListToFindAItemThatsAlreadyInIt(thelist, theitem.Name) != null)
                {
                    errormsg += theitem.Name + " was already added to the " + thelist.Name + " list.";
                    return Json(new { found = false, error = errormsg }, JsonRequestBehavior.AllowGet);
                }

                ItemAndShoppingList iands = new ItemAndShoppingList
                {
                    Item = theitem,
                    ItemId = theitem.Id,
                    ShoppingList = thelist,
                    ShoppingListId = thelist.Id,
                    QuantityBought = 1
                };


                _dataRepository.AddItemToItemAndListTable(theitem, iands);

                _dataRepository.AddShoppingListToItemAndListTable(thelist, iands);

                //thelist.ItemsAndLists.Add(iands);
                //theitem.ItemAndLists.Add(iands);

               //_db.SaveChanges();

                return Json(new
                {
                    found = true,
                    itemfound = theitem.Name,
                    sectionofitem = theitem.Section,
                    list = thelist.Name
                }, JsonRequestBehavior.AllowGet);
                //return Json(new
                //{
                //    found = true,
                //    itemfound = theitem,
                //    list = thelist.Name
                //}, JsonRequestBehavior.AllowGet);
            }

            return Json(new { found = false, error = errormsg }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult RemoveItemFromShoppingList(int theitemid, int listId)
        {
            var currentuserid = User.Identity.GetUserId();

            var user = _dataRepository.GetCurrentUser(currentuserid);
            //var user = _db.Users.ToList().Where(u => u.Id == currentuserid).First();

            var errormsg = "";

            var thelist = user.ShoppingLists.Where(sl => sl.Id == listId).First();

            if (thelist.ItemsAndLists.FirstOrDefault(i => i.ItemId == theitemid) != null)
            {
                

                var iands = _dataRepository.LookUpItemAndShoppingListGivenItemIdAndShoppingList(thelist, theitemid);

                var theitem = _dataRepository.GetItem(theitemid);
                //var theitem = _db.Items.FirstOrDefault(i => i.Id == theitemid);

                _dataRepository.RemoveItemAndShoppingListLink(iands);


                //return Json(new
                //{
                //    found = true,
                //    itemfound = theitem.Name,
                //    list = thelist.Name
                //}, JsonRequestBehavior.AllowGet);

                return Json(new
                {
                    found = true,
                    itemfound = theitem.Name,
                    sectionofitem = theitem.Section,
                    list = thelist.Name
                }, JsonRequestBehavior.AllowGet);
            }

            errormsg += "An item with the id of " + theitemid + " was not found!";

            return Json(new { found = false, error = errormsg }, JsonRequestBehavior.AllowGet);


        }


        public JsonResult GetAllShoppingListForUserToPopulateDropdown()
        {
            var currentuserid = User.Identity.GetUserId();

            var user = _dataRepository.GetCurrentUser(currentuserid);
            //var user = _db.Users.ToList().Where(u => u.Id == currentuserid).First();


            var lists = _dataRepository.GetUsersShoppingList(user);

            //var lists = _db.ShoppingLists.Where(sl => sl.ApplicationUser.HomeStoreId == user.HomeStoreId).ToList();

            return Json(new { listsfound = lists }, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetCurrentShoppingListForUser()
        //{
        //    var currentuserid = User.Identity.GetUserId();
        //    var user = _db.Users.ToList().Where(u => u.Id == currentuserid).First();

        //    var list = user.CurrentShoppingList.UserItems.ToList();

        //    return Json(new { currentfound = list }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetUserShoppingListsandreturnpartial()
        {
            var currentuserid = User.Identity.GetUserId();

            var user = _dataRepository.GetCurrentUser(currentuserid);

            //var user = _db.Users.ToList().Where(u => u.Id == currentuserid).First();

            var lists = _dataRepository.GetUsersShoppingList(user);

            //var lists = _db.ShoppingLists.Where(sl => sl.ApplicationUser.HomeStoreId == user.HomeStoreId).ToList();

            return PartialView("_shoppinglist", lists);
        }



        public ActionResult CreateShoppingList(string newshoplist)
        {

            var currentuserid = User.Identity.GetUserId();
            var user = _dataRepository.GetCurrentUser(currentuserid);
            // var user = _db.Users.ToList().Where(u => u.Id == currentuserid).First();

            

            if (!_dataRepository.LookUpShoppingListByName(user, newshoplist))
            {
                
                _dataRepository.CreateShoppingListForUser(newshoplist, user);

               
                return Json(new { listadded = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { listadded = false }, JsonRequestBehavior.AllowGet);
        }





    }
}