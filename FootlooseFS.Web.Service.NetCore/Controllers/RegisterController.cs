using FootlooseFS.Service;
using FootlooseFS.Web.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootlooseFS.Web.Service.Controllers
{
    public class RegisterController : FootloseFSApiController
    {
        public RegisterController(IFootlooseFSService service, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(service, httpContextAccessor) { }

        // POST: api/register
        [AllowAnonymous]
        public void Post([FromBody] RegisterViewModel registerViewModel)
        {
            var enrollmentRequest = new EnrollmentRequest
            {
                LastName = registerViewModel.LastName,
                AccountNumber = registerViewModel.AccountNumber,
                Username = registerViewModel.Username,
                Password = registerViewModel.Password                
            };

            var oppStatus = service.Enroll(enrollmentRequest);

            // Return success or error state
            if (!oppStatus.Success)
            {
                throw new Exception(oppStatus.Messages[0]);
            }
        }
    }
}
