using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface ISocialConnectRepository
    {
        Task<ICollection<instagram>> GetInstagramRecentMedia();
    }
}
