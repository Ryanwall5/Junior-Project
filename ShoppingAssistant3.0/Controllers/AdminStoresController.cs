using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingAssistant3._0.Models;
using ShoppingAssistant3._0.Data;

namespace ShoppingAssistant3._0.Controllers
{
    public class AdminStoresController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private readonly IDataRepository _dataRepository;
        //private ApplicationUserManager _userManager;

        public AdminStoresController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: AdminStores
        public ActionResult Index()
        {
            //var stores = db.Stores.Include(s => s.Address);
            var stores = _dataRepository.GetAllStores();
            return View(stores);
        }

        // GET: AdminStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Store store = db.Stores.Find(id);
            Store store = _dataRepository.GetStoreById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: AdminStores/Create
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(_dataRepository.GetAllAddresses(), "Id", "Street");
            return View();
        }

        // POST: AdminStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AddressId,Name,EmailAddress,PhoneNumber,Street,City,State,Zip,Longitude,Latitude")] StoreViewModel store)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddStore(store);

                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(_dataRepository.GetAllAddresses(), "Id", "Street", store.AddressId);
            return View(store);
        }

        // GET: AdminStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _dataRepository.GetStoreById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }

            Address address = _dataRepository.GetAddressById(store.AddressId);

            StoreViewModel s = new StoreViewModel(store, address);

            ViewBag.AddressId = new SelectList(_dataRepository.GetAllAddresses(), "Id", "Street", store.AddressId);
            return View(s);
        }

        // POST: AdminStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddressId,Name,EmailAddress,PhoneNumber,Street,City,State,Zip,Longitude,Latitude")] StoreViewModel store)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.EditStore(store);
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(_dataRepository.GetAllAddresses(), "Id", "Street", store.AddressId);
            return View(store);
        }

        // GET: AdminStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _dataRepository.GetStoreById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: AdminStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _dataRepository.RemoveStore(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
