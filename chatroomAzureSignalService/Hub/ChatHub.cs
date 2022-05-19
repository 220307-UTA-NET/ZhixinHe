using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chatroom.Hubs;
public class ChatHub : Hub
{
    public Task BroadcastMessage(string name, string message)
    {
        return Clients.All.SendAsync("broadcastMessage", name, message);
    }
    public Task Echo(string name, string message)
    {
        return Clients.Client(Context.ConnectionId).SendAsync("echo", name, message);
    }
}