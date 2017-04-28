using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<bloginfo> GetPrevPost(int blogId)
        {
            var user = dbContext.SP_PrevPost(blogId).FirstOrDefault();
            return user;
        }
        public async Task<bloginfo> GetNextPost(int blogId)
        {
            var user = dbContext.SP_NextPost(blogId).FirstOrDefault();
            return user;
        }

        public async Task<postcontent> GetContent(int blogId)
        {
            var postContent = await dbContext.postcontents.Where(x => x.Id == blogId).FirstOrDefaultAsync();
            return postContent;
        }

        public List<blog_tag> GetTags(int blogTagId)
        {
            var tags = dbContext.SP_GetBlogTags(blogTagId);
            return tags.ToList();
        }

        public async Task<ICollection<blog_comment>> GetComments(int blogId)
        {
            var comments = await dbContext.blog_comment.Where(x => x.PostId == blogId).ToListAsync();
            return comments;
        }

        public async Task<bool> AddComment(blog_comment comment)
        {
            dbContext.blog_comment.Add(comment);
            var success = await dbContext.SaveChangesAsync();
            return success > 0 ? true : false;
        }

        public async Task<IEnumerable<bloginfo>> GetRelatedPosts(int[] tagIds)
        {
            var relatedPosts = new List<bloginfo>();
            if (tagIds.Count() > 0)
            {
                for (int i = 0; i < tagIds.Count(); i++)
                {
                    var mappers = await dbContext.tag_mapper.Where(x => x.TagId == tagIds[i]).Distinct().ToListAsync();
                    foreach (var mapper in mappers)
                    {
                        relatedPosts.Add(dbContext.bloginfoes.FirstOrDefault(x => x.BlogTagId == mapper.BlogTagId));
                    }
                    if (relatedPosts.Count >= 4)
                        return relatedPosts.Take(4);
                }
            }

            return relatedPosts;
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