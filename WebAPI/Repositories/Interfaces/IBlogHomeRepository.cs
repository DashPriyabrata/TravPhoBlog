﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBlogHomeRepository
    {
        Task<IEnumerable<bloginfo>> GetAll();
        Task<IEnumerable<bloginfo>> GetPrecisePosts(int skippedCount, int requiredCount);
        Task<int> GetTotalBlogCount();
        Task<IEnumerable<bloginfo>> GetFeaturedPosts();
        Task<IEnumerable<bloginfo>> GetTrendingPosts();
        Task<IEnumerable<blog_category>> GetAllCategoriesWithBlogCount();
        Task<IEnumerable<bloginfo>> GetFavouritePosts();
    }
}
