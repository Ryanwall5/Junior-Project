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
    public class StoreController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly IDataRepository _dataRepository;

        public StoreController(IDataRepository datarepository)
        {
            _dataRepository = datarepository;
        }

        // GET: Store
        [HttpGet]
        public ActionResult BuildAStore()
        {
            var stores = _dataRepository.GetAllStores().Select(x => x.GetListItem()).ToList();
            ViewData["StoreName"] = stores;
            return View();
        }

        public JsonResult AddSectionToStoreMap(string nameofsection, string shelfwithsectionumandcoords, int storeId)
        { 
     
            if(String.IsNullOrEmpty(nameofsection) || String.IsNullOrEmpty(shelfwithsectionumandcoords))
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //StoreMap sm = _dataRepository.GetLatestStoreMap();
                Section section = new Section(nameofsection, shelfwithsectionumandcoords);

                var store = _dataRepository.GetStoreById(storeId);

                _dataRepository.AddSection(section);

                // storemap.shelves where the name of the shelf is equal to the shelf name that was passed in. and then we add the section to that shelf

                _dataRepository.AddSectionToShelf(store, section);
             
                return Json(new { data = section, success = true }, JsonRequestBehavior.AllowGet);
               // return Json(new { data = section, success = true }, JsonRequestBehavior.AllowGet);
            }          
        }


        public JsonResult CreateStoreMap(int aisles, int shelves, int sections, bool backwall, bool rightwall, bool leftwall, int storeId)
        {
            if (aisles == 0 || sections == 0 || shelves == 0)
            {
                return Json(new {error = "Aisles, Sections and/or Shelves equals zero. They all must be greater than zero.", success = false }, JsonRequestBehavior.AllowGet);
            }
        
            StoreMap map = new StoreMap(aisles, shelves, backwall, rightwall, leftwall);

            Store store =_dataRepository.GetStoreById(storeId);
            if(store != null)
            {
                _dataRepository.CreateStoreMapWithShelves(map, sections, store);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {error = "The store was not found",  success = false }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult GetAllStoreNames()
        {
            return Json(new { storenames = _dataRepository.GetAllStores() }, JsonRequestBehavior.AllowGet);
        }

        public void UpdateUserHomeStore(string newstoreId)
        {
            var userid = User.Identity.GetUserId();
            var user = _dataRepository.GetCurrentUser(userid);

            StoreSearch(user.HomeStore.Name);
        }

        public ActionResult StoreSearch(string storename)
        {

            if (String.IsNullOrEmpty(storename))
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                var store = storename.Split(',');
                var storelist = _dataRepository.GetAllStores();
                if (storelist.FirstOrDefault(x => x.Name.ToLower() == store[0].ToLower()) != null)
                {
                    var storefound = storelist.FirstOrDefault(x => x.Name.ToLower() == store[0].ToLower());
                   
                    string markers = "[";

                    markers += "{";
                    markers += string.Format("'title': '{0}',", storefound.Name);
                    markers += string.Format("'lat': '{0}',", storefound.Address.Latitude);
                    markers += string.Format("'lng': '{0}',", storefound.Address.Longitude);
                    markers += string.Format("'description': '{0}'", storefound.PhoneNumber);
                    markers += "},";

                    markers += "];";
                    ViewBag.Markers = markers;

                    var stores = _dataRepository.GetAllStores().Select(x => x.GetListItem());
                    ViewData["StoreName"] = stores;

                    return View(storefound);
                }

                return RedirectToAction("DisplayError", "Home", new { error = "* " + storename + " was not found in our database" });
            }
        }

        public JsonResult GetStoreMapDetails(int listId)
        {
            var userid = User.Identity.GetUserId();
            var user = _dataRepository.GetCurrentUser(userid);
            Store usersstore = user.HomeStore;

            StoreMap sm = usersstore.StoreMap;
            List<Shelf> smshelves = sm.Shelves.ToList();

            List<Section> smsections = new List<Section>();
            smshelves.ForEach(x => x.Sections.ToList().ForEach(y => smsections.Add(y)));

            var shoppinglist = _dataRepository.GetShoppingList(listId);
            var itemsinlist = shoppinglist.ItemsAndLists.Where(il => il.ShoppingListId == listId).Select(x => x.Item).ToList();

            IList<ItemViewModel> list = new List<ItemViewModel>();
            foreach (Item i in itemsinlist)
            {
                list.Add(new ItemViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    InStock = i.InStock,
                    StockAmount = i.StockAmount,
                    Aisle = i.Aisle,
                    Section = i.Section,
                    Allergens = i.Allergens
                });
            }

            return Json(new { shelves = smshelves, sections = smsections, items = list, success = true }, JsonRequestBehavior.AllowGet);
        }


    }
}