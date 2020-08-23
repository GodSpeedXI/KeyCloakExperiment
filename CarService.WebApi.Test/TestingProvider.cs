using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.WebApi.Test
{
    public class TestingProvider
    {
        protected readonly WebApplicationFactory<Startup> _factory;
        protected readonly HttpClient _Client;

        public TestingProvider()
        {
            _factory = new WebApplicationFactory<Startup>();
            _Client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    //services.AddTransient<IPolicyEvaluator, FakePolicyEvaluator>();
                });
            }).CreateClient();
        }
    }
}
