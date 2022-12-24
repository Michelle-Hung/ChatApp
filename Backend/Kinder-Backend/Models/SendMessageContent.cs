namespace Kinder_Backend.Models;

public class SendMessageContent
{
    public UserInfo SendBy { get; set; }
    public UserInfo SendTo { get; set; }
    public string RoomId { get; set; }
    public string Message { get; set; }
}