using Microsoft.AspNetCore.Mvc;
using BeerCollection.Application.Interfaces;
using BeerCollection.Application.DTOs;

[ApiController]
[Route("api/[controller]")]
public class BeersController : ControllerBase
{
    private readonly IBeerService _service;

    public BeersController(IBeerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateBeerDto dto)
    {
        await _service.AddBeerAsync(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string query)
    {
        return Ok(await _service.SearchAsync(query));
    }

    [HttpPost("{id}/rate")]
    public async Task<IActionResult> Rate(Guid id, RateBeerDto dto)
    {
        await _service.RateBeerAsync(id, dto.Rating);
        return Ok();
    }
}