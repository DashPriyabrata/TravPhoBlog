using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class BloggerRepository : IBloggerRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public BloggerRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<blogger> GetBlogger(int bloggerId)
        {
            var blogger = await dbContext.bloggers.Where(x => x.BloggerId == bloggerId).FirstOrDefaultAsync();
            return blogger;
        }

        public async Task<ICollection<blogger>> GetAll()
        {
            var bloggers = await dbContext.bloggers.ToListAsync();
            return bloggers;
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