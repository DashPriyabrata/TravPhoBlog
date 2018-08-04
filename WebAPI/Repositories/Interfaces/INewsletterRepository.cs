using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    interface INewsletterRepository : IDisposable
    {
        Task<string> AddSubscriber(newsletter_sub subscriber);
        Task<ICollection<newsletter_sub>> GetAllSubscribers();
        Task<bool> Unsubscribe(int id, string emailKey);
    }
}
