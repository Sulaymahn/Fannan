using Microsoft.AspNetCore.Mvc;

namespace Fannan.API.Controllers
{
    [Route("/api")]
    [ApiController]
    public class AuthenticationController
    {
        [HttpGet("auth")]
        public string Authenticate()
        {
            return "Authenticated";        }
    }
}
