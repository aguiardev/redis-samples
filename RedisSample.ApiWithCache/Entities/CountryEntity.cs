using Dapper.Contrib.Extensions;

namespace RedisSample.ApiWithCache.Entities
{
    [Table("dbo.Country")]
    public class CountryEntity
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}