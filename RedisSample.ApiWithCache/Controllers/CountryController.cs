using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisSample.ApiWithCache.Repositories.Interface;
using RedisSample.ApiWithCache.ResponseModels;

namespace RedisSample.ApiWithCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        public CountryController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] ICountryRepository countryRepository,
            [FromServices] IDistributedCache cache)
        {
            const string KEY_COUNTRIES = "countries";
            var countriesCache = await cache.GetStringAsync(KEY_COUNTRIES);

            if(string.IsNullOrEmpty(countriesCache))
            {
                var countries = await countryRepository.GetAll();

                var countriesResponse = new CountriesResponse
                {
                    Countries = countries
                };

                countriesCache = JsonSerializer.Serialize(countriesResponse);

                var optionsCache = new DistributedCacheEntryOptions();
                optionsCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                await cache.SetStringAsync(KEY_COUNTRIES, countriesCache, optionsCache);
            }

            return Content(countriesCache, "application/json");
        }
    }
}