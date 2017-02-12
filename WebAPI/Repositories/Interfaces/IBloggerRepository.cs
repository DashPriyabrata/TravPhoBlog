using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IBloggerRepository
    {
        Task<blogger> GetBlogger(int bloggerId);
        Task<ICollection<blogger>> GetAll();
    }
}
