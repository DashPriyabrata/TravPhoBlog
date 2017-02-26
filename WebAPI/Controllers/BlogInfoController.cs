using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class BlogInfoController : ApiController
    {
        IBlogInfoRepository blogInfoRepo;

        public BlogInfoController()
        {
            blogInfoRepo = new BlogInfoRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> GetBlogContent()
        {
            return Ok(await blogInfoRepo.GetBlogContent(3));
        }
    }
}
