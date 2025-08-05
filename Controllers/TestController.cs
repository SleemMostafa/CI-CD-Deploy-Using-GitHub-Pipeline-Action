using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CI_CD_Deploy_Using_GitHub_Pipeline_Action.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("health")]
    [AllowAnonymous]
    public IActionResult HealthCheck()
    {
        return Ok(new
        {
            status = "Healthy",
            timestamp = DateTime.UtcNow
        });
    }

    [HttpPost("contact")]
    [AllowAnonymous]
    public IActionResult SubmitContactForm([FromBody] ContactFormRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest("Email and message are required.");
        }

        return Ok(new
        {
            message = "Your message has been received.",
            receivedAt = DateTime.UtcNow
        });
    }

    [HttpGet("public-info")]
    [AllowAnonymous]
    public IActionResult GetPublicInfo()
    {
        return Ok(new
        {
            appName = "My Sample API",
            version = "1.0.0",
            description = "This is a public API for testing purposes."
        });
    }
}

public class ContactFormRequest
{
    public required string Name { get; init; } 
    public required string Email { get; init; } 
    public required string Message { get; init; }
}