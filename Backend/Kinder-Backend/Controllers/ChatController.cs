using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Models;
using Kinder_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ChatController : ControllerBase
 {
     private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }
    [HttpGet]
    public async Task<ContactInfo> GetContacts(string userId)
    {
        return await _chatService.GetContactInfos(userId);
    }

    [HttpGet]
    public async Task<List<ChatListInfo>> GetRecentChatListInfos(string userId)
    {
        return await _chatService.GetRecentChatListInfosAsync(userId);
    }

    [HttpGet]
    public async Task<List<ChatInfo>> GetChatInfos (string userId)
    {
        return await _chatService.GetChatInfos(userId);
    }
}