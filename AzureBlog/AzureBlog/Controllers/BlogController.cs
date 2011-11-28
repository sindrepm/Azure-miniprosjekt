using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AzureBlog.Model.Infrastructure;
using AzureBlog.Model.Repository.Abstracts;
using AzureBlog.Model.Entities;

namespace AzureBlog.Controllers
{ 
    
    public class BlogController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IBlogRepository _repository;

        public BlogController(IBlogRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }


        //
        // GET: /Blog/

        public ViewResult Index()
        {
            var posts = _repository.GetAll();

            return View(posts);
        }

        //
        // GET: /Blog/Details/5

        public ViewResult Details(int id)
        {
            var blogpost = _repository.GetById(id);
            
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
                _repository.Add(blogpost);

                _unitOfWork.Commit();
                
                return RedirectToAction("Index");  
            }

            return View(blogpost);
        }
        
        //
        // GET: /Blog/Edit/5
 
        public ActionResult Edit(int id)
        {
            //BlogPost blogpost = db.Posts.Find(id);
            //return View(blogpost);

            return View();
        }

        //
        // POST: /Blog/Edit/5

        [HttpPost]
        public ActionResult Edit(BlogPost blogpost)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(blogpost).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogpost);
        }

        //
        // GET: /Blog/Delete/5
 
        public ActionResult Delete(int id)
        {
            //BlogPost blogpost = db.Posts.Find(id);
            //return View(blogpost);
            return View();
        }

        //
        // POST: /Blog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            //BlogPost blogpost = db.Posts.Find(id);
            //db.Posts.Remove(blogpost);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TagCloud()
        {
            var service = new Model.Service.Concrete.TagService();
            var tagCloud = service.GetTagCloud();
            return View(tagCloud);
        }

        protected override void Dispose(bool disposing)
        {
            //_unitOfWork.
            base.Dispose(disposing);
        }
    }
}