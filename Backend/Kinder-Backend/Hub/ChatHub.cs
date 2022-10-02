using System.Threading.Tasks;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.SignalR;

namespace Kinder_Backend.Hub;

public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
{
    private readonly IChatService _chatService;

    public ChatHub(IChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task SendMessageAsync(string message, string userName)
    {
        
        // await _chatService.InsertMessageAsync(chatInfo);
        await Clients.All.SendAsync("ReceiveMessage", message, userName);
    }
}
