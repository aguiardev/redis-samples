using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using RedisSample.ApiWithCache.Entities;
using RedisSample.ApiWithCache.Repositories.Interface;

namespace RedisSample.ApiWithCache.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration _configuration;
        private const string SqlGetAll = "SELECT Id, Name FROM Country";

        public CountryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<CountryEntity>> GetAll()
        {
            using(var connection = GetConnection())
            {
                return await connection.QueryAsync<CountryEntity>(SqlGetAll);
            }
        }

        public async Task<CountryEntity> GetById(int id)
        {
            using(var connection = GetConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<CountryEntity>(SqlGetAll, new { Id = id });
            }
        }

        private SqlConnection GetConnection()
            => new SqlConnection(_configuration.GetConnectionString("SqlServer"));
    }
}