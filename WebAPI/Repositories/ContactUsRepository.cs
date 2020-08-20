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
    public class ContactUsRepository : IContactUsRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;

        public ContactUsRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddRecord(contactus submission)
        {
            dbContext.contactus.Add(submission);
            var success = await dbContext.SaveChangesAsync();
            return success > 0 ? true : false;
        }

        public async Task<IEnumerable<contactus>> GetAllRecords()
        {
            var allSubmissions = await dbContext.contactus.Where(x => x.IsActive == true).OrderByDescending(x => x.Date).ToListAsync();
            return allSubmissions;
        }

        /// <summary>
        /// Updates the Admin read property of the contact us form submission record.
        /// This is invoked from admin dashboard when an admin reads the submission entry.
        /// </summary>
        /// <param name="id">The Id of the record, which invoked this method.</param>
        /// <returns>Update status in boolean or null if no record found.</returns>
        public async Task<bool?> UpdateIsAdminReadProperty(int id)
        {
            var submission = dbContext.contactus.FirstAsync(x => x.Id == id);
            if (submission != null)
            {
                submission.Result.IsAdminRead = true;
                var success = await dbContext.SaveChangesAsync();
                return success > 0 ? true : false;
            }
            return null;
        }

        private bool isDisposed;
        public void Dispose(bool isDisposing)
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