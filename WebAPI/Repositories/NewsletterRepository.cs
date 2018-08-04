using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class NewsletterRepository : INewsletterRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public NewsletterRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> AddSubscriber(newsletter_sub subscriber)
        {
            var _existingsub = await dbContext.newsletter_sub.Where(x => x.Email == subscriber.Email).FirstOrDefaultAsync();

            if (_existingsub != null)
            {
                return Constants.NEWSLETTER_EXIST_MSG;
            }
            else
            {
                subscriber.IsSubscribed = true;
                var _newSub = dbContext.newsletter_sub.Add(subscriber);
                var success = await dbContext.SaveChangesAsync();

                if (success > 0)
                    return Constants.NEWSLETTER_THANK_MSG;
                else
                    return Constants.NEWSLETTER_FAIL_MSG;
            }
        }

        public async Task<ICollection<newsletter_sub>> GetAllSubscribers()
        {
            var subscribers = await dbContext.newsletter_sub.ToListAsync();
            return subscribers;
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