using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _apiKey = configuration["ApiKey"];
    }

    public async Task Invoke(HttpContext context)
    {
        // Log the incoming API key
        Console.WriteLine($"Received API Key: {context.Request.Headers["x-api-key"]}");

        if (!context.Request.Headers.ContainsKey("x-api-key") || context.Request.Headers["x-api-key"] != _apiKey)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid or missing API Key");
            return;
        }

        await _next(context);
    }
}
