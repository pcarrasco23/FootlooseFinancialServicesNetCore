using FootlooseFS.Service;
using FootlooseFS.Web.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootlooseFS.Web.Service.Controllers
{
    public class ChangePasswordController : FootloseFSApiController
    {
        public ChangePasswordController(IFootlooseFSService service, IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor) { }

        // PUT: api/changepassword
        public void Post([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            var oppStatus = service.UpdatePassword(authenticatedUser, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);

            // Return success or error state
            if (!oppStatus.Success)
            {
                throw new Exception(oppStatus.Messages[0]);
            }
        }
    }
}
