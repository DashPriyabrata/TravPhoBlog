﻿using System;
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

        [ResponseType(typeof(List<blog_comment>))]
        [Route("api/BlogInfo/Comments/{blogId}")]
        public async Task<IHttpActionResult> GetComments(int blogId)
        {
            return Ok(await blogInfoRepo.GetComments(blogId));
        }
    }
}
