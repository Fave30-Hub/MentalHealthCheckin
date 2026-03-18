using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class LicenseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public LicenseMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        var token = context.Request.Headers["X-License-Token"].ToString();

        var validToken = _config["LICENSE_TOKEN"];
        var expiryRaw = _config["LICENSE_EXPIRY"];

        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Missing license token");
            return;
        }

        if (token != validToken)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid license token");
            return;
        }

        if (!DateTime.TryParse(expiryRaw, out var expiryDate))
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Invalid expiry configuration");
            return;
        }

        if (DateTime.UtcNow > expiryDate)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("License expired");
            return;
        }

        await _next(context);
    }
}