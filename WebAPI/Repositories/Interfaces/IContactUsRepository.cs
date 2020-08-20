using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface IContactUsRepository : IDisposable
    {
        Task<IEnumerable<contactus>> GetAllRecords();
        Task<bool> AddRecord(contactus submission);
        Task<bool?> UpdateIsAdminReadProperty(int id);
    }
}
