using Microsoft.AspNetCore.Mvc;

namespace chathub.Controllers;

[ApiController]
[Route("/")]
public class HealthController : ControllerBase
{
    

    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHealth")]
    public string Get()
    {
        return "Assistant V 0.0.2";
    }
}
