using Microsoft.AspNetCore.SignalR;
using WebApi.Models;

namespace WebApi.Hubs;

public class ProfileHub : Hub
{
    public async Task JoinUserGroup(string userId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}");
    }

    public async Task UpdateProfile(string userId, UserProfile profile)
    {
        await Clients.Group($"user-{userId}").SendAsync("ProfileUpdated", profile);
    }
}
