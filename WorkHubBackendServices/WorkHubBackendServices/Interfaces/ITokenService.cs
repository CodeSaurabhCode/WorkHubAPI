using WorkHubBackEndServices.Models.Identity;

namespace WorkHubBackEndServices.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
