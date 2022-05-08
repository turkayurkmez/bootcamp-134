using Catalog.Business;
using Catalog.Business.Mapping;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories;
using Catalog.API.Extensions;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Middlewares;
using Catalog.API.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(opt => opt.AddPolicy("allow", cpb =>
   {
       cpb.AllowAnyOrigin();
       cpb.AllowAnyHeader();
       cpb.AllowAnyMethod();
   }));

builder.Services.AddMemoryCache();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("token:secret").Value));

//builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic", null);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateActor = true,
                        ValidIssuer = "http://www.kodluyoruz.com",
                        ValidAudience = "http://client.kodluyoruz.com",
                        IssuerSigningKey = key

                    };
                });

var app = builder.Build();

////app.UseWelcomePage();
//app.Run(async (context) => {
//    await context.Response.WriteAsync("Talep, middleware tarafindan yakalandi");

//}); 

//app.Map("/test", middleBuilder =>
//{
//    middleBuilder.Run(async (ctx) =>
//    {
//        if (ctx.Request.Query.ContainsKey("id"))
//        {
//            int id = int.Parse(ctx.Request.Query["id"]);
//            await ctx.Response.WriteAsync($"{id} degeri, middleware'a geldi <br>");
//            using var scope = middleBuilder.ApplicationServices.CreateScope();
//            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
//            if (await productService.IsProductExists(id))
//            {
//                await ctx.Response.WriteAsync($"{id} degeri, db'de var");
//            }
//            else
//            {
//                await ctx.Response.WriteAsync($"{id} degeri, db'de yok");

//            }

//        }
//        else
//        {
//            await ctx.Response.WriteAsync($"id degeri, middleware'a gelmedi!");

//        }
//    });
//});

// Configure the HTTP request pipeline.
//Yukarıdaki kod yerine, bu extension metot çağrılıyor:
app.UseProductIsExistTestPage();

app.Use((ctx, next) =>
{
    Console.WriteLine($"{ctx.Request.Path} adresinden,  {ctx.Request.Method} talebi geldi");
    return next();
});




//app.UseMiddleware<CheckBrowserIsIEMiddleware>();
//app.UseMiddleware<ResponseEditingMiddleware>();
//app.UseMiddleware<RedirectMiddleware>();

app.UseCheckIE();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("allow");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
