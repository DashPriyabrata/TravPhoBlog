using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class BloggerRepository : IBloggerRepository
    {
        MyTravelBlogEntities dbContext;

        public BloggerRepository()
        {
            dbContext = new MyTravelBlogEntities();
        }
        public async Task<blogger> GetBlogger(int bloggerId)
        {
            return dbContext.bloggers.Where(x => x.BloggerId == bloggerId).FirstOrDefault();
        }

        public async Task<ICollection<blogger>> GetAll()
        {
            return dbContext.bloggers.AsEnumerable() as ICollection<blogger>;
        }
    }
}