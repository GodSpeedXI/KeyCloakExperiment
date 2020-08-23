using System;
using Xunit;

namespace CarService.WebApi.Test
{
    public class CarServiceApiTest : TestingProvider
    {
        [Fact]
        public async void AddCar_CanAdd_ReturnAuthFail()
        {
            var resultContext = await _Client.GetAsync("CarService");

            Assert.False(resultContext.IsSuccessStatusCode);
        }
    }
}
