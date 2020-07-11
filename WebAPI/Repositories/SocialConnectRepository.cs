using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Timers;
using WebAPI.Common;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class SocialConnectRepository : ISocialConnectRepository, IDisposable
    {
        MyTravelBlogEntities dbContext;
        static HttpClient httpClient;

        public SocialConnectRepository(MyTravelBlogEntities dbContext)
        {
            this.dbContext = dbContext;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Scheduler.Instance.Timer.Elapsed += WriteInstagramFeedToDB;
        }

        public async Task<ICollection<instagram>> GetInstagramRecentMedia()
        {
            var instagramFeedColl = await dbContext.instagram.ToListAsync();
            return instagramFeedColl;
        }

        /// <summary>
        /// The recent Graph API implementation by Instagram limits the no of call one can make per hour.
        /// Due to this it's now not possible to call the Graph API everytime the Instagram component loads since it'll eat up the quota in few calls.
        /// To workaround this the result from Graph API is getting stored in database, from where we'll fetch the data to show in website.
        /// A scheduled task will call this method every 1hr to get the updated content from Graph API and store in database.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private async void WriteInstagramFeedToDB(object source, ElapsedEventArgs e)
        {
            var mediaIDResponse = await httpClient.GetAsync(Constants.INSTAGRAM_ROOT_URL + Constants.INSTAGRAM_USER_ID + "/media/?access_token=" + Constants.INSTAGRAM_ACCESS_TOKEN);
            if (mediaIDResponse.IsSuccessStatusCode)
            {
                var instagramMediaColl = new List<instagram>();
                var media = await mediaIDResponse.Content.ReadAsAsync<Media>();
                foreach (var post in media.Data)
                {
                    var response = await httpClient.GetAsync(Constants.INSTAGRAM_ROOT_URL + post.Id + "?access_token=" + Constants.INSTAGRAM_ACCESS_TOKEN
                                + "&fields=id,media_url,caption,media_type,timestamp,permalink,thumbnail_url");
                    if (response.IsSuccessStatusCode)
                    {
                        instagramMediaColl.Add(await response.Content.ReadAsAsync<instagram>());
                    }
                }

                if (instagramMediaColl.Count > 0)
                {
                    dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE travphotblog.instagram");
                    dbContext.instagram.AddRange(instagramMediaColl);
                    var success = dbContext.SaveChanges();
                }
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