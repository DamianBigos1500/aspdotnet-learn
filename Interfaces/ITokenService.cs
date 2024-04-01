using dotnet_first.Models;

namespace dotnet_first.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}