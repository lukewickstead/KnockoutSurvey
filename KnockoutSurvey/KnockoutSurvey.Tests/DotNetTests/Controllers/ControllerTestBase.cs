using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace KnockoutSurvey.Tests.DotNetTests.Controllers
{
    public abstract class ControllerTestBase
    {
        private readonly HttpClient _client;
       
        protected ControllerTestBase()
        {
            var server = new TestServer(
                new WebHostBuilder().UseStartup<Startup>());

            _client = server.CreateClient();
        }
        
        protected StringContent GetPostPayloadAsJasonAndUTF8Encoding<T>(T model)
        {
            var content = JsonConvert.SerializeObject(model);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
        
        protected async Task<HttpResponseMessage> PostAsJson<T>(string endPoint, T model )
        {
            var postPayload = GetPostPayloadAsJasonAndUTF8Encoding(model);
            return await _client.PostAsync(endPoint, postPayload);
        }
        
        protected async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}