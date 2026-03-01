using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace FullstackApp.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class ActivitiesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        var data = await context.Activities.ToListAsync();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        var data = await context.Activities.FindAsync(id);

        if (data == null) return NotFound();
        
        return data;
    }
}