using AutoMapper;
using LeageBillete_api.Model.DTO;
using LeageBillete_api.Model.DataBase;


namespace LeageBillete_api.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<Event_leage_DTO, Event_leage>();
            CreateMap<Event_day_DTO, Event_day>();
            CreateMap<Price_ticket_DTO, Price_ticket>(); 

        }
    }
}
