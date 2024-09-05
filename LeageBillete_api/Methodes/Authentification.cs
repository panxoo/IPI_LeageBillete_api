using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.Request;
using LeageBillete_api.Model.RequestResp;
using LeageBillete_api.Services;
using Microsoft.AspNetCore.Identity;

namespace LeageBillete_api.Methodes
{

    public class Authentification : IAuthentification
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public Authentification(UserManager<IdentityUser> userManager, ApplicationDbContext context, TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        public async Task DataIni()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("cliente"));
            }

            if (_userManager.FindByNameAsync("admin").Result ==  null)
            {
            var res =   await _userManager.CreateAsync(new IdentityUser { Email = "admin@leage.cl", UserName = "admin"}, "root123123");
                var user = await _userManager.FindByNameAsync("admin");
                var res2 = await _userManager.AddToRoleAsync(user, "admin");

            }
        }




        public async Task<bool> RegisterUser(RegistrationRequest request, int tipeUser)
        {

            IdentityUser usr = new IdentityUser
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.Phone
            };

            var res = await _userManager.CreateAsync(usr, request.Password);

            if (!res.Succeeded)
                throw new Exception(res.Errors.FirstOrDefault()?.Description);

            var resrol = await _userManager.AddToRoleAsync(usr, (tipeUser == 0 ? "admin" : "cliente"));

            if (!resrol.Succeeded)
                throw new Exception(resrol.Errors.FirstOrDefault()?.Description);

            return true;
        }


        public async Task<AuthentificationResp> login(AuthRequest inputs)
        {
            var managedUser = await _userManager.FindByNameAsync(inputs.UserName);

            if (managedUser == null || !await _userManager.CheckPasswordAsync(managedUser, inputs.Password))
                return new AuthentificationResp { state = "Unauthorized" };

            var role = await _userManager.GetRolesAsync(managedUser);
            string accessToken = _tokenService.CreateToken(managedUser, role.FirstOrDefault());

            return new AuthentificationResp
            {
                Username = managedUser.UserName,
                Email = managedUser.Email,
                Token = accessToken,
                state = "Authorized"
            };

        }
    }
}
