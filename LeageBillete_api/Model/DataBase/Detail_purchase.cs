namespace LeageBillete_api.Model.DataBase
{
    public class Detail_purchase
    {
        public int Detail_purchaseId { get; set; }
        public int Quantite_ticket {  get; set; }
        public string Code_detail { get; set; }
        public float Total_price { get; set; }
        public Price_ticket Price_Ticket { get; set; }
        public Event_leage Event_Leage { get; set; }
        public Ticket_purchase ticket_Purchase { get; set; }
        public Event_day Event_Day { get; set; }
    }
}
