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
        IBlogTagRepository blogTagRepo;

        public BlogInfoController()
        {
            blogInfoRepo = new BlogInfoRepository(new MyTravelBlogEntities());
            blogTagRepo = new BlogTagRepository(new MyTravelBlogEntities());
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

        [ResponseType(typeof(List<blog_tag>))]
        [Route("api/BlogInfo/Tags/{blogTagId}")]
        public async Task<IHttpActionResult> GetTags(int blogTagId)
        {
            return Ok(blogTagRepo.GetTags(blogTagId));
        }

        [ResponseType(typeof(bloginfo))]
        [Route("api/BlogInfo/PrevPost/{blogId}")]
        public async Task<IHttpActionResult> GetPrevPost(int blogId)
        {
            return Ok(await blogInfoRepo.GetPrevPost(blogId));
        }

        [ResponseType(typeof(bloginfo))]
        [Route("api/BlogInfo/NextPost/{blogId}")]
        public async Task<IHttpActionResult> GetNextPost(int blogId)
        {
            return Ok(await blogInfoRepo.GetNextPost(blogId));
        }

        [ResponseType(typeof(IEnumerable<bloginfo>))]
        [Route("api/BlogInfo/RelatedPosts/{blogTagId}")]
        public async Task<IHttpActionResult> GetRelatedPosts(int blogTagId)
        {
            return Ok(await blogInfoRepo.GetRelatedPosts(blogTagId));
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
