using AutoMapper;
using Scheduler.Model;
using System.Collections.Generic;

namespace Scheduler.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ScheduleViewModel, Schedule>()
                .ForMember(s => s.Creator, map => map.MapFrom(src => default(User)))
                .ForMember(s => s.Attendees, map => map.MapFrom(src => new List<Attendee>()));

            CreateMap<UserViewModel, User>();
        }
    }
}
