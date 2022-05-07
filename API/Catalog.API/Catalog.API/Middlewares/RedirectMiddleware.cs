namespace Catalog.API.Middlewares
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
               await context.Response.WriteAsync(context.Items["message"].ToString());
            }
            await _next.Invoke(context);
        }
    }
}
