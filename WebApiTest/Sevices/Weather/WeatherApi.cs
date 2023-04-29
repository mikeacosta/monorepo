namespace Sevices.Weather;

public class WeatherApi
{
    private HttpClient restClient = new HttpClient();
    private string URI = "https://api.weather.gov/alerts?area=MN&severity=severe";

    public async Task<string> GetReasonPhrase()
    {
        // build the URI
        restClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml,application");
        restClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        restClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:10.0) Gecko/20100101 Firefox/10.0");
        restClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
        
        // request
        var response = await restClient.GetAsync(URI);
        var reasonPhrase = response.ReasonPhrase?.ToString() ?? "";

        return reasonPhrase;
    }
}