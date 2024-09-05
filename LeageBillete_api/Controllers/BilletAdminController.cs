using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeageBillete_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilletAdminController : ControllerBase
    {

        private readonly IBilletAdmin _billetAdmin;

        public BilletAdminController(IBilletAdmin billetAdmin)
        {

            _billetAdmin = billetAdmin;
        }

        [HttpGet]
        [Route("leagesActives")]
        [Authorize]
        public async Task<IActionResult> leagesActives()
        {
            try
            {
                return Ok(await _billetAdmin.leagesActives());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addEvent")]
        [Authorize]
        public async Task<IActionResult> addEvent(Event_leage_DTO eventLeage)
        {
            try
            {
                return Ok(await _billetAdmin.addEvent(eventLeage));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("eventdetaillist")]
        [Authorize]
        public async Task<IActionResult> eventDetailList()
        {
            try
            {
                return Ok(await _billetAdmin.eventDetailList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
