using System.Collections.Generic;
using System.Threading.Tasks;
using RedisSample.ApiWithCache.Entities;

namespace RedisSample.ApiWithCache.Repositories.Interface
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryEntity>> GetAll();
        Task<CountryEntity> GetById(int id);
    }
}