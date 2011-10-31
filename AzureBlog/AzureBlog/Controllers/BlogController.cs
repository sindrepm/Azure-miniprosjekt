using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureBlog.Models;

namespace AzureBlog.Controllers
{ 
    public class BlogController : Controller
    {
        private AzureBlogContext db = new AzureBlogContext();

        //
        // GET: /Blog/

        public ViewResult Index()
        {
            return View(db.Posts.ToList());
        }

        //
        // GET: /Blog/Details/5

        public ViewResult Details(int id)
        {
            BlogPost blogpost = db.Posts.Find(id);
            return View(blogpost);
        }

        //
        // GET: /Blog/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Blog/Create

        [HttpPost]
        public ActionResult Create(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(blogpost);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(blogpost);
        }
        
        //
        // GET: /Blog/Edit/5
 
        public ActionResult Edit(int id)
        {
            BlogPost blogpost = db.Posts.Find(id);
            return View(blogpost);
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogpost);
        }

        //
        // GET: /Blog/Delete/5
 
        public ActionResult Delete(int id)
        {
            BlogPost blogpost = db.Posts.Find(id);
            return View(blogpost);
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BlogPost blogpost = db.Posts.Find(id);
            db.Posts.Remove(blogpost);
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