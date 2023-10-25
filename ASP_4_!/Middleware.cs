using ASP_4__;
using ASP_4__.Objects;
namespace ASP_4__
{
    public class Middleware
    {
        RequestDelegate next;
        Zoo zoo;

        public Middleware(RequestDelegate next, Zoo zoo)
        {
            this.next = next;
            this.zoo = zoo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Виклик зоопарку: {zoo?.Id}");
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
