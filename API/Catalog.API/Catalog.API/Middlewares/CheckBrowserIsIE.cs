namespace Catalog.API.Middlewares
{
    public class CheckBrowserIsIEMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckBrowserIsIEMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var isIE = context.Request.Headers["User-Agent"].Any(value=>value.Contains("Trident"));
            context.Items["IE"] = isIE;
            context.Items["message"] = "Bu api istemcisi; IE olamaz";
            //items; bir request'e eklenecek özel bilgilerdir.
            await _next.Invoke(context);
        }
    }
}
