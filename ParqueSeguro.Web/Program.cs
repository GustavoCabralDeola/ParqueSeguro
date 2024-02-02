using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Application.Services;
using ParqueSeguro.Core.Interfaces.Respositories;
using ParqueSeguro.Core.Interfaces.Services;
using ParqueSeguro.Infra.Persistence;
using ParqueSeguro.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Context"),
        ServerVersion.Parse("8.0.33-mysql"),
        b => b.MigrationsAssembly("ParqueSeguro.Infra")));


builder.Services.AddScoped<Context>();

builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
builder.Services.AddScoped<ITabelaPrecoRepository, TabelaPrecoRepository>();


builder.Services.AddScoped<IRegistroService>(provider =>
{
    var registroRepository = provider.GetRequiredService<IRegistroRepository>();
    var tabelaPrecoRepository = provider.GetRequiredService<ITabelaPrecoRepository>();
    return new RegistroService(registroRepository, tabelaPrecoRepository);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
