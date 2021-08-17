using System.Collections.Generic;
using RedisSample.ApiWithCache.Entities;

namespace RedisSample.ApiWithCache.ResponseModels
{
    public class CountriesResponse
    {
        public IEnumerable<CountryEntity> Countries { get; set; }
    }
}