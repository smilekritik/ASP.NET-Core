using System;
using Newtonsoft.Json;
using ASP_4__.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ASP_4__;

public class AddZooMiddleware
{
    private readonly RequestDelegate _next;

    public AddZooMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ApplicationContext db)
    {
        context.Response.Redirect("/index.html");
        await _next(context);

        if (context.Request.Method == "GET")
        {
            if (context.Request.Path == "/Zoo" && context.Request.Query.ContainsKey("zoo_number"))
            {
                if (int.TryParse(context.Request.Query["zoo_number"], out int zoo_number))
                {
                    Zoo? found_zoo = await db.Zoo.FirstOrDefaultAsync(u => u.Id == zoo_number);
                    if (found_zoo != null)
                    {
                        context.Response.StatusCode = 200;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(found_zoo));
                        return;
                    }
                }
            }
        }
        if (context.Request.Path == "/addZoo" && context.Request.Method == "POST")
        {
            string name = context.Request.Form["Name"];
            int workers_Ammount = Convert.ToInt32(context.Request.Form["Workers_Ammount"]);
            int aviary_Ammount = Convert.ToInt32(context.Request.Form["Aviary_Ammount"]);

            Zoo new_zoo = new Zoo
            {
                Name = name,
                Workers_Ammount = workers_Ammount,
                Aviary_Ammount = aviary_Ammount
            };

            db.Zoo.Add(new_zoo);
            db.SaveChanges();

            context.Response.Redirect("/success");
        }
        else
        {
            await _next(context);
        }
    }
}