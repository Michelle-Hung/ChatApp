using System;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Models;

public class ChatListInfo
{
    public DateTime ChannelCreatedOn { get; set; }
    public string ChannelId { get; set; }
    public string ChannelName { get; set; }
    public string ChannelType { get; set; }
    public ChatInfo ChatInfo { get; set; }
}