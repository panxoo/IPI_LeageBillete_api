using LeageBillete_api.Model.DataBase;
using LeageBillete_api.Model.DTO;

namespace LeageBillete_api.Interfaces
{
    public interface IBilletAdmin
    {
        Task<List<Event_leage>> leagesActives();
        Task<bool> addEvent(Event_leage_DTO eventLeage);
        Task<List<Event_leage_details>> eventDetailList();
        Task<bool> desactiveEvent(int eventId); 
    }
}
