using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class BloggerController : ApiController
    {
        IBloggerRepository bloggerRepo;

        public BloggerController()
        {
            bloggerRepo = new BloggerRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(blogger))]
        public async Task<IHttpActionResult> GetBlogger()
        {
            return Ok(await bloggerRepo.GetBlogger(1));
        }

        [ResponseType(typeof(List<blogger>))]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await bloggerRepo.GetAll());
        }

        [HttpGet]
        [ResponseType(typeof(bool))]
        [Route("api/Blogger/Validate")]
        public async Task<IHttpActionResult> CheckBloggerPresence(string token)
        {
            return Ok(await bloggerRepo.CheckBlogger(token));
        }

        [HttpGet]
        public string Demo()
        {
            return "Yep it's working!";
        }
    }
}
