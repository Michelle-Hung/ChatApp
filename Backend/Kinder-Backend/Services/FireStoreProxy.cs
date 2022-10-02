using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Kinder_Backend.Controllers;
using Kinder_Backend.Helper;

namespace Kinder_Backend.Services;

public class FireStoreProxy : IFireStoreProxy
{
    private readonly FirestoreDb _firestoreDb;

    public FireStoreProxy(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public async Task Insert<T>(T data, string tableName)
    {
        var docRef = _firestoreDb.Collection(tableName).Document();
        await docRef.SetAsync(data);
    }

    public async Task<List<T>> Get<T>(string tableName) where T : class, new()
    {
        var collectionReference = _firestoreDb.Collection(tableName);
        var snapshotAsync = await collectionReference.GetSnapshotAsync();
        return snapshotAsync.Documents.Select(x => x.ToDictionary().ToObject<T>()).ToList();
    }

    public async Task<IEnumerable<ProfileDto>> GetContactProfiles(string userId)
    {
        var contactInfoDto = (await _firestoreDb.Collection("Contact").WhereEqualTo("AccountId", userId).GetSnapshotAsync()).Documents.Select(x => x.ToDictionary().ToObject<ContactInfoDto>()).First();
        var profileDtos = (await _firestoreDb.Collection("Profile").WhereIn("AccountId", contactInfoDto.Friends)
            .GetSnapshotAsync()).Documents.Select(x => x.ToDictionary().ToObject<ProfileDto>());

        return profileDtos;
    }

    private async Task<IEnumerable<MessageDto>> GetMessagesByUserAsync(string userId)
    {
        var messageDtos = (await _firestoreDb.Collection("Message").GetSnapshotAsync()).Documents.Select(x =>
            x.ToDictionary().ToObject<MessageDto>());
        return messageDtos.Where(x => x.SendBy == userId || x.SendTo == userId);
    }
    
    public async Task<IEnumerable<ChatInfo>> GetChatInfosByUserAsync(string userId)
    {
        var messagesByUserAsync = await GetMessagesByUserAsync(userId);
        var profileDtos = await GetProfilesAsync();
        var chatInfos = messagesByUserAsync.Select(messageDto => new ChatInfo
        {
            MessageId = messageDto.MessageId,
            Message = messageDto.Content,
            MessageTime = messageDto.CreatedOn.ToDateTime(),
            SendTo = new UserInfo
            {
                UserId = messageDto.SendTo,
                DisplayName = profileDtos.Single(x => x.AccountId == messageDto.SendTo).DisplayName
            },
            SendBy = new UserInfo
            {
                UserId = messageDto.SendBy,
                DisplayName = profileDtos.Single(x => x.AccountId == messageDto.SendBy).DisplayName
            }
        });
        return chatInfos;
    }

    private async Task<IEnumerable<ProfileDto>> GetProfilesAsync()
    {
        var profileDtos = (await _firestoreDb.Collection("Profile").GetSnapshotAsync()).Documents.Select(x => x.ToDictionary().ToObject<ProfileDto>());
        return profileDtos;
    }

    public async Task<IEnumerable<ChannelDto>> GetChannelsAsync(string userId)
    {
        var channelDtos = (await _firestoreDb.Collection("Channel").WhereArrayContains("Members", userId).GetSnapshotAsync()).Documents.Select(x =>
            x.ToDictionary().ToObject<ChannelDto>());
        return channelDtos;
    }

    public async Task InsertUserInfo(AccountInfoDto accountInfoDto)
    {
        var docRef = _firestoreDb.Collection("users").Document();
        await docRef.SetAsync(accountInfoDto.AsDictionary());
    }

    public async Task<List<AccountInfoDto>> GetAccountInfos()
    {
        return (await _firestoreDb.Collection("Account").GetSnapshotAsync()).Documents.Select(x => x.ToDictionary().ToObject<AccountInfoDto>()).ToList();
    }

    public async Task<AccountInfoDto> GetAccountInfo(LoginRequest request)
    {
        var accountQuery = _firestoreDb.Collection("Account").WhereEqualTo("LoginName",request.Name).WhereEqualTo("Passwords", request.Password);
        var accountInfo = (await accountQuery.GetSnapshotAsync()).Documents.Select(x => x.ToDictionary().ToObject<AccountInfoDto>()).FirstOrDefault();
        if (accountInfo == null)
        {
            throw new AuthenticationException();
        }

        return accountInfo;
    }
}

[FirestoreData]
public class ChannelDto
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public List<object> MessageIds { get; set; }
    [FirestoreProperty]
    public string Name { get; set; }
    [FirestoreProperty]
    public string Type { get; set; }
    [FirestoreProperty]
    public Timestamp CreatedOn { get; set; }
}

[FirestoreData] 
public class ProfileDto
{
    [FirestoreProperty]
    public string AccountId { get; set; }
    [FirestoreProperty]
    public string DisplayName { get; set; }
    [FirestoreProperty]
    public string Email { get; set; }
}

[FirestoreData]
public class ContactInfoDto
{
    [FirestoreProperty]
    public string AccountId { get; set; }
    [FirestoreProperty]
    public List<object> Friends { get; set; }    
 }

[FirestoreData]
public class MessageDto
{
    [FirestoreProperty]
    public string MessageId { get; set; }
    [FirestoreProperty]
    public string SendBy { get; set; }
    [FirestoreProperty]
    public string SendTo { get; set; }
    [FirestoreProperty]
    public string Content { get; set; }
    [FirestoreProperty]
    public Timestamp CreatedOn { get; set; }
}

[FirestoreData]
public class RoomDto
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public string Name { get; set; }
    [JsonIgnore]
    [FirestoreProperty]
    public long Status { get; set; }

    public EnumRoomStatus RoomStatus => (EnumRoomStatus)(int)Status;

    [JsonIgnore]
    [FirestoreProperty]
    public long Type { get; set; }

    public EnumRoomType RoomType => (EnumRoomType) (int) Type;

    [FirestoreProperty]
    public Timestamp CreateTime { get; set; }
}

public enum EnumRoomType
{
    Direct = 1,
    Group = 2
}

public enum EnumRoomStatus
{
    Active = 1,
    Archive = 2,
}

[FirestoreData]
public class ChatDto
{
    [FirestoreProperty]
    public string UserId { get; set; }
    [FirestoreProperty]
    public string RoomId { get; set; }
    [FirestoreProperty]
    public string Message { get; set; }
    [FirestoreProperty]
    public Timestamp CreateTime { get; set; }
}

[FirestoreData]
public class AccountInfoDto
{
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public string LoginName { get; set; }
    [FirestoreProperty]
    public string Passwords { get; set; }
}

public interface IFireStoreProxy
{
    Task InsertUserInfo(AccountInfoDto accountInfoDto);
    Task<List<AccountInfoDto>> GetAccountInfos();
    Task<AccountInfoDto> GetAccountInfo(LoginRequest request);
    Task Insert<T>(T data, string tableName);
    Task<List<T>> Get<T>(string tableName) where T : class, new();
    Task<IEnumerable<ProfileDto>> GetContactProfiles(string userId);
    Task<IEnumerable<ChannelDto>> GetChannelsAsync(string userId);
    Task<IEnumerable<ChatInfo>> GetChatInfosByUserAsync(string userId);
}