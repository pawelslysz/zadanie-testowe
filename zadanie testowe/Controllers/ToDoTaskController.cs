using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Models;
using zadanie_testowe.Services;

namespace zadanie_testowe.Controllers
{
    [Route("tasks")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly IMapper _mapper;

        public ToDoTaskController(IToDoTaskService toDoTaskService, IMapper mapper)
        {
            _toDoTaskService = toDoTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoTask>> GetAllTasks()
        {
            var tasks = _toDoTaskService.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoTask> GetTaskById([FromRoute] int id)
        {
            var task = _toDoTaskService.GetTaskById(id);

            return Ok(task);
        }

        [HttpGet("today")]
        public ActionResult<IEnumerable<ToDoTask>> GetTaskForToday()
        {
            var tasks = _toDoTaskService.GetTasksForToday();

            return Ok(tasks);
        }

        [HttpGet("nextDay")]
        public ActionResult<IEnumerable<ToDoTask>> GetTaskForNextDay()
        {
            var tasks = _toDoTaskService.GetTasksForNextDay();

            return Ok(tasks);
        }

        [HttpGet("currentWeek")]
        public ActionResult<IEnumerable<ToDoTask>> GetTaskForCurrentWeek()
        {
            var tasks = _toDoTaskService.GetTasksForCurrentWeek();

            return Ok(tasks);
        }


        [HttpPost]
        public ActionResult CreateTask([FromBody] ToDoTaskDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isCreated = _toDoTaskService.CreateTask(dto);

            if (!isCreated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask([FromBody] ToDoTaskDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = _toDoTaskService.UpdateTask(dto, id);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("percent/{id}")]
        public ActionResult SetPercentComplete([FromQuery] int percentComplete, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isSet = _toDoTaskService.SetPercentComplete(percentComplete, id);

            if (!isSet)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("done/{id}")]
        public ActionResult SetAsDone([FromRoute] int id)
        {
            var isSet = _toDoTaskService.SetAsDone(id);

            if (!isSet)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask([FromRoute] int id)
        {
            var isDeleted = _toDoTaskService.DeleteTask(id);

            if (!isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}
