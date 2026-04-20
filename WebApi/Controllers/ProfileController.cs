using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IHubContext<ProfileHub> _hubContext;
    private static readonly Dictionary<string, UserProfile> _profiles = new();

    public ProfileController(IHubContext<ProfileHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet("{userId}")]
    public IActionResult Get(string userId)
    {
        if (!_profiles.ContainsKey(userId))
            _profiles[userId] = new UserProfile { Name = "Initial", Age = 0 };
        return Ok(_profiles[userId]);
    }

    [HttpPost("{userId}/name")]
    public async Task<IActionResult> UpdateName(string userId, [FromBody] string newName)
    {
        var profile = _profiles.GetValueOrDefault(userId);
        if (profile == null) return NotFound();

        profile.Name = newName;
        await _hubContext.Clients.Group($"user-{userId}").SendAsync("ProfileUpdated", profile);

        return Ok(profile);
    }

    [HttpPost("{userId}/age")]
    public async Task<IActionResult> UpdateAge(string userId, [FromBody] int newAge)
    {
        var profile = _profiles.GetValueOrDefault(userId);
        if (profile == null) return NotFound();

        profile.Age = newAge;
        await _hubContext.Clients.Group($"user-{userId}").SendAsync("ProfileUpdated", profile);

        return Ok(profile);
    }
}
