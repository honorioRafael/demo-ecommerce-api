namespace ECommerce.Application.Interfaces.Jwt;

public interface IJwtProvider
{
    string Generate(Guid userId, string email, string name);
}