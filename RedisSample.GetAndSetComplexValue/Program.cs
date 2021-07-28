using System;
using ServiceStack.Redis;

namespace RedisSample.GetAndSetComplexValue
{
    class Program
    {
        static void Main(string[] args)
        {
            const string host = "localhost:6379";
            var cpf1 = "30012876723";
            var cpf2 = "28826290012";
            var cpf3 = "28826290097";

            var client1 = new Client(cpf1) { Birth = new DateTime(1991,8,3), Name = "Beast Boy" };
            var client2 = new Client(cpf2) { Birth = new DateTime(1992,4,21), Name = "Raven" };

            using(var redisClient = new RedisClient(host))
            {
                redisClient.Set<Client>(cpf1, client1);
                redisClient.Set<Client>(cpf2, client2);

                var result1 = redisClient.Get<Client>(cpf1);
                var result2 = redisClient.Get<Client>(cpf2);
                var result3 = redisClient.Get<Client>(cpf3);

                Console.WriteLine(result1 == null ? "Not Found" : result1);
                Console.WriteLine(result2 == null ? "Not Found" : result2);
                Console.WriteLine(result3 == null ? "Not Found" : result3);
            }
        }
    }
}
