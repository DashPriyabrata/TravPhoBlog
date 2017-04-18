using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    
    public class BlogInfoController : ApiController
    {
        IBlogInfoRepository blogInfoRepo;

        public BlogInfoController()
        {
            blogInfoRepo = new BlogInfoRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(bloginfo))]
        [Route("api/BlogInfo/{blogId}")]
        public async Task<IHttpActionResult> GetBlogInfo(int blogId)
        {
            return Ok(await blogInfoRepo.GetBlogInfo(blogId));
        }

        [ResponseType(typeof(postcontent))]
        [Route("api/BlogInfo/PostContent/{contentId}")]
        public async Task<IHttpActionResult> GetPostContent(int contentId)
        {
            return Ok(await blogInfoRepo.GetContent(contentId));
        }

        [ResponseType(typeof(blog_user))]
        [Route("api/BlogInfo/NextUser/{blogId}")]
        public async Task<IHttpActionResult> GetNextUser(int blogId)
        {
            return Ok(await blogInfoRepo.GetNextPost(blogId));
        }

        [ResponseType(typeof(List<blog_comment>))]
        [Route("api/BlogInfo/Comments/{blogId}")]
        public async Task<IHttpActionResult> GetComments(int blogId)
        {
            return Ok(await blogInfoRepo.GetComments(blogId));
        }

        [HttpPost]
        [Route("api/BlogInfo/AddComment")]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> AddComment([FromBody] blog_comment comment)
        {
            return Ok(await blogInfoRepo.AddComment(comment));
        }
    }
}
