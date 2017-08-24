﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBlogInfoRepository : IDisposable
    {
        Task<bloginfo> GetBlogInfo(int blogId);
        Task<postcontent> GetContent(int blogId);
        List<blog_tag> GetTags(int blogTagId);
        Task<bloginfo> GetPrevPost(int blogId);
        Task<bloginfo> GetNextPost(int blogId);
        Task<ICollection<blog_comment>> GetComments(int blogId);
        Task<bool> AddComment(blog_comment comment);
        Task<IEnumerable<bloginfo>> GetRelatedPosts(int blogTagId);
    }
}
