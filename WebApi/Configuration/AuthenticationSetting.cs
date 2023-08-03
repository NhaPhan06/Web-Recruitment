using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebRecruitment.Domain.Enums.Role;

namespace WebRecruitment.WebApi.Configuration;

public static class SecuritySetting
{
    public static IServiceCollection SecurityConfiguration(this IServiceCollection services, string secretKey)
    {
        var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                //auto generate token
                ValidateIssuer = false,
                ValidateAudience = false,

                //sign in token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy =>
            {
                policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("Role", ROLEACCOUNT.ADMIN.ToString());
            });
        });


        return services;
    }
}