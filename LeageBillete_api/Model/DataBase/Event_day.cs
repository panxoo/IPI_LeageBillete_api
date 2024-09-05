namespace LeageBillete_api.Model.DataBase
{
    public class Event_day
    {
        public int Event_DayId { get; set; }
        public DateTime EventDate { get; set; }
        public int Capacity_ticket { get; set; }
        public string Area { get; set; }
        public bool IsActif { get; set; } = true;
        public bool Prix_eleve { get; set; } = false;
        public Event_leage Event_Leage { get; set; }
        public List<Detail_purchase> Detail_Purchases { get; set; }
    }
}
