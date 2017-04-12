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
    public class UserController : ApiController
    {
        IUserRepository userRepo;

        public UserController()
        {
            userRepo = new UserRepository(new MyTravelBlogEntities());
        }

        [HttpPost]
        [Route("api/User/Add")]
        [ResponseType(typeof(blog_user))]
        public async Task<IHttpActionResult> AddUser([FromBody] blog_user user)
        {
            return Ok(await userRepo.AddUser(user));
        }
    }
}
