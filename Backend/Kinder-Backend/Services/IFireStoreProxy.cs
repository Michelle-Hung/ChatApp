using System.Collections.Generic;
using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public interface IFireStoreProxy
{
    Task InsertUserInfo(AccountInfoDto accountInfoDto);
    Task<List<AccountInfoDto>> GetAccountInfos();
    Task<AccountInfoDto> GetAccountInfo(LoginRequest request);
    Task<IEnumerable<ProfileDto>> GetContactProfiles(string userId);
    Task<IEnumerable<ChannelDto>> GetChannelsAsync(string userId);
    Task<IEnumerable<ChatInfo>> GetChatInfosByUserAsync(string userId);
    Task InsertMessageAsync(object chatInfo);
}