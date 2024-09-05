using AutoMapper;
using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
namespace LeageBillete_api.Methodes
{
    public class ReserveTicket: IReserveTicket
    {
        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReserveTicket(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


    }
}
