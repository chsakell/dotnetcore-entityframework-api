using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.API.ViewModels
{
    public class ScheduleDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Creator { get; set; }
        public int CreatorId { get; set; }
        public ICollection<UserViewModel> Attendees { get; set; }
        // Lookups
        public string[] Statuses { get; set; }
        public string[] Types { get; set; }
    }
}
