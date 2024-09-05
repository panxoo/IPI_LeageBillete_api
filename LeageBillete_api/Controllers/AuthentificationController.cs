using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeageBillete_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {

        private readonly IAuthentification _authentification;

        public AuthentificationController(IAuthentification authentification)
        {
            _authentification = authentification;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(AuthRequest inputs)
        {
            try
            {
                var res = await _authentification.login(inputs);

                if (res.state == "Unauthorized")
                    return Unauthorized();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("registerClient")]
        public async Task<IActionResult> RegisterClient(RegistrationRequest request)
        {
            try
            {
                var res = await _authentification.RegisterUser(request, 1);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        [Route("registerAdmin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin(RegistrationRequest request)
        {
            try
            {
                var res = await _authentification.RegisterUser(request, 0);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
