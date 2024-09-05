using LeageBillete_api.Model.DataBase;

namespace LeageBillete_api.Model.DTO
{
    public class Event_leage_details:Event_leage
    {
      public List<event_leage_details_jours> event_Leage_Details_Jours { get; set; }
    }

    public class event_leage_details_jours
    {
        public int ticket_vendu { get; set; }
        public int ticket_disponible { get; set; }
        public DateTime date_event { get; set; }
    }
}
