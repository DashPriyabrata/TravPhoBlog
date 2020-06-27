using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class SearchController : ApiController
    {
        ISearchRepository searchRepo;

        public SearchController()
        {
            searchRepo = new SearchRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/Search/Country/{countryName}")]
        public async Task<IHttpActionResult> GetAllBlogsOfCountry(string countryName)
        {
            return Ok(await searchRepo.GetAllCountryBlogs(countryName).ToListAsync());
        }
    }
}
