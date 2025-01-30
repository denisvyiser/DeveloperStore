using DevStore.Core.Authentication.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Core.Authentication.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var cert = configuration["CERTIFICATEKEY"];
            var signingConfig = new SigningConfig(cert);

            services.AddSingleton(signingConfig);

            var tokenConfig = configuration.GetSection("TokenConfig").Get<TokenConfig>();

            services.AddSingleton(tokenConfig);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;

                bearerOptions.SaveToken = true;
                paramsValidation.IssuerSigningKey = signingConfig.Key;
                paramsValidation.ValidIssuer = tokenConfig.Issuer;

                //Do not validate audience
                paramsValidation.ValidateAudience = false;
                //paramsValidation.ValidAudience = tokenConfig.Audience;

                // validates the token signature
                paramsValidation.ValidateIssuerSigningKey = true;

                // check token validity
                paramsValidation.ValidateLifetime = true;

                // Token expiration tolerance time.     
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            return services;
        }
    }
}
