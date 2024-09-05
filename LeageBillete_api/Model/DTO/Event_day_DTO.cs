using System.ComponentModel.DataAnnotations;

namespace LeageBillete_api.Model.DTO
{
    public class Event_day_DTO
    {
        [Required(ErrorMessage = "Event Date obligatoire")]
        public DateTime EventDate { get; set; }
        [Required(ErrorMessage = "Capacity obligatoire")]
        public int Capacity_ticket { get; set; }
        public string Area { get; set; }
    }
}
