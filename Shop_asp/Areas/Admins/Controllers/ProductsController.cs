using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_asp.Models;
using System.IO;
namespace Shop_asp.Areas.Admins.Controllers
{
    public class ProductsController : Controller
    {
        private ShopEntities db = new ShopEntities();
            
        // GET: Admins/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Admins/Products/Details/5
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

        // GET: Admins/Products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "id", "name");
            return View();
        }

        // POST: Admins/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price,description,information,sale,category_id,tag,photo")] Product product,string photo)
        {
            var upload_file = HttpContext.Request.Files["photo"];
             
            if (upload_file.ContentType == "image/gif" || upload_file.ContentType == "image/png" || upload_file.ContentType == "image/jpg" || upload_file.ContentType == "image/jpeg")
            {
                string file_name = DateTime.Now.ToString("mm - ss - ffff - ") + upload_file.FileName;
                string new_file = Path.Combine(HttpContext.Server.MapPath("/Uploads"), file_name);
                upload_file.SaveAs(new_file);
                product.photo = file_name;
            }
           // return Content(product.photo.ToString());

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "id", "name", product.category_id);
            return View(product);
        }

        // GET: Admins/Products/Edit/5
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
            ViewBag.category_id = new SelectList(db.Categories, "id", "name", product.category_id);
            return View(product);
        }

        // POST: Admins/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,description,information,sale,category_id,tag,photo")] Product product,string oldfile)
        {
            var upload_file = HttpContext.Request.Files["photo"];
            if (upload_file.FileName.Length>0)
            {
                if (upload_file.ContentType == "image/gif" || upload_file.ContentType == "image/png" || upload_file.ContentType == "image/jpg" || upload_file.ContentType == "image/jpeg")
                {
                    string file_name = DateTime.Now.ToString("mm - ss - ffff - ") + upload_file.FileName;
                    string new_file = Path.Combine(HttpContext.Server.MapPath("/Uploads"), file_name);
                    upload_file.SaveAs(new_file);
                    product.photo = file_name;
                }
            }
            else
            {
                product.photo = oldfile;
            }
           
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "id", "name", product.category_id);
            return View(product);
        }

        // GET: Admins/Products/Delete/5
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

        // POST: Admins/Products/Delete/5
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
