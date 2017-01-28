using FootlooseFS.Models;
using FootlooseFS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FootlooseFS.Web.Service.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IFootlooseFSService service;
        private readonly IOptions<FootlooseFSConfiguration> options;

        public LoginController(IFootlooseFSService service, IOptions<FootlooseFSConfiguration> options)
        {
            this.service = service;
            this.options = options;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromForm] string userName, string password)
        {
            var identity = await GetClaimsIdentity(userName, password);
            if (identity == null)
            {
                return BadRequest("Invalid credentials");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                          new DateTimeOffset().ToUnixTimeSeconds().ToString(),
                          ClaimValueTypes.Integer64),
                identity.FindFirst("UserName")
              };

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,               
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Serialize and return the response
            var response = new
            {
                access_token = encodedJwt,
                expires_in = 1000
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }        

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        /// <summary>
        /// IMAGINE BIG RED WARNING SIGNS HERE!
        /// You'd want to retrieve claims through your claims provider
        /// in whatever way suits you, the below is purely for demo purposes!
        /// </summary>
        private Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            var operationStatus = service.Login(userName, password);

            if (operationStatus.Success)
            {
                return Task.FromResult(new ClaimsIdentity(
                 new GenericIdentity(userName, "Token"),
                 new[]
                 {
                    new Claim("UserName", userName)
                 }));
            }                    

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}