using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using project.users.dto;
using project.utils;
using project.utils.dto;
using project.utils.services;

namespace project.users
{
    [ApiController]
    [Route("api/users")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMINISTRATOR")]

    public class userController : ControllerBase
    {
        //Esto nos va servir para crear nuevos usuarios 
        private readonly UserManager<userEntity> userManager;
        private readonly IConfiguration configuration;
        // Esto nos va a servir para el login
        private readonly SignInManager<userEntity> signManager;
        private readonly emailService emailService;
        private readonly IDataProtector dataProtector;
        private readonly IMapper mapper;

        public userController(UserManager<userEntity> userManager, IConfiguration configuration, SignInManager<userEntity> signManager, emailService emailService, IDataProtectionProvider dataProtectionProvider, IMapper mapper)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signManager = signManager;
            this.emailService = emailService;
            this.dataProtector = dataProtectionProvider.CreateProtector("emailConfirmation");
            this.mapper = mapper;
        }



        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<userDto>> register(userCreationDto credentials)
        {
            if (await userManager.FindByEmailAsync(credentials.email) != null)
                return BadRequest(new errorMessageDto("El correo ya esta en uso"));
            if (await userManager.FindByNameAsync(credentials.userName) != null)
                return BadRequest(new errorMessageDto("El Nombre de usuario ya esta en uso"));
            userEntity user = new userEntity() { UserName = credentials.userName, Email = credentials.email, address = credentials.address };

            IdentityResult result = await userManager.CreateAsync(user, credentials.password);
            if (result.Succeeded)
            {
                credentialsDto credentialsPassword = new credentialsDto() { email = user.Email, password = credentials.password };
                authenticationDto token = await createToken(credentialsPassword);
                userDto resUserDto = mapper.Map<userDto>(user);
                resUserDto.token = token.token;
                return resUserDto;
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<userDto>> login(credentialsDto credentials)
        {

            userEntity EMAIL = await userManager.FindByEmailAsync(credentials.email);
            if (EMAIL == null)
                return BadRequest(new errorMessageDto("Credenciales invalidas"));

            if (EMAIL.deleteAt != null)
                return BadRequest(new errorMessageDto("Credenciales invalidas"));

            var result = await signManager.PasswordSignInAsync(EMAIL.UserName, credentials.password, false, false);
            if (result.Succeeded)
            {
                credentialsDto credentialsPassword = new credentialsDto() { email = EMAIL.Email, password = credentials.password };
                authenticationDto token = await createToken(credentialsPassword);
                userDto resUserDto = mapper.Map<userDto>(EMAIL);
                resUserDto.token = token.token;
                return resUserDto;
            }
            else
                return BadRequest(new errorMessageDto("Credenciales invalidas"));
        }
        private async Task<authenticationDto> createToken(credentialsDto credentials)
        {
            userEntity user = await userManager.FindByEmailAsync(credentials.email);
            IList<Claim> claimUser = await userManager.GetClaimsAsync(user);
            IList<string> roles = await userManager.GetRolesAsync(user);
            foreach (string rol in roles)
            {
                claimUser.Add(new Claim(ClaimTypes.Role, rol));
            }
            claimUser.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claimUser.Add(new Claim(ClaimTypes.Name, user.UserName)); // Agrega el nombre de usuario como un claim


            // Estos son los parametros que guardara el webToken
            List<Claim> claims = new List<Claim>(){
                new Claim("email", credentials.email),
            };
            claims.AddRange(claimUser);

            // Creamos nuestra sensual llave
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyJwt"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Creamos la fecha de expiracion
            DateTime expiration = DateTime.UtcNow.AddDays(1);

            // Creamos nuestro token
            JwtSecurityToken securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);
            return new authenticationDto()
            {
                token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                expiration = expiration
            };
        }
    }
}