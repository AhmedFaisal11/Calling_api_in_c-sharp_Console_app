using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace apiCall2
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("please Enter A City Name : ");
            string city = Console.ReadLine();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherapi-com.p.rapidapi.com/current.json?q= {city}"),
                Headers =
                {
                    { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                    { "x-rapidapi-key", "a93015729emsh9d7cc27bdc028bfp18718cjsn5cee2cc88094" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                JObject obj = JObject.Parse(body);
                /*Console.WriteLine(obj);*/


                Console.WriteLine("=======================================================");

                Console.WriteLine(string.Concat("Country : ", obj["location"]["country"]));
                Console.WriteLine(string.Concat("Area : ", obj["location"]["name"]));
                Console.WriteLine(string.Concat("latitude : ", obj["location"]["lat"]));
                Console.WriteLine(string.Concat("longtitude : ", obj["location"]["lon"]));
                Console.WriteLine(string.Concat("Time Zone : ", obj["location"]["tz_id"]));
                Console.WriteLine(string.Concat("Temprature (Celcius) : ", obj["current"]["temp_c"]));
                Console.WriteLine(string.Concat("Temprature (Farhenhiet) : ", obj["current"]["temp_f"]));
                Console.WriteLine(string.Concat("Wheather  : ", obj["current"]["condition"]["text"]));
                Console.WriteLine(string.Concat("Humadity  : ", obj["current"]["humidity"]));





            }
        }
    }

}
