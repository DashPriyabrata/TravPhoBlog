using Google.Apis.Auth;
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

        public async Task<bool> CheckBlogger(string token)
        {
            try
            {
                var validPayload = await GoogleJsonWebSignature.ValidateAsync(token);
                return await dbContext.bloggers.AnyAsync(x => x.Email == validPayload.Email);
            }
            catch
            {
                return false;
            }
        }

        //public async Task<bool> UpdateAuthToken(string email, string authToken)
        //{
        //    var blogger = await dbContext.bloggers.FirstAsync(x => x.Email == email);
        //    //AuthToken should be null 
        //    if (blogger != null && string.IsNullOrEmpty(blogger.AuthToken))
        //    {
        //        blogger.AuthToken = authToken;
        //        var success = await dbContext.SaveChangesAsync();
        //        return success > 0;
        //    }
        //    return false;
        //}

        //public async Task<bool> DeleteAuthToken(string email, string authToken)
        //{
        //    var blogger = await dbContext.bloggers.FirstAsync(x => x.Email == email);
        //    if (blogger != null)
        //    {
        //        blogger.AuthToken = null;
        //        var success = await dbContext.SaveChangesAsync();
        //        return success > 0;
        //    }
        //    return false;
        //}

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