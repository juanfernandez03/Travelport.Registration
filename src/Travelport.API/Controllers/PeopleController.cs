using Microsoft.AspNetCore.Mvc;
using Travelport.Application.DTOs;
using Travelport.Application.Services;
using Travelport.Application.Validators;

namespace Travelport.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly PersonService _service;

    public PeopleController(PersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] CreatePersonCommand command,CancellationToken cancellationToken)
    {
        var validator = new CreatePersonValidator();
        var validation = validator.Validate(command);
        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        var person = await _service.RegisterAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = person.Id }, person);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var person = await _service.GetByIdAsync(id);
        return person is null ? NotFound() : Ok(person);
    }
}
