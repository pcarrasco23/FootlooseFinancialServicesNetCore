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

        // POST: api/changepassword
        public OperationStatus Post([FromBody] ChangePasswordViewModel changePasswordViewModel)
        {
            var oppStatus = service.UpdatePassword(authenticatedUser, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);

            return oppStatus;
        }
    }
}
