﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBlogInfoRepository : IDisposable
    {
        Task<bloginfo> GetBlogInfo(int blogId);
        Task<ICollection<bloginfo>> GetAll();
        Task<postcontent> GetContent(int blogId);
        Task<blog_user> GetPrevPost(int blogId);
        Task<blog_user> GetNextPost(int blogId);
        Task<List<blog_comment>> GetComments(int blogId);
        Task<bool> AddComment(blog_comment comment);
    }
}
