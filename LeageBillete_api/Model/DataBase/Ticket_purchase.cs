namespace LeageBillete_api.Model.DataBase
{
    public class Ticket_purchase
    {
        public int Ticket_purchaseId { get; set; }
        public float Total_price { get; set; }
        public string Firstname_facture { get; set; }
        public string Lastname_facture { get;set; }
        public string Address_facture { get; set; }
        public string Email {  get; set; }
        public DateTime Date_purchase { get; set; }
        public string Code_reserva { get; set; }
        public List<Detail_purchase>  Detail_Purchases { get; set; }

    }
}
