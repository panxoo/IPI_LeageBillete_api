namespace LeageBillete_api.Model.DataBase
{
    public class Event_leage
    {
        public int Event_leageId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Event_day> Event_Days { get; set; }
        public List<Price_ticket> Price_tickets { get; set; }
        public List<Detail_purchase> Detail_Purchases { get; set; }
    }
}
