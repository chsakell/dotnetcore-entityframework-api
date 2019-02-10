using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using Scheduler.API.ViewModels;
using AutoMapper;
using Scheduler.API.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Scheduler.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IAttendeeRepository _attendeeRepository;

        int page = 1;
        int pageSize = 10;
        public UsersController(IUserRepository userRepository,
                                IScheduleRepository scheduleRepository,
                                IAttendeeRepository attendeeRepository)
        {
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
            _attendeeRepository = attendeeRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalUsers = _userRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            IEnumerable<User> _users = _userRepository
                .AllIncluding(u => u.SchedulesCreated)
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            IEnumerable<UserViewModel> _usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_users);

            Response.AddPagination(page, pageSize, totalUsers, totalPages);

            return new OkObjectResult(_usersVM);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            User _user = _userRepository.GetSingle(u => u.Id == id, u => u.SchedulesCreated);

            if (_user != null)
            {
                UserViewModel _userVM = Mapper.Map<User, UserViewModel>(_user);
                return new OkObjectResult(_userVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/schedules", Name = "GetUserSchedules")]
        public IActionResult GetSchedules(int id)
        {
            IEnumerable<Schedule> _userSchedules = _scheduleRepository.FindBy(s => s.CreatorId == id);

            if (_userSchedules != null)
            {
                IEnumerable<ScheduleViewModel> _userSchedulesVM = Mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(_userSchedules);
                return new OkObjectResult(_userSchedulesVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            _userRepository.Add(_newUser);
            _userRepository.Commit();

            user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetUser", new { controller = "Users", id = user.Id }, user);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User _userDb = _userRepository.GetSingle(id);

            if (_userDb == null)
            {
                return NotFound();
            }
            else
            {
                _userDb.Name = user.Name;
                _userDb.Profession = user.Profession;
                _userDb.Avatar = user.Avatar;
                _userRepository.Commit();
            }

            user = Mapper.Map<User, UserViewModel>(_userDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User _userDb = _userRepository.GetSingle(id);

            if (_userDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                IEnumerable<Attendee> _attendees = _attendeeRepository.FindBy(a => a.UserId == id);
                IEnumerable<Schedule> _schedules = _scheduleRepository.FindBy(s => s.CreatorId == id);

                foreach (var attendee in _attendees)
                {
                    _attendeeRepository.Delete(attendee);
                }

                foreach (var schedule in _schedules)
                {
                    _attendeeRepository.DeleteWhere(a => a.ScheduleId == schedule.Id);
                    _scheduleRepository.Delete(schedule);
                }

                _userRepository.Delete(_userDb);

                _userRepository.Commit();

                return new NoContentResult();
            }
        }

    }

}
