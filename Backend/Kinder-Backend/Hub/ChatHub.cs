using System.Threading.Tasks;
using Kinder_Backend.Models;
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
    
    public async Task SendMessageAsync(SendMessageContent sendMessageContent)
    {
        
        await _chatService.InsertMessageAsync(sendMessageContent);
        await Clients.All.SendAsync("ReceiveMessage", sendMessageContent.Message, sendMessageContent.SendBy.DisplayName);
    }
}