using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IUserRepository : IDisposable
    {
        Task<blog_user> AddUser(blog_user user);
    }
}
