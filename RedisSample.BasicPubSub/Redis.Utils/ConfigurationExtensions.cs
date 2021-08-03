using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;

namespace Redis.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfigurationRoot builder)
        {
            var section = builder.GetSection("ConnectionStrings");
            
            return section["Redis"];
        }

        public static string GetChannelName(this IConfigurationRoot builder)
            => builder["channelName"];

        public static ConnectionMultiplexer GetConnection(this IConfigurationRoot builder)
        {
            var connectionString = builder.GetConnectionString();

            return ConnectionMultiplexer.Connect(connectionString);
        }
    }
}
