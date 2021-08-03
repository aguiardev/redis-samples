using Microsoft.Extensions.Configuration;
using Redis.Utils;
using System;
using System.IO;

namespace Redis.Consumer
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
            var sub = redis.GetSubscriber();
            
            sub.Subscribe(channelName, (channel, message) => {
                Console.WriteLine($"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}]: {(string)message}");
            });

            Console.WriteLine("[Consumer] Connected on channel: " + channelName);
            Console.ReadKey();
        }
    }
}