using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace consultacep.Controllers;

[ApiController]
[Route("[controller]")]
public class ZipCodeController : ControllerBase
{

    private readonly ILogger<ZipCodeController> _logger;

    public ZipCodeController(ILogger<ZipCodeController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    [Route("getcep/{cep}")]
    public IActionResult GetEnumerable(string cep)
    {
        if (string.IsNullOrEmpty(cep))
            cep = "05126040";

        string retorno = string.Empty;
        using (HttpClient cl = new HttpClient())
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";
            retorno = cl.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

        }

        return Ok(retorno);
    }
}
