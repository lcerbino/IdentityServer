using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cliente
{
    public class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            //var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            //if (disco.IsError)
            //{
            //    throw new Exception("error");

            //}
            //var TokenCliente = new TokenClient(disco.TokenEndpoint, "Cliente1", "secreto");
            //var TokenResponse = await TokenCliente.RequestClientCredentialsAsync("resourceApi1");

            //if (TokenResponse.IsError)
            //{
            //    throw new Exception("error");
            //}

            var tokenResponse = Token.GetTokenResponseAsync().Result;
            //var tokenJson = TokenResponse.Json;

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/Values");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error");

            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
            }

        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
    }
}
