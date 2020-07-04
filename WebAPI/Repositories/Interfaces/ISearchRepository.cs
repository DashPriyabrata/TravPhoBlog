using System;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface ISearchRepository : IDisposable
    {
        IQueryable<bloginfo> GetAllCountryBlogs(string countryName);
        IQueryable<bloginfo> GetAllCityBlogs(string cityName);
    }
}