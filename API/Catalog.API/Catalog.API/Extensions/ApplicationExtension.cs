using Catalog.API.Middlewares;
using Catalog.Business;

namespace Catalog.API.Extensions
{
    public static class ApplicationExtension
    {

        public static void UseCheckIE(this IApplicationBuilder app)
        {
            app.UseMiddleware<CheckBrowserIsIEMiddleware>();
            app.UseMiddleware<ResponseEditingMiddleware>();
            app.UseMiddleware<RedirectMiddleware>();
        }
        public static IApplicationBuilder UseProductIsExistTestPage(this IApplicationBuilder app)
        {
            app.Map("/test", middleBuilder =>
            {
                middleBuilder.Run(async (ctx) =>
                {
                    if (ctx.Request.Query.ContainsKey("id"))
                    {
                        int id = int.Parse(ctx.Request.Query["id"]);
                        await ctx.Response.WriteAsync($"{id} degeri, middleware'a geldi <br>");
                        using var scope = middleBuilder.ApplicationServices.CreateScope();
                        var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                        if (await productService.IsProductExists(id))
                        {
                            await ctx.Response.WriteAsync($"{id} degeri, db'de var");
                        }
                        else
                        {
                            await ctx.Response.WriteAsync($"{id} degeri, db'de yok");

                        }

                    }
                    else
                    {
                        await ctx.Response.WriteAsync($"id degeri, middleware'a gelmedi!");

                    }
                });
            });
            return app;
        }
    }
}
