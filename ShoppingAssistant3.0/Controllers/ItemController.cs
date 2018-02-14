using ShoppingAssistant3._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShoppingAssistant3._0.Data;

namespace ShoppingAssistant3._0.Controllers
{
    public class ItemController : Controller
    {

        private readonly IDataRepository _dataRepository;


        public ItemController(IDataRepository datarepository)
        {
            _dataRepository = datarepository;
        }

        // GET: Item
        public ActionResult Index()
        {

            return View("Index", _dataRepository.GetAllItems());
        }


        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }


        [HttpPost]
        public ActionResult Create(Item item)
        {
            _dataRepository.AddItem(item);

            return View();
        }

        [HttpGet]
        public ActionResult Details(Item item)
        {
            var userId = User.Identity.GetUserId();

            if (userId != null)
            {
                var user = _dataRepository.GetCurrentUser(userId);
                _dataRepository.AddItemToUserRecentlySearched(user, item);
                //user.RecentlySearchedItems.Add(itemfound);
                //_db.SaveChanges();
            }

            var itemViewModel = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                InStock = item.InStock,
                StockAmount = item.StockAmount,
                Aisle = item.Aisle,
                Section = item.Section,
                Allergens = item.Allergens
            };

            return View(itemViewModel);
        }


        [HttpGet]
        public ActionResult DetailsById(int id)
        {

            var item = _dataRepository.GetItem(id);

            var itemViewModel = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                InStock = item.InStock,
                StockAmount = item.StockAmount,
                Aisle = item.Aisle,
                Section = item.Section,
                Allergens = item.Allergens
            };

            return View("Details",itemViewModel);
        }

        [HttpGet]
        public ActionResult ItemSearch(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return RedirectToAction("Index", "Home", null);

            var splitString = searchString.Split(' ');

            var items = _dataRepository.GetAllItems();

            var searchItems = new List<Tuple<int, Item>>();

            foreach (Item i in items)
            {
                int valuesMatched = 0;

                var splitName = i.Name.Split(' ');
                foreach (string s1 in splitName)
                {
                    foreach (string s2 in splitString)
                    {
                        if (s1.ToLower().StartsWith(s2.ToLower()))
                            ++valuesMatched;
                    }
                }

                foreach (ItemAndTag t in i.ItemAndTags)
                {
                    foreach (string s in splitString)
                    {
                        if (t.Tag.Name.ToLower().StartsWith(s.ToLower()))
                            ++valuesMatched;
                    }
                }

                if (valuesMatched != 0)
                {
                    var iPair = new Tuple<int, Item>(valuesMatched, i);
                    searchItems.Add(iPair);
                }
            }

            var orderedSearchItems = searchItems.OrderByDescending(t => t.Item1).Select(t => t.Item2);

            return View(orderedSearchItems.ToList());
        }

        public ActionResult GetItemsInSection(string section)
        {
            if(String.IsNullOrEmpty(section))
            {
                return Json(new { error = "Section name was null or empty", success = false }, JsonRequestBehavior.AllowGet);
            }
            if ( _dataRepository.GetAllItems().Where(x => x.Section.ToLower() == section.ToLower()).ToList().Count != 0)
            {
                var items = _dataRepository.GetAllItems().Where(x => x.Section.ToLower() == section.ToLower());
                IList<ItemViewModel> list = new List<ItemViewModel>();
                foreach (Item i in items)
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
                return Json(new { itemsfound = list, success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { error = "Did not find any items for that given section", success = false }, JsonRequestBehavior.AllowGet);
            }                
        }
    }
}