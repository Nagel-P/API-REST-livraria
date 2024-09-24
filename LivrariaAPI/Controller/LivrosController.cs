using Microsoft.AspNetCore.Mvc;

namespace LivrariaAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Exemplo de retorno de dados
            return Ok(new[]
            {
                new { Date = DateTime.Now, TemperatureC = 25, Summary = "Sunny" },
                new { Date = DateTime.Now.AddDays(1), TemperatureC = 22, Summary = "Cloudy" }
            });
        }
    }
}
