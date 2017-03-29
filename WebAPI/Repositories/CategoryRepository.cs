using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public CategoryRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<category> GetCategory(int categoryId)
        {
            var category = await dbContext.categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
            return category;
        }

        public async Task<ICollection<category>> GetAll()
        {
            var categories = await dbContext.categories.ToListAsync();
            return categories;
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