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
        public IHttpActionResult GetTestData()
        {
            var testData = new List<object>();
            testData.Add(new { Name = "Test Name 1", Account = "Microsoft", Designation = "SE" });
            testData.Add(new { Name = "Test Name 2", Account = "Puma", Designation = "SSE" });
            testData.Add(new { Name = "Test Name 3", Account = "EOL", Designation = "Consultant" });
            testData.Add(new { Name = "Test Name 4", Account = "eLIMS NG", Designation = "Lead" });

            return Ok(testData);
        }

        [HttpGet]
        public string Demo()
        {
            return "Yep it's working!";
        }
    }
}
