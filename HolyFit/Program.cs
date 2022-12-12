using HolyFit.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection(key: "AzureAdB2C"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(name: "Admin", policy =>
    {
        policy.RequireClaim(claimType: "jobTitle", allowedValues: "Admin");
    });
});

builder.Services.AddSingleton<WeatherForecastService>();
//Add all here when add 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRewriter(
    new RewriteOptions().Add(
        context =>
        {
            if (context.HttpContext.Request.Path == "/MicrosoftIdentity/Account/SignedOut")
            {
                context.HttpContext.Response.Redirect(location: "/");
            }
        }));
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

