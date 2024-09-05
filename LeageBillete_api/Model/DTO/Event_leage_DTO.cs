using LeageBillete_api.Model.DataBase;
using System.ComponentModel.DataAnnotations;

namespace LeageBillete_api.Model.DTO
{
    public class Event_leage_DTO
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location obligatoire")]
        public string Location { get; set; }
        public string Description { get; set; }
        public List<Event_day_DTO> Event_Days { get; set; }
        public List<Price_ticket_DTO> Price_tickets { get; set; }
    }
}
