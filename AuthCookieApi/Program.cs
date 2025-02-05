using AuthCookieApi.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// Adicionar autenticação por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.LoginPath = "/api/auth/login";
        options.LogoutPath = "/api/auth/logout";
    });


builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Habilitar o middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();