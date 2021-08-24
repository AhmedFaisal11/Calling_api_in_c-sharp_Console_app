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
            try
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

                    string[] result =
                    {
                        string.Concat("Country : ", obj["location"]["country"]),
                        string.Concat("Area : ", obj["location"]["name"]),
                        string.Concat("Latitude : " , obj["location"]["lat"]),
                        string.Concat("Longtitude : " , obj["location"]["lon"]),
                        string.Concat("Time Zone : ", obj["location"]["tz_id"]),
                        string.Concat("Temprature (Celcius) : ", obj["current"]["temp_c"]),
                        string.Concat("Temprature (Farhenhiet) : ", obj["current"]["temp_f"]),
                        string.Concat("Wheather  : ", obj["current"]["condition"]["text"]),
                        string.Concat("Humadity  : ", obj["current"]["humidity"])
                    };

                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }

                    Console.ReadLine();
                }
            

            }
            catch (Exception)
            {
                string err = "City Not Found ! Please Enter a Valid City ";
                Console.WriteLine(err);
                Console.ReadLine();
            }

            
        }
    }

}
