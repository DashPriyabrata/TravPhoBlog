using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBlogInfoRepository : IDisposable
    {
        Task<bloginfo> GetBlogInfo(int blogId);
        Task<ICollection<bloginfo>> GetAll();
    }
}
