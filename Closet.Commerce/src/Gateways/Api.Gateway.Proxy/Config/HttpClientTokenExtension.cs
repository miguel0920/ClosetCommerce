using Microsoft.AspNetCore.Http;

namespace Api.Gateway.Proxies.Config
{
    public static class HttpClientTokenExtension
    {
        public static void AddBearerToken(this HttpClient client, IHttpContextAccessor httpContext)
        {
            if (httpContext.HttpContext.User.Identity.IsAuthenticated && httpContext.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                string token = httpContext.HttpContext.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
            }
        }
    }
}