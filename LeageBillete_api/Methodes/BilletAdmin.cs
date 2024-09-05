using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.DataBase;
using LeageBillete_api.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace LeageBillete_api.Methodes
{
    public class BilletAdmin: IBilletAdmin
    {

        private ApplicationDbContext _context;
        public BilletAdmin(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event_leage>> leagesActives()
        {
           return await _context.Event_leages.Where(w => w.Event_Days.MaxBy(m => m.EventDate).EventDate > DateTime.Now).ToListAsync();
        }

        public async Task<bool> addEvent(Event_leage_DTO eventLeage)
        {
            //Event_leage event_Leage = 
            return true;
        }
    }
}
