using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBlogTagRepository : IDisposable
    {
        List<blog_tag> GetTags(int blogTagId);
        Task<ICollection<blog_tag>> GetAllTags();
    }
}
