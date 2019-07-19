using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionCompanyAPI.Controllers.Generics
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase: ControllerBase

    {
        protected int GetCurrentUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Claim nameClaim = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(nameClaim?.Value);
        }

    }
}
