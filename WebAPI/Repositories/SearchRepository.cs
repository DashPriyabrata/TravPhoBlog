using System;
using System.Linq;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class SearchRepository : ISearchRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public SearchRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<bloginfo> GetAllCountryBlogs(string country)
        {
            return dbContext.bloginfoes.Where(x => x.Country == country).OrderByDescending(o => o.PostDate);
        }

        public IQueryable<bloginfo> GetAllCityBlogs(string cityName)
        {
            return dbContext.bloginfoes.Where(x => x.City == cityName).OrderByDescending(o => o.PostDate);
        }

        private bool isDisposed;

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    dbContext.Dispose();
                }
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}