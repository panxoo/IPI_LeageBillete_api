using System.ComponentModel.DataAnnotations;

namespace LeageBillete_api.Model.DTO
{
    public class Price_ticket_DTO
    {
        [Required(ErrorMessage ="Nom obligatoire")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price obligatoire")]
        public float Price_unit { get; set; }
        [Required(ErrorMessage = "Quantite ticket min obligatoire")]
        public int Quantite_ticket_min { get; set; }
        public bool Prix_eleve { get; set; } = false;

        public bool Is_all_event { get; set; } = false;
    }
}
