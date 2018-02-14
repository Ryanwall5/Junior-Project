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
    public class HomeController : Controller
    {

        private readonly IDataRepository _dataRepository;

        //private ApplicationDbContext _db = new ApplicationDbContext();

      
        public HomeController(IDataRepository datarepository)
        {
            _dataRepository = datarepository;


          //var items = _dataRepository.GetAllItems();


        }

        public ActionResult Index()
        {
            return View();
        }


        // fill in recentlysearched items with random items unless the recentlysearch items count == 3 
        public ActionResult DisplayRecentUserSearchedItems()
        {
            var userId = User.Identity.GetUserId();

            var user = _dataRepository.GetCurrentUser(userId);

            var recentlysearchitems = user.RecentlySearchedItems.ToList();     

            if(recentlysearchitems.Count > 0 )
            {

               var itemssearched = recentlysearchitems.Select(itemfound => new ItemViewModel
                {
                    Id = itemfound.Id,
                    Name = itemfound.Name,
                    Price = itemfound.Price,
                    InStock = itemfound.InStock,
                    StockAmount = itemfound.StockAmount,
                    Aisle = itemfound.Aisle,
                    Section = itemfound.Section,
                    Allergens = itemfound.Allergens

                });

                ViewBag.displaytitle = "Recently Searched Items";

                return PartialView("_RecentlySearched", itemssearched.Take(3));
            }
            else
            {
                Random rand = new Random();

                var items = _dataRepository.GetAllItems();

                var itemsforview = items.OrderBy(x => rand.Next()).Take(3).Select(itemfound => new ItemViewModel
                {

                    Id = itemfound.Id,
                    Name = itemfound.Name,
                    Price = itemfound.Price,
                    InStock = itemfound.InStock,
                    StockAmount = itemfound.StockAmount,
                    Aisle = itemfound.Aisle,
                    Section = itemfound.Section,
                    Allergens = itemfound.Allergens

                });

                ViewBag.displaytitle = "Random Items";
                return PartialView("_RecentlySearched", itemsforview);
            }


     

        }

        public ActionResult UserIndex()
        {
            var userId = User.Identity.GetUserId();

            var user = _dataRepository.GetCurrentUser(userId);

            var store = _dataRepository.GetStoreById(user.HomeStoreId);

            ViewBag.UserHomeStore = store.Name;

            return View("Index");
        }


        public ActionResult DisplayRandomItems()
        {

            Random rand = new Random();

            var items = _dataRepository.GetAllItems();

            var itemsforview = items.OrderBy(x => rand.Next()).Take(3).Select(itemfound => new ItemViewModel
            {

                Id = itemfound.Id,
                Name = itemfound.Name,
                Price = itemfound.Price,
                InStock = itemfound.InStock,
                StockAmount = itemfound.StockAmount,
                Aisle = itemfound.Aisle,
                Section = itemfound.Section,
                Allergens = itemfound.Allergens

            });

            return PartialView("_Displaythreeranditems", itemsforview.ToList());
        }


        [HttpPost]
        public ActionResult Index(string searchchoice)
        {
            switch (searchchoice)
            {

                case "itemsearch":
                    {
                        return PartialView("_Itemsearch");
                    }
                case "storesearch":
                    {
                        return PartialView("_Storesearch");
                    }
                case "shoppinglistsearch":
                    {
                        return PartialView("_Shoppinglistsearch");
                    }
                default:
                    {
                        return View();
                    }
            }
        }

        public ActionResult Autocomplete(string term)
        {
            var model2 = _dataRepository.GetAllItems();
            var items = model2.Where(r => r.Name.ToLower().StartsWith(term.ToLower())).Take(10).Select(r => new
            {
                label = r.Name + ",  $" + r.Price.ToString("0.##")
            });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AutocompleteStore(string term)
        {
            var model2 = _dataRepository.GetAllStores();
            var items = model2.Where(r => r.Name.ToLower().StartsWith(term.ToLower())).Take(10).Select(r => new
            {
                label = r.Name + ", " + r.Address.City
            });

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayError(string error)
        {
            ViewBag.Error = error;
            return View("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}