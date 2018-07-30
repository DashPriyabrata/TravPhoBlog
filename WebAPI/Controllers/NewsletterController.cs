using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class NewsletterController : ApiController
    {
        INewsletterRepository newsLetRepo;

        public NewsletterController()
        {
            newsLetRepo = new NewsletterRepository(new MyTravelBlogEntities());
        }

        [HttpPost]
        [Route("api/Newsletter/AddSub")]
        [ResponseType(typeof(blog_user))]
        public async Task<IHttpActionResult> AddSubscriber([FromBody] newsletter_sub subscriber)
        {
            return Ok(await newsLetRepo.AddSubscriber(subscriber));
        }
    }
}
