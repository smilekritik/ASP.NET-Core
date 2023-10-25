using Microsoft.EntityFrameworkCore;
using System;
using ASP_4__;
using ASP_4__.Objects;
var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var services = builder.Services;

builder.Services.AddTransient<Zoo>();

var app = builder.Build();

app.UseMiddleware<Middleware>();

app.MapGet("/", (ApplicationContext db) => db.Zoo.ToList());


app.MapPost("/addZoo", (string Name, int Workers_Ammount, int Aviary_Ammount, ApplicationContext db) =>
{
    Zoo new_zoo = new Zoo();
    new_zoo.Name = Name;
    new_zoo.Workers_Ammount = Workers_Ammount;
    new_zoo.Aviary_Ammount = Aviary_Ammount;
    db.Zoo.Add(new_zoo);
    db.SaveChanges();
    return new_zoo;
});

app.MapGet("/Zoo/{zoo_number:int}", async (int zoo_number, ApplicationContext db) =>
{
    Zoo? found_zoo = await db.Zoo.FirstOrDefaultAsync(u => u.Id == zoo_number);
    if (found_zoo == null)
    {
        return Results.NotFound(new { message = "Зоопарк не знайдено" });
    }
    return Results.Json(found_zoo);
});


app.Run();