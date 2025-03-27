using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetCheckupAPI.Models;

namespace VetCheckupAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    public IMediator Mediator { get; } = null!;

    protected ActionResult HandleResult<T>(Result<T>? result)
    {
        if (result == null)
            return NotFound();
        if (result.IsSuccess && result.Value != null)
            return Ok(result.Value);        
        if (result.IsSuccess && result.Value == null)
            return NotFound();
        if (!result.IsSuccess && string.IsNullOrEmpty(result.Error))
           return BadRequest("An unknown error occurred.");

        return BadRequest(result.Error);
    }
}