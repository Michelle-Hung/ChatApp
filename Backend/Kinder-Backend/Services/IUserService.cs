using System.Threading.Tasks;
using Kinder_Backend.Controllers;

namespace Kinder_Backend.Services;

public interface IUserService
{
    Task<AccountInfoDto> GetAccountInfo(LoginRequest request);
}