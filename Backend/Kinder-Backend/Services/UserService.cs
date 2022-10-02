using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public class UserService : IUserService
{
    private readonly IFireStoreProxy _fireStoreProxy;

    public UserService(IFireStoreProxy fireStoreProxy)
    {
        _fireStoreProxy = fireStoreProxy;
    }

    public async Task<AccountInfoDto> GetAccountInfo(LoginRequest request)
    {
        var accountInfo = await _fireStoreProxy.GetAccountInfo(request);
        return accountInfo;
    }
}