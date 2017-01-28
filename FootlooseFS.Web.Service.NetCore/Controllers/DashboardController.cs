using FootlooseFS.Models;
using FootlooseFS.Service;
using FootlooseFS.Web.Service.Models;
using Microsoft.AspNetCore.Http;

namespace FootlooseFS.Web.Service.Controllers
{
    public class DashboardController : FootloseFSApiController
    {
        public DashboardController(IFootlooseFSService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor) { }

        // GET api/accounts
        public DashboardViewModel Get()
        {
            var dashboardViewModel = new DashboardViewModel();

            var person = service.GetPersonByUsername(authenticatedUser, new PersonIncludes());

            dashboardViewModel.FirstName = person.FirstName;
            dashboardViewModel.LastName = person.LastName;

            return dashboardViewModel;
        }
    }
}
