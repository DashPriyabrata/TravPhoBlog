using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
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
        }

        public async Task<InstagramPost> GetInstagramRecentMedia()
        {
            InstagramPost instagramMedia = null;
            var response = await httpClient.GetAsync("https://api.instagram.com/v1/users/self/media/recent/?access_token=" + Constants.INSTAGRAM_ACCESS_TOKEN);
            if (response.IsSuccessStatusCode)
            {
                instagramMedia = await response.Content.ReadAsAsync<InstagramPost>();
            }
            return instagramMedia;
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