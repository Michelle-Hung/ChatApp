using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

public class ChatInfo
{
    public string Message { get; set; }
    public DateTime MessageTime { get; set; }
    public UserInfo SendTo { get; set; }
    public UserInfo SendBy { get; set; }
    public string MessageId { get; set; }
}

public class ContactInfo
{
    public List<UserInfo> Friends { get; set; }
}

public class UserInfo
{
    public string UserId { get; set; }
    public string DisplayName { get; set; }
}