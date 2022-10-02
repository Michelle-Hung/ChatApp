using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public interface IChatService
{
    Task<ContactInfo> GetContactInfos(string userId);
    Task<List<ChatInfo>> GetChatInfos(string userId);
    Task<List<ChatListInfo>> GetRecentChatListInfosAsync(string userId);
}