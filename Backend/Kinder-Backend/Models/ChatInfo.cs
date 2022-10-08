using System;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Models;

public class ChatInfo
{
    public string Message { get; set; }
    public DateTime MessageTime { get; set; }
    public UserInfo SendTo { get; set; }
    public UserInfo SendBy { get; set; }
    public string MessageId { get; set; }
}