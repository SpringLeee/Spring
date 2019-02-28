using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DoAsync(); 

        }

        public static void DoAsync()
        { 

            var client = new HttpClient();

            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5000/").Result;


            var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest {

                Address = disco.TokenEndpoint,
                ClientId = "console client",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                Scope = "api1 openid"
            }).Result;


            // 呼叫API

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var apiResponse = apiClient.GetStringAsync(disco.UserInfoEndpoint).Result;



            Console.ReadKey();  
        }

    }
}
