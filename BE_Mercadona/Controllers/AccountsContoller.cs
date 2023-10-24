using BE_Mercadona.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_Mercadona.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsContoller:ControllerBase
    {
        #region Fields
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        #endregion
        #region Constructor
        public AccountsContoller(UserManager<IdentityUser> userManager,SignInManager<IdentityUser>signInManager,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        #endregion
        #region Public Methods

        [HttpPost("create")]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody]UserCredentials userCredentials)
        {
            var user=new IdentityUser { UserName=userCredentials.Email, Email=userCredentials.Email };
            var result=await userManager.CreateAsync(user,userCredentials.Password);

            if (result.Succeeded)
            {
                return BuildToken(userCredentials);
            }
            else return BadRequest(result.Errors);
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody]UserCredentials userCredentials)
        {
            var result=await signInManager.PasswordSignInAsync(userCredentials.Email,userCredentials.Password,isPersistent:false,lockoutOnFailure:false);
            if (result.Succeeded)
            {
                return BuildToken(userCredentials);
            }
            else return BadRequest("Incorrect Login");
        }
        private AuthenticationResponse BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email",userCredentials.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expiration=DateTime.UtcNow.AddYears(1);
            var token=new JwtSecurityToken(issuer:null,audience:null,claims:claims,expires:expiration,signingCredentials:cred);

            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        #endregion
    }
}
