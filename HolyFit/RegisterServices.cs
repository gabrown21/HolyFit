using HolyFit.Data;
using HolyFit;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace HolyFit
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
            builder.Services.AddMemoryCache();
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
            builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(name: "Admin", policy =>
                {
                    policy.RequireClaim(claimType: "jobTitle", allowedValues: "Admin");
                });
            });

            builder.Services.AddSingleton<WeatherForecastService>();
            //Add all here when add instead of RegisterServices.cs
            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddSingleton<IMongoUserData, MongoUserData>();


        }
    }
}

