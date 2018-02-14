using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingAssistant3._0.Models;

namespace ShoppingAssistant3._0.Controllers
{
    public class ItemWithEntityFrameworkController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemWithEntityFramework
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Store);
            return View(items.ToList());
        }

        // GET: ItemWithEntityFramework/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: ItemWithEntityFramework/Create
        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        // POST: ItemWithEntityFramework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreId,Name,Price,Allergens,InStock,StockAmount,Aisle,Section")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", item.StoreId);
            return View(item);
        }

        // GET: ItemWithEntityFramework/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", item.StoreId);
            return View(item);
        }

        // POST: ItemWithEntityFramework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreId,Name,Price,Allergens,InStock,StockAmount,Aisle,Section")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", item.StoreId);
            return View(item);
        }

        public ActionResult EditTags(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            
            var tagIds = item.ItemAndTags.Select(t => t.TagId);

            ViewBag.ItemTags = new SelectList(db.Tags.Where(t => tagIds.Contains(t.Id)));
            ViewBag.OtherTags = new SelectList(db.Tags.Where(t => !tagIds.Contains(t.Id)));

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTags(Item item, FormCollection collection, string command)
        {
            if (command.Equals(""))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (command.Equals("Add"))
            {
                var tagName = collection["TagToAdd"];
                if (!string.IsNullOrEmpty(tagName))
                {
                    Tag tag = db.Tags.FirstOrDefault(t => t.Name.Equals(tagName));

                    ItemAndTag link = new ItemAndTag
                    {
                        ItemId = item.Id,
                        TagId = tag.Id
                    };

                    db.ItemsAndTagsLink.Add(link);
                    db.SaveChanges();
                }
            }
            else
            {
                var tagName = collection["TagToDelete"];
                if (!string.IsNullOrEmpty(tagName))
                {
                    Tag tag = db.Tags.FirstOrDefault(t => t.Name.Equals(tagName));

                    ItemAndTag link = db.ItemsAndTagsLink.FirstOrDefault(l => l.ItemId == item.Id
                                                                                && l.TagId == tag.Id);

                    db.ItemsAndTagsLink.Remove(link);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("EditTags");
        }

        // GET: ItemWithEntityFramework/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ItemWithEntityFramework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
