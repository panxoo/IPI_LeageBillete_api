using LeageBillete_api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeageBillete_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveTicketController : ControllerBase
    {
        private readonly IReserveTicket _reserveTicket;

        public ReserveTicketController(IReserveTicket reserveTicket)
        {

            _reserveTicket = reserveTicket;
        }

        
    }
}
