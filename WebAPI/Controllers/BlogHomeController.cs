﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class BlogHomeController : ApiController
    {
        IBlogHomeRepository blogHomeRepo;
        IBlogTagRepository blogTagRepo;

        public BlogHomeController()
        {
            blogHomeRepo = new BlogHomeRepository(new MyTravelBlogEntities());
            blogTagRepo = new BlogTagRepository(new MyTravelBlogEntities());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/BlogHome/All")]
        public async Task<IHttpActionResult> GetAllPosts()
        {
            return Ok(await blogHomeRepo.GetAll());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/BlogHome/Precise/{startIndex}/{numOfPosts}")]
        public async Task<IHttpActionResult> GetPrecisePosts(int startIndex, int numOfPosts)
        {
            return Ok(await blogHomeRepo.GetPrecisePosts(startIndex, numOfPosts));
        }

        [ResponseType(typeof(int))]
        [Route("api/BlogHome/TotalBlogCount")]
        public async Task<IHttpActionResult> GetBlogsCount()
        {
            return Ok(await blogHomeRepo.GetTotalBlogCount());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/BlogHome/Featured")]
        public async Task<IHttpActionResult> GetFeaturedPosts()
        {
            return Ok(await blogHomeRepo.GetFeaturedPosts());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/BlogHome/Trending")]
        public async Task<IHttpActionResult> GetTrendingPosts()
        {
            return Ok(await blogHomeRepo.GetTrendingPosts());
        }

        [ResponseType(typeof(List<blog_tag>))]
        [Route("api/BlogHome/AllCatsWithPostCount")]
        public async Task<IHttpActionResult> GetAllCategoriesWithBlogCount()
        {
            return Ok(await blogHomeRepo.GetAllCategoriesWithBlogCount());
        }

        [ResponseType(typeof(List<bloginfo>))]
        [Route("api/BlogHome/Favourite")]
        public async Task<IHttpActionResult> GetFavouritePosts()
        {
            return Ok(await blogHomeRepo.GetFavouritePosts());
        }
    }
}
