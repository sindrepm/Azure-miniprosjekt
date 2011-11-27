using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Microsoft.ApplicationServer.Caching;

namespace AzureBlog.Controllers
{
    public class CacheController : Controller
    {
        public class CacheEntryViewModel
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        //
        // GET: /Cache/

        public ActionResult Index()
        {
            DataCacheFactoryConfiguration factoryConfig = new DataCacheFactoryConfiguration();

            DataCacheServerEndpoint[] servers = new DataCacheServerEndpoint[1] { 
                new DataCacheServerEndpoint(factoryConfig.Servers.First().HostName, 22233) };
           
            factoryConfig.Servers = servers;
           
            DataCacheFactory mycacheFactory = new DataCacheFactory(factoryConfig);
           
            DataCache cache = mycacheFactory.GetCache("default");
            
            var list = new List<CacheEntryViewModel>();


            if (cache.Get("Time") == null)
            {
                cache.Put("Time", DateTime.Now);
            }

            list.Add(new CacheEntryViewModel()
            {
                Key= "Time",
                Value = ((DateTime)cache.Get("Time")).ToLongTimeString()
            });

            return View(list);
        }


        [OutputCache(Duration=300)]
        public ActionResult Output()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Put(string text)
        {
            return RedirectToAction("Index");
        }

    }
}
