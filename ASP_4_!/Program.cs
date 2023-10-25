using Microsoft.EntityFrameworkCore;
using System;
using ASP_4__;
using ASP_4__.Objects;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var services = builder.Services;

builder.Services.AddTransient<Zoo>();

builder.Services.AddDirectoryBrowser();

var app = builder.Build();

app.UseMiddleware<AddZooMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseDefaultFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
    });
});

//app.MapGet("/", (ApplicationContext db) => db.Zoo.ToList());



app.Run();