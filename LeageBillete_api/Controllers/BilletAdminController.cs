using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeageBillete_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilletAdminController : ControllerBase
    {

        private readonly IBilletAdmin _billetAdmin;
         
        public BilletAdminController( IBilletAdmin billetAdmin) { 
        
            _billetAdmin = billetAdmin;
        }

        [HttpGet]
        [Route("leagesActives")]
        public async Task<IActionResult> leagesActives() {             
            return Ok(_billetAdmin.leagesActives());
        }

        [HttpGet]
        [Route("addEvent")]
        public async Task<IActionResult> addEvent(Event_leage_DTO eventLeage)
        {
            return Ok();
        }
    }
}
