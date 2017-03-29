using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryRepository categoryRepo;

        public CategoryController()
        {
            categoryRepo = new CategoryRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(category))]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            return Ok(await categoryRepo.GetCategory(id));
        }

        [ResponseType(typeof(List<category>))]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok(await categoryRepo.GetAll());
        }
    }
}