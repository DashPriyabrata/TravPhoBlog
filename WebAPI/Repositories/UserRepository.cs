using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;
        Utility util;

        public UserRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
            util = new Utility();
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
                user.Avatar = Constants.GRAVATAR_BASE_URL + await util.GetHashedValue(user.Email);
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