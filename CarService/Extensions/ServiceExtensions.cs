using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CarService.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddKeyCloakCookieIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
                {
                    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)

                // 
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, opt =>
                {
                    opt.Authority = configuration["Oidc:Authority"];
                    opt.ClientId = configuration["Oidc:ClientId"];
                    //opt.ClientSecret = configuration["Oidc:ClientSecret"];
                    opt.SaveTokens = true;
                    opt.ResponseType = OpenIdConnectResponseType.Code; //Configuration["Oidc:ResponseType"];
                    opt.RequireHttpsMetadata = false; // dev only
                    opt.GetClaimsFromUserInfoEndpoint = true;
                    opt.Scope.Add("openid");
                    opt.Scope.Add("profile");
                    opt.Scope.Add("email");
                    opt.Scope.Add("claims");

                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "groups",
                        ValidateIssuer = true
                    };
                });

            services.AddAuthorization();
        }

        public static void AddKeyCloakJwtIdentityService(this IServiceCollection services, IConfiguration configuration,
            IWebHostEnvironment env)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Add validate with OpenIdConnect; In studying
            .AddOpenIdConnect(opt =>
            {
                opt.Authority = configuration.GetSection("Oidc:Authority").Value;
                opt.ClientId = configuration.GetSection("Oidc:ClientId").Value;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                };
            })
            // Add validate with JWT Token
            .AddJwtBearer(opt =>
            {
                opt.Authority = configuration.GetSection("Oidc:Authority").Value;
                opt.Audience = configuration.GetSection("Oidc:ClientId").Value;
                // Https metadata = false need for dev only
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    // May need to validate in production
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });

            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        }
    }
}
