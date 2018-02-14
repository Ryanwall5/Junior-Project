using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingAssistant3._0.Data;
using ShoppingAssistant3._0.Models;

namespace ShoppingAssistant3._0.Controllers
{
    public class TagsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IDataRepository _dataRepository;

        public TagsController(IDataRepository datarepository)
        {
            _dataRepository = datarepository;
        }
        // GET: Tags
        public ActionResult Index()
        {
            return View(_dataRepository.GetAllTags());
        }

        // GET: Tags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _dataRepository.GetTagById((int)id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddTag(tag);
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _dataRepository.GetTagById((int)id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.EditTag(tag);
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _dataRepository.GetTagById((int)id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _dataRepository.RemoveTag(id);
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
