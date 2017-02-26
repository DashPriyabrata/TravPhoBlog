using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class BlogInfoRepository : IBlogInfoRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public BlogInfoRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<bloginfo>> GetAll()
        {
            var allBlogInfo = await dbContext.bloginfoes.ToListAsync();
            return allBlogInfo;
        }

        public async Task<bloginfo> GetBlogInfo(int blogId)
        {
            var blogInfo = await dbContext.bloginfoes.Where(x => x.BlogId == blogId).FirstOrDefaultAsync();
            return blogInfo;
        }

        public async Task<string> GetContent(int blogId)
        {
            var blogContent = await dbContext.blogcontents.Where(x => x.Id == blogId).FirstOrDefaultAsync();
            return blogContent.Content;
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