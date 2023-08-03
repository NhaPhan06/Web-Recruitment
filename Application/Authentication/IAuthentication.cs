using WebRecruitment.Domain.Entity;

namespace WebRecruitment.Application.Authentication;

public interface IAuthentication
{
    public bool Verify(string HashPassword, string InputPassword);
    public string Hash(string password);
    public string GenerateToken(Account user, string secretKey, string role);
    
}