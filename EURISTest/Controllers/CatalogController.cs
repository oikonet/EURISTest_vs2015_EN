using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EURIS.Entities;

namespace EURISTest.Controllers
{
    public class CatalogController : Controller
    {
        private LocalDbEntities db = new LocalDbEntities();

        //
        // GET: /Catalog/

        public ActionResult Index()
        {
            return View(db.Catalog.ToList());
        }

        //
        // GET: /Catalog/Details/5

        public ActionResult Details(string id = null)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // GET: /Catalog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Catalog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Catalog.Add(catalog);
                db.SaveChanges();
                return RedirectToAction(@"Edit/" + catalog.Code);
            }

            return View(catalog);
        }






        //
        // GET: /Catalog/AddProduct/5

        public ActionResult AddProduct(string id = null, String pid = null)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogProducts = catalog.Product;

            Product product = db.Product.Find(pid);
            catalog.Product.Add(product);
            db.SaveChanges();

            ViewBag.RemainingProducts = RemainingProducts(catalog);

            //return View(catalog);
            return RedirectToAction("Edit/" + catalog.Code);
        }

        //
        // GET: /Catalog/RemoveProduct/5

        public ActionResult RemoveProduct(string id = null, String pid = null)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogProducts = catalog.Product;

            Product product = db.Product.Find(pid);
            catalog.Product.Remove(product);
            db.SaveChanges();

            ViewBag.RemainingProducts = RemainingProducts(catalog);

            //return View(catalog);
            return RedirectToAction("Edit/" + catalog.Code);
        }

        public List<Product> RemainingProducts(Catalog catalog)
        {
            EURIS.Service.ProductManager productManager = new EURIS.Service.ProductManager();
            return productManager.GetRemainingProducts(catalog); ;
        }




















        //
        // GET: /Catalog/Edit/5

        public ActionResult Edit(string id = null)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogProducts = catalog.Product;
            ViewBag.RemainingProducts = RemainingProducts(catalog);
            return View(catalog);
        }

        //
        // POST: /Catalog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalog);
        }

        //
        // GET: /Catalog/Delete/5

        public ActionResult Delete(string id = null)
        {
            Catalog catalog = db.Catalog.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        //
        // POST: /Catalog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Catalog catalog = db.Catalog.Find(id);
            
            foreach (Product p in catalog.Product.ToList())
                catalog.Product.Remove(p);

            db.Catalog.Remove(catalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}