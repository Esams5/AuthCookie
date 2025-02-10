using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AuthCookieApi.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AuthCookieApi.Middleware
{
    public class SessionValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var sessionId = context.User.FindFirst("SessionId")?.Value;
                var username = context.User.Identity.Name;

                if (!string.IsNullOrEmpty(sessionId))
                {
                    // Verificar se o identificador da sessão é válido
                    var user = dbContext.Users.FirstOrDefault(u => u.Username == username && u.SessionId == sessionId);

                    if (user == null)
                    {
                        // Invalidar o cookie de autenticação
                        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return;
                    }
                }
                else
                {
                    // Se o SessionId for NULL, invalide o cookie
                    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
            }

            await _next(context);
        }
    }
}