namespace LeageBillete_api.Model.DataBase
{
    public class Price_ticket
    {
        public int Price_ticketId { get; set; }
        public string Name { get; set; }
        public float Price_unit {  get; set; }
        public int Quantite_ticket_min { get; set; }
        public bool Is_all_event { get; set; }
        public bool Prix_eleve { get; set; }

        public Event_leage Event_Leage { get; set; }
        public List<Detail_purchase> Detail_Purchases { get; set; }
    }
}
