using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class SocialController : ApiController
    {
        ISocialConnectRepository socialRepo;

        public SocialController()
        {
            socialRepo = new SocialConnectRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(ICollection<instagram>))]
        [Route("api/Social/Instagram/RecentMedia")]
        public async Task<IHttpActionResult> GetRecentInstagramMedia()
        {
            return Ok(await socialRepo.GetInstagramRecentMedia());
        }
    }
}
