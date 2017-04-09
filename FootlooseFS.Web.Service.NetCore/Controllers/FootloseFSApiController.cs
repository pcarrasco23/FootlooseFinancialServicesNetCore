using FootlooseFS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FootlooseFS.Web.Service.Controllers
{
    [Route("api/[controller]")]
    public class FootloseFSApiController : Controller
    {
        protected string authenticatedUser;
        protected readonly IFootlooseFSService service;

        public FootloseFSApiController(IFootlooseFSService service, IHttpContextAccessor httpContextAccessor)        
        {
            this.service = service;

            // Get username from claims
            HttpContextAccessor accessor = (HttpContextAccessor)httpContextAccessor;
            if (accessor.HttpContext.User.Claims.Any(c => c.Type == "UserName"))
            {
                var userNameClaim = accessor.HttpContext.User.Claims.First(c => c.Type == "UserName");
                if (userNameClaim != null)
                    authenticatedUser = userNameClaim.Value;
            }            
        }
    }
}