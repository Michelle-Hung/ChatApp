using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Controllers;
using Kinder_Backend.Hub;
using Kinder_Backend.Models;

namespace Kinder_Backend.Services;

public interface IFireStoreProxy
{
    Task InsertUserInfo(AccountInfoDto accountInfoDto);
    Task<List<AccountInfoDto>> GetAccountInfos();
    Task<AccountInfoDto> GetAccountInfo(LoginRequest request);
    Task<IEnumerable<ProfileDto>> GetContactProfiles(string userId);
    Task<IEnumerable<ChannelDto>> GetChannelsAsync(string userId);
    Task<IEnumerable<ChatInfo>> GetChatInfosByUserAsync(string userId);
    Task InsertMessageAsync(SendMessageContent sendMessageContent);
}