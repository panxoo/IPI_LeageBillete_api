using AutoMapper;
using LeageBillete_api.Data;
using LeageBillete_api.Interfaces;
using LeageBillete_api.Model.DataBase;
using LeageBillete_api.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LeageBillete_api.Methodes
{
    public class BilletAdmin : IBilletAdmin
    {

        private ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BilletAdmin(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Event_leage>> leagesActives()
        {
            return await _context.Event_leages.Where(w => w.Event_Days.Any(a => a.EventDate >= DateTime.Now && a.IsActif)).ToListAsync();
        }

        public async Task<bool> addEvent(Event_leage_DTO eventLeagedto)
        {
            Event_leage event_Leage = _mapper.Map<Event_leage>(eventLeagedto);

            if (_context.Event_leages.Any(a => a.Name.Equals(event_Leage.Name)))
            {
                throw new Exception("L'événtment déja exists");
            }

            _context.Add(event_Leage);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Event_leage_details>> eventDetailList()
        {
            return await _context.Event_leages
                .Where(w => w.Event_Days.Any(a => a.EventDate >= DateTime.Now && a.IsActif))
                .Select(s => new Event_leage_details
                {
                    Name = s.Name,
                    Location = s.Location,
                    event_Leage_Details_Jours = s.Event_Days.Where(ed => ed.EventDate > DateTime.Now && ed.IsActif)
                 .Select(s1 => new event_leage_details_jours
                 {
                     ticket_disponible = s1.Capacity_ticket - s1.Detail_Purchases.Sum(su => su.Quantite_ticket),
                     ticket_vendu = s1.Detail_Purchases.Sum(su => su.Quantite_ticket),
                     date_event = s1.EventDate
                 }).ToList()
                }).ToListAsync();
        }

        public async Task<bool> desactiveEvent(int enventId)
        {
            List<Event_day> eventDays =  await _context.Event_Days.Where(w => w.Event_Leage.Event_leageId == enventId && w.IsActif).ToListAsync();

            if(eventDays.Count == 0)
                throw new Exception("L'événtment ne trouve pas");

            eventDays.ForEach(f => { f.IsActif = false; });

            _context.Update(eventDays);
            return true;

        }
         

    }
}
