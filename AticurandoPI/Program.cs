using Microsoft.EntityFrameworkCore;
using AticurandoPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapGet("/exportsql", async (AppDbContext context) =>
{
    var sql = context.Database.GenerateCreateScript();

    await File.WriteAllTextAsync("banco.sql", sql);

    return Results.Ok("Arquivo banco.sql gerado na raiz do projeto!");
});


app.Run();
