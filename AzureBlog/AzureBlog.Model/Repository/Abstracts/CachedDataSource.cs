using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using System.Configuration;

namespace AzureBlog.Model.Repository.Abstracts
{
    public abstract class CachedDataSource
    {
        private readonly ObjectCache cacheProvider;
        private readonly string regionName;

        public CachedDataSource(ObjectCache cacheProvider, string regionName)
        {
            if (cacheProvider == null)
            {
                throw new ArgumentNullException("cacheProvider");
            }

            if (cacheProvider is MemoryCache)
            {
                regionName = null;
            }

            this.cacheProvider = cacheProvider;
            this.regionName = regionName;
        }

        protected T RetrieveCachedData<T>(string cacheKey, Func<T> fallbackFunction, CacheItemPolicy cachePolicy) where T : class
        {
            var data = this.cacheProvider.Get(cacheKey, this.regionName) as T;
            if (data != null)
            {
                return data;
            }

            data = fallbackFunction();
            if (data != null)
            {
                this.cacheProvider.Add(new CacheItem(cacheKey, data, this.regionName), cachePolicy);
            }

            return data;
        }

        protected void RemoveCachedData(string cacheKey)
        {
            this.cacheProvider.Remove(cacheKey, this.regionName);
        }



    }


    public class DataSourceFactory
    {
        private static readonly ObjectCache cacheProvider;

        static DataSourceFactory()
        {
            string provider = ConfigurationManager.AppSettings["CacheService.Provider"];
            if (provider != null)
            {
                switch (ConfigurationManager.AppSettings["CacheService.Provider"].ToUpperInvariant())
                {
                    //case "APPFABRIC":
                    //    cacheProvider = new AppFabricCacheProvider();
                    //    break;
                    case "INMEMORY":
                        cacheProvider = MemoryCache.Default;
                        break;
                }
            }
        }

        public static ObjectCache CacheProvider
        {
            get { return cacheProvider; }
        }

    }
}
