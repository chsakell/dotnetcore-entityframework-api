using Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduler.Data
{
    public class SchedulerDbInitializer
    {
        private static SchedulerContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SchedulerContext>();
                InitializeSchedules(context);
            }
        }

        private static void InitializeSchedules(SchedulerContext context)
        {
            if(!context.Users.Any())
            {
                User user_01 = new User { Name = "Chris Sakellarios", Profession = "Developer", Avatar = "avatar_02.png" };

                User user_02 = new User { Name = "Charlene Campbell", Profession = "Web Designer", Avatar = "avatar_03.jpg" };

                User user_03 = new User { Name = "Mattie Lyons", Profession = "Engineer", Avatar = "avatar_05.png" };

                User user_04 = new User { Name = "Kelly Alvarez", Profession = "Network Engineer", Avatar = "avatar_01.png" };

                User user_05 = new User { Name = "Charlie Cox", Profession = "Developer", Avatar = "avatar_03.jpg" };

                User user_06 = new User { Name = "Megan	Fox", Profession = "Hacker", Avatar = "avatar_05.png" };

                context.Users.Add(user_01); context.Users.Add(user_02);
                context.Users.Add(user_03); context.Users.Add(user_04);
                context.Users.Add(user_05); context.Users.Add(user_06);

                context.SaveChanges();
            }

            if(!context.Schedules.Any())
            {
                Schedule schedule_01 = new Schedule
                {
                    Title = "Meeting",
                    Description = "Meeting at work with the boss",
                    Location = "Korai",
                    CreatorId = 1,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Work,
                    TimeStart = DateTime.Now.AddHours(4),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 1, UserId = 2 },
                        new Attendee() { ScheduleId = 1, UserId = 3 },
                        new Attendee() { ScheduleId = 1, UserId = 4 }
                    }                    
                };

                Schedule schedule_02 = new Schedule
                {
                    Title = "Coffee",
                    Description = "Coffee with folks",
                    Location = "Athens",
                    CreatorId = 2,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Coffee,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 2, UserId = 1 },
                        new Attendee() { ScheduleId = 1, UserId = 3 },
                        new Attendee() { ScheduleId = 2, UserId = 4 }
                    }
                };

                Schedule schedule_03 = new Schedule
                {
                    Title = "Shopping day",
                    Description = "Shopping therapy",
                    Location = "Attica",
                    CreatorId = 3,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Shopping,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 3, UserId = 1 },
                        new Attendee() { ScheduleId = 3, UserId = 4 },
                        new Attendee() { ScheduleId = 3, UserId = 5 }
                    }
                };

                Schedule schedule_04 = new Schedule
                {
                    Title = "Family",
                    Description = "Thanks giving day",
                    Location = "Home",
                    CreatorId = 5,
                    Status = ScheduleStatus.Valid,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(3),
                    TimeEnd = DateTime.Now.AddHours(6),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 4, UserId = 1 },
                        new Attendee() { ScheduleId = 4, UserId = 2 },
                        new Attendee() { ScheduleId = 4, UserId = 5 }
                    }
                };

                Schedule schedule_05 = new Schedule
                {
                    Title = "Friends",
                    Description = "Friends giving day",
                    Location = "Home",
                    CreatorId = 5,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(5),
                    TimeEnd = DateTime.Now.AddHours(7),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 4, UserId = 1 },
                        new Attendee() { ScheduleId = 4, UserId = 2 },
                        new Attendee() { ScheduleId = 4, UserId = 3 },
                        new Attendee() { ScheduleId = 4, UserId = 4 },
                        new Attendee() { ScheduleId = 4, UserId = 5 }
                    }
                };

                Schedule schedule_06 = new Schedule
                {
                    Title = "Meeting with the boss and collegues",
                    Description = "Discuss project planning",
                    Location = "Office",
                    CreatorId = 3,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(22),
                    TimeEnd = DateTime.Now.AddHours(30),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 4, UserId = 1 },
                        new Attendee() { ScheduleId = 4, UserId = 2 },
                        new Attendee() { ScheduleId = 4, UserId = 5 }
                    }
                };

                Schedule schedule_07 = new Schedule
                {
                    Title = "Scenario presentation",
                    Description = "Discuss new movie's scenario",
                    Location = "My special place",
                    CreatorId = 6,
                    Status = ScheduleStatus.Cancelled,
                    Type = ScheduleType.Other,
                    TimeStart = DateTime.Now.AddHours(11),
                    TimeEnd = DateTime.Now.AddHours(13),
                    Attendees = new List<Attendee>
                    {
                        new Attendee() { ScheduleId = 4, UserId = 4 },
                        new Attendee() { ScheduleId = 4, UserId = 2 },
                        new Attendee() { ScheduleId = 4, UserId = 3 }
                    }
                };

                context.Schedules.Add(schedule_01); context.Schedules.Add(schedule_02);
                context.Schedules.Add(schedule_03); context.Schedules.Add(schedule_04);
                context.Schedules.Add(schedule_05); context.Schedules.Add(schedule_06);
            }

            context.SaveChanges();
        }
    }
}
