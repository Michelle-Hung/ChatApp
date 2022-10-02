using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public class ChatService : IChatService
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public ChatService(IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    public async Task<ContactInfo> GetContactInfos(string userId)
    {
        var profileDtos = await _fireStoreProxy.GetContactProfiles(userId);
        var friendInfos = profileDtos.Select(x => new UserInfo
        {
            UserId = x.AccountId,
            DisplayName = x.DisplayName
        }).OrderBy(x => x.DisplayName).ToList();
        return new ContactInfo
        {
            Friends = friendInfos,
        };
    }

    public async Task<List<ChatInfo>> GetChatInfos(string userId)
    {
        return (await _fireStoreProxy.GetChatInfosByUserAsync(userId)).ToList();
    }

    public async Task<List<ChatListInfo>> GetRecentChatListInfosAsync(string userId)
    {
        var channelDtos = await _fireStoreProxy.GetChannelsAsync(userId);
        var chatInfos = await _fireStoreProxy.GetChatInfosByUserAsync(userId);

        return (from channelDto in channelDtos
            let latestChatInfo = channelDto.MessageIds
                .Join(chatInfos, messageId => messageId, chatInfo => chatInfo.MessageId, (_, chatInfo) => chatInfo)
                .OrderByDescending(x => x.MessageTime).First()
            select new ChatListInfo()
            {
                ChannelId = channelDto.Id,
                ChannelCreatedOn = channelDto.CreatedOn.ToDateTime(),
                ChatInfo = latestChatInfo,
                ChannelName = string.Equals(channelDto.Type, "Direct") ? latestChatInfo.SendTo.DisplayName : channelDto.Name ,
                ChannelType = channelDto.Type
            }).ToList();
    }
}

public class ChatListInfo
{
    public string ChannelId { get; set; }
    public string ChannelName { get; set; }
    public string ChannelType { get; set; }
    public DateTime ChannelCreatedOn { get; set; }
    public ChatInfo ChatInfo { get; set; }
}