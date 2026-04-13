using System.ComponentModel.DataAnnotations;

namespace ECommerce.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    [Required, MinLength(32)]
    public string Secret { get; init; } = null!;

    [Required]
    public string Issuer { get; init; } = null!;

    [Required]
    public string Audience { get; init; } = null!;

    [Range(1, 1440)]
    public int ExpiryMinutes { get; init; }
}