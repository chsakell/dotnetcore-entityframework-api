using AutoMapper;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ScheduleViewModel, Schedule>()
               .ForMember(s => s.Creator, map => map.UseValue(null))
               .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}
