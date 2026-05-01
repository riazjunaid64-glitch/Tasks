using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ride_sharing_api.Data;

namespace ride_sharing_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RideController : ControllerBase
{
    private readonly AppDbContext _context;

    public RideController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetRides()
    {
        var rides = await _context.Rides
            .Include(r => r.Rider)
            .Include(r => r.Driver)
            .Include(r => r.Vehicle)
            .Include(r => r.PickupLocation)
            .Include(r => r.DropoffLocation)
            .ToListAsync();

        return Ok(rides);
    }
}