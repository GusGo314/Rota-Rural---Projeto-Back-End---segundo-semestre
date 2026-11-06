using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using RotaRural.Data;
using RotaRural.Models;
using RotaRural.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using RotaRural.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException(
                           "Connection string 'DefaultConnection' não encontrada no appsettings.json.");

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews(options =>
{
    // Mensagens de erro de conversão em português
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        campo => $"O campo {campo} deve ser um número.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (valor, campo) => $"O valor \"{valor}\" não é válido para {campo}.");
});

builder.Services.AddScoped<FotoProdutoService>();

// Login local: cookie + hash de senha (sem ASP.NET Identity)
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "RotaRural.Auth";
        options.LoginPath = "/Conta/Login";
        options.LogoutPath = "/Conta/Sair";
        options.AccessDeniedPath = "/Conta/AcessoNegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });
builder.Services.AddScoped<SeedMunicipios>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seedMunicipios = scope.ServiceProvider.GetRequiredService<SeedMunicipios>();

    await seedMunicipios.RequisitarDados();



}



// Dados de teste: só em desenvolvimento
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    SemearDados.Inicializar(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var culturaBrasil = new CultureInfo("pt-BR");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culturaBrasil),
    SupportedCultures = new[] { culturaBrasil },
    SupportedUICultures = new[] { culturaBrasil }
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();