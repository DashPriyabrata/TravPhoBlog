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
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> AddSubscriber([FromBody] newsletter_sub subscriber)
        {
            return Ok(await newsLetRepo.AddSubscriber(subscriber));
        }

        [HttpPost]
        [Route("api/Newsletter/UnSub")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> UnSubscribe(int d, string em)
        {
            return Ok(await newsLetRepo.Unsubscribe(d, em));
        }
    }
}
