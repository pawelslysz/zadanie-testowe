using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Services;

namespace zadanie_testowe.Controllers
{
    [Route("tasks")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
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

    }
}
