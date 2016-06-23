using AutoMapper;
using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Schedule, ScheduleViewModel>()
               .ForMember(vm => vm.Creator,
                    map => map.MapFrom(s => s.Creator.Name))
               .ForMember(vm => vm.Attendees, map =>
                    map.MapFrom(s => s.Attendees.Select(a => a.UserId)));

            Mapper.CreateMap<Schedule, ScheduleDetailsViewModel>()
               .ForMember(vm => vm.Creator,
                    map => map.MapFrom(s => s.Creator.Name))
               .ForMember(vm => vm.Attendees, map =>
                    map.UseValue(new List<UserViewModel>()))
                .ForMember(vm => vm.Status, map =>
                    map.MapFrom(s => ((ScheduleStatus)s.Status).ToString()))
                .ForMember(vm => vm.Type, map =>
                   map.MapFrom(s => ((ScheduleType)s.Type).ToString()))
               .ForMember(vm => vm.Statuses, map =>
                    map.UseValue(Enum.GetNames(typeof(ScheduleStatus)).ToArray()))
               .ForMember(vm => vm.Types, map =>
                    map.UseValue(Enum.GetNames(typeof(ScheduleType)).ToArray()));

            Mapper.CreateMap<User, UserViewModel>()
                .ForMember(vm => vm.SchedulesCreated,
                    map => map.MapFrom(u => u.SchedulesCreated.Count()));
        }
    }
}
