using MediatR;
using Microsoft.AspNetCore.Mvc;
using VetCheckupAPI.Models;

namespace VetCheckupAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null)
            return NotFound();
        if (result.IsSuccess && result.Value != null)
            return Ok(result.Value);        
        if (result.IsSuccess && result.Value == null)
            return NoContent();
        if (!result.IsSuccess && string.IsNullOrEmpty(result.Error))
           return BadRequest("An unknown error occurred.");

        return BadRequest(result.Error);
    }
}