using System.Net;

namespace E_Commerce_API.Middlewares
{
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private const string APIKEY = "x-ApiKey";
        public APIKeyMiddleware(RequestDelegate next, IConfiguration configuration) { 
            this.next = next;
            this.configuration = configuration;
        }
        public async Task Invoke(HttpContext context) {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extracted_apikey)) {
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("API Key not provided");
                return;
            }

            string? api_key = configuration.GetValue<string>("API_Key");
            
            Console.WriteLine(api_key);
            Console.WriteLine(extracted_apikey);

            if (!extracted_apikey.Equals(api_key)) {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }
            await next(context);
        }
    }
}
