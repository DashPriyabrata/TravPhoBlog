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
    public class UserRepository : IUserRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public UserRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<blog_user> AddUser(blog_user user)
        {
            var _existingUser = await dbContext.blog_user.Where(x => x.Email == user.Email).FirstOrDefaultAsync();

            if(_existingUser != null)
            {
                return _existingUser;
            }
            else
            {
                var _newUser = dbContext.blog_user.Add(user);
                var success = await dbContext.SaveChangesAsync();

                if (success > 0)
                    return _newUser;
                else
                    return null;
            }
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