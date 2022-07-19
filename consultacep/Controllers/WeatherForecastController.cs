using Microsoft.AspNetCore.Mvc;

namespace consultacep.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [Route("getcep/{cep}")]
    public string GetEnumerable(string cep)
    {
        if (string.IsNullOrEmpty(cep))
            cep = "05126040";

        string dados = string.Empty;
        using (HttpClient cl = new HttpClient())
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            dados = cl.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        return dados;
    }
}
