using Bogus;
using Microsoft.Extensions.Configuration;
using Redis.Utils;
using System;
using System.IO;
using System.Threading;

namespace Redis.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var channelName = builder.GetChannelName();
            var redis = builder.GetConnection();
            var pub = redis.GetSubscriber();
            var faker = new Faker();

            var timer = new Timer(
                (object o) =>
                {
                    pub.Publish(channelName, faker.Lorem.Paragraph());
                },
                null,
                0,
                5000);

            Console.WriteLine("[Publisher] Connected on channel: " + channelName);
            Console.ReadKey();
        }
    }
}