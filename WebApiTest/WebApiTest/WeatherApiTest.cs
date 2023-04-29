using Sevices.Weather;

namespace WebApiTest;

public class WeatherApiTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Category("APITests")]
    public async Task ApiTest()
    {
        WeatherApi weatherApi = new WeatherApi();
        var actual = await weatherApi.GetReasonPhrase();
        Assert.That(actual, Is.EqualTo("OK"));
    }
}