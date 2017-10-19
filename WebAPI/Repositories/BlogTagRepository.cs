using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class BlogTagRepository : IBlogTagRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public BlogTagRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<blog_tag> GetTags(int blogTagId)
        {
            var tags = dbContext.SP_GetBlogTags(blogTagId);
            return tags.ToList();
        }

        public async Task<ICollection<blog_tag>> GetAllTags()
        {
            var tags = await dbContext.blog_tag.ToListAsync();
            return tags;
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