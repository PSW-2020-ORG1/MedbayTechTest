using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MedbayTech.Feedback.Domain.Entities;
using Newtonsoft.Json;


namespace MedbayTech.Feedback.Infrastructure.Gateways
{
    public class RestClient
    {

        private List<User> users { get; set; }

        public List<User> GetUsers()
        {
            using HttpClient client = new HttpClient();
            var task = client.GetAsync(GetUsersDomain() + "/api/user")
                .ContinueWith((taskWithResponse) =>
                {
                    var message = taskWithResponse.Result;
                    var json = message.Content.ReadAsStringAsync();
                    json.Wait();
                    users = JsonConvert.DeserializeObject<List<User>>(json.Result);
                });
            task.Wait();

            return users;

        }

        private string GetUsersDomain()
        {
            string origin = Environment.GetEnvironmentVariable("URL") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "8081";

            return $"http://{origin}:{port}";
        }
    }
}
