using Catalog.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Catalog.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly IUserService userService;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, 
                                          ILoggerFactory logger, 
                                          UrlEncoder encoder,
                                          ISystemClock systemClock,
                                          IUserService userService
                                          ):base(options,logger,encoder,systemClock)
        {
            this.userService = userService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Request içinde Authorization header var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. Authorization header, doğru formatta mi?

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //3. Authorization header, Basic mi?
            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var bytes = Convert.FromBase64String(headerValue.Parameter);
            var credentials = Encoding.UTF8.GetString(bytes).Split(':');
            string username = credentials[0];
            string password = credentials[1];

            var user = userService.Validate(username, password);
            if (user != null)
            {
                //TODO 1: Geriye, claim ve token bilgisini döndür
                Claim[] claims = new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("GozRengi", user.FirstName)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);

                AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                
                return Task.FromResult(AuthenticateResult.Success(ticket));

            }

            return Task.FromResult(AuthenticateResult.Fail("Kullanıcı adı veya şifre hatalı"));

        }
    }
}
