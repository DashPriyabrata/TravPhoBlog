using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<bool> Unsubscribe(int id, string emailKey)
        {
            var userRecord = await dbContext.newsletter_sub.SingleOrDefaultAsync(x => x.Id == id);
            var temp = GenerateUnSubUrl(userRecord);
            if (userRecord != null && userRecord.IsSubscribed == true)
            {
                var hashedEmail = await new Utility().GetHashedValue(userRecord.Email);
                
                if (emailKey == hashedEmail)
                {
                    userRecord.IsSubscribed = false;
                    userRecord.Un_SubscribedDate = DateTime.Now;
                    var success = await dbContext.SaveChangesAsync();

                    if (success > 0)
                        return true;
                }
            }

            return false;
        }

        public async Task<ICollection<newsletter_sub>> GetAllSubscribers()
        {
            var subscribers = await dbContext.newsletter_sub.ToListAsync();
            return subscribers;
        }

        public async Task<string> GenerateUnSubUrl(newsletter_sub userRecord)
        {
            if (userRecord != null)
            {
                var encodedEmail = HttpUtility.UrlEncode(await new Utility().GetHashedValue(userRecord.Email));
                var finalUrl = Constants.NEWSLETTER_UNSUB_BASE_URL + "d=" + userRecord.Id + "&em=" + encodedEmail;

                return finalUrl;
            }
            return string.Empty;
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