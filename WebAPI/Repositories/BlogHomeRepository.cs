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
    public class BlogHomeRepository : IBlogHomeRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public BlogHomeRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<bloginfo>> GetAll()
        {
            var allBlogInfo = await dbContext.bloginfoes.Where(x => x.IsActive).OrderByDescending(x => x.PostDate).ToListAsync();
            return allBlogInfo;
        }

        public async Task<IEnumerable<bloginfo>> GetPrecisePosts(int skippedCount, int requiredCount)
        {
            var posts = await dbContext.bloginfoes.Where(x => x.IsActive).OrderByDescending(x => x.PostDate).Skip(skippedCount).Take(requiredCount).ToListAsync();
            //foreach (var post in posts)
            //{
            //    post.Introduction = dbContext.postcontents.Where(x => x.Id == post.ContentId).FirstOrDefaultAsync().Result.Introduction;
            //}

            return posts;
        }

        public async Task<int> GetTotalBlogCount()
        {
            var count = await dbContext.bloginfoes.Where(x => x.IsActive).CountAsync();
            return count;
        }

        public async Task<IEnumerable<bloginfo>> GetFeaturedPosts()
        {
            var featuredPosts = await dbContext.bloginfoes.Where(x => x.IsFeatured == true).OrderByDescending(o => o.PostDate).ToListAsync();
            return featuredPosts;
        }

        public async Task<IEnumerable<bloginfo>> GetTrendingPosts()
        {
            var trendingPosts = dbContext.SP_GetLastFiveCommentedPosts();
            return trendingPosts.Take(2).ToList();
        }

        public async Task<IEnumerable<blog_category>> GetAllCategoriesWithBlogCount()
        {
            var categories = await dbContext.blog_category.ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<bloginfo>> GetFavouritePosts()
        {
            var featuredPosts = await dbContext.bloginfoes.Where(x => x.IsFavourite == true).OrderByDescending(o => o.PostDate).ToListAsync();
            return featuredPosts;
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