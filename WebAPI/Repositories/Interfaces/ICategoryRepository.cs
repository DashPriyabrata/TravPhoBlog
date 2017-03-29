using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface ICategoryRepository : IDisposable
    {
        Task<category> GetCategory(int categoryId);
        Task<ICollection<category>> GetAll();
    }
}
