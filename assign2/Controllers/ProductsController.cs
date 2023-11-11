using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using assign2.Data;
using assign2.Models;
using assign2.ViewModels;

namespace assign2.Controllers
{
    public class ProductsController : Controller
    {
        private assign2Context db = new assign2Context();

        // GET: Products
        public ActionResult Index(string topic, string search)
        {
            //instantiate a new view model
            ProductIndexViewModel viewModel = new ProductIndexViewModel();
            var products = db.Products.Include(p => p.Topic);
            //find the products where either the product name field contains search,the product 
            //description contains search, or the product's category name contains search
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search) ||
                p.Place.Contains(search) ||
                p.Topic.Name.Contains(search));
                // ViewBag.Search = search;
                viewModel.Search = search;
            }
            //group search results into categories and count how many items in each category
            viewModel.CatsWithCount = from matchingProducts in products
                                      where
                                      matchingProducts.TopicID != null
                                      group matchingProducts by
                                      matchingProducts.Topic.Name into
                                      catGroup
                                      select new TopicWithCount()
                                      {
                                          TopicName = catGroup.Key,
                                          ProductCount = catGroup.Count()
                                      };
       
   //var categories = products.OrderBy(p => p.Category.Name).Select(p => 
//p.Category.Name).Distinct();
            if (!String.IsNullOrEmpty(topic))
            {
                products = products.Where(p => p.Topic.Name == topic);
            }
            //ViewBag.Category = new SelectList(categories); 
            viewModel.Products = products;
            // return View(products.ToList());
           // return View(db.Topics.OrderBy(c => c.Name).ToList());
            return View(viewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Place,Usefulness,TopicID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopicID = new SelectList(db.Topics, "ID", "Name", product.TopicID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "Name", product.TopicID);
            return View(product);
        }

        // POST: Products/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Place,Usefulness,TopicID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.Topics, "ID", "Name", product.TopicID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
