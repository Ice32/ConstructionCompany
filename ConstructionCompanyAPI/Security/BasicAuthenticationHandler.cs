using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ConstructionCompany.BR.Users;
using ConstructionCompany.Specifications;
using ConstructionCompanyDataLayer;
using ConstructionCompanyDataLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Task = System.Threading.Tasks.Task;

namespace ConstructionCompanyAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUsersService _userService;
        private readonly IRepository<ConstructionSiteManager> _constructionSiteManagersRepository;
        private readonly IRepository<Manager> _managersRepository;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUsersService userService,
            IRepository<ConstructionSiteManager> constructionSiteManagersRepository,
            IRepository<Manager> managersRepository)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
            _constructionSiteManagersRepository = constructionSiteManagersRepository;
            _managersRepository = managersRepository;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            User user;
            try
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                string username = credentials[0];
                string password = credentials[1];
                user = _userService.GetUserFromCredentials(username, password);
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }

            if (user == null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.FullName),
            };

            bool userIsManager = _managersRepository.GetSingle(new ManagerSpecification(user)) != null;
            bool userIsConstructionSiteManager = _constructionSiteManagersRepository.GetSingle(new ConstructionSiteManagerSpecification(user)) != null;
            
            if (userIsManager)
            {
                claims.Add(new Claim(ClaimTypes.Role, Role.RoleEnum.Manager.ToString()));
            } else if (userIsConstructionSiteManager)
            {
                claims.Add(new Claim(ClaimTypes.Role, Role.RoleEnum.ConstructionSiteManager.ToString()));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, Role.RoleEnum.Worker.ToString()));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}