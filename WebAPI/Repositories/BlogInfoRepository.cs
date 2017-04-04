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

        public async Task<postcontent> GetContent(int blogId)
        {
            var postContent = await dbContext.postcontents.Where(x => x.Id == blogId).FirstOrDefaultAsync();
            return postContent;
        }

        public async Task<List<blog_comment>> GetComments(int blogId)
        {
            var comments = await dbContext.blog_comment.Where(x => x.PostId == blogId).ToListAsync();
            return comments;
        }

        public async Task<bool> AddComment(blog_comment comment)
        {
            var status = dbContext.blog_comment.Add(comment);

            return status == null ? false : true;
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