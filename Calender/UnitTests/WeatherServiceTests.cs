using Calender.Models;
using Calender.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class WeatherServiceTests
    {
        // Mocked HTTP Client and Handler
        [TestMethod]
        public async Task GetWeatherData_ShouldReturnWeatherForecast_WhenResponseIsSuccessful()
        {
            // Arrange: Create a mock HttpMessageHandler to simulate HTTP responses
            var mockHandler = new Mock<HttpMessageHandler>();

            WeatherForecast mockWeatherForecast = new WeatherForecast
            {
                // Populate with relevant properties based on the WeatherForecast model
                Temperature = 22,
                Summary = "Sunny"
            };

            // Serialize mock response to JSON
            var mockResponseJson = JsonConvert.SerializeObject(mockWeatherForecast);

            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    It.IsAny<HttpRequestMessage>(),
                    It.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(mockResponseJson)
                });

            // Use the mock handler to create an HttpClient instance
            var httpClient = new HttpClient(mockHandler.Object);

            // Replace the client with the mock one in the method being tested (use dependency injection, if applicable)
            // In your case, the method creates a new HttpClient internally, so we would need to refactor to allow injecting the HttpClient

            // Act: Call the GetWeatherData method
            var result = await WeatherService.GetWeatherData(httpClient);

            // Assert: Verify the result
            Assert.IsNotNull(result);
            Assert.AreEqual(mockWeatherForecast.Temperature, result.Temperature);
            Assert.AreEqual(mockWeatherForecast.Summary, result.Summary);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task GetWeatherData_ShouldThrowException_WhenResponseIsNotSuccessful()
        {
            // Arrange: Create a mock HttpMessageHandler to simulate a failed response
            var mockHandler = new Mock<HttpMessageHandler>();

            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    It.IsAny<HttpRequestMessage>(),
                    It.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest)); // Simulate 400 Bad Request

            var httpClient = new HttpClient(mockHandler.Object);

            // Act: Call the GetWeatherData method and expect an exception
            await WeatherService.GetWeatherData(httpClient);
        }
    }
}
