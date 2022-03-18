using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Controllers;
using System.Globalization;
using zadanie_testowe.Models;

namespace zadanie_testowe.Services
{
    public interface IToDoTaskService
    {        
        IEnumerable<ToDoTask> GetAllTasks();
        ToDoTask GetTaskById(int id);
        IEnumerable<ToDoTask> GetTasksForToday();
        IEnumerable<ToDoTask> GetTasksForNextDay();
        IEnumerable<ToDoTask> GetTasksForCurrentWeek();               
        bool CreateTask(ToDoTaskDto dto);
        bool UpdateTask(ToDoTaskDto dto, int id);
        bool SetPercentComplete(int percentComplete, int id);
        bool SetAsDone(int id);
        bool DeleteTask(int id);
    }

    public class ToDoTaskService : IToDoTaskService
    {
        private ToDoTaskDbContext _dbContext;

        public ToDoTaskService(ToDoTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ToDoTask> GetAllTasks()
        {
            var tasks = _dbContext
                .Tasks
                .ToList();

            return tasks;
        }

        public ToDoTask GetTaskById(int id)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            return task;
        }

        public IEnumerable<ToDoTask> GetTasksForToday()
        {
            var tasks = new List<ToDoTask>();

            foreach (var task in _dbContext.Tasks)
            {
                if (task.DateOfExpiry.Day == DateTime.Now.Day & task.DateOfExpiry.Month == DateTime.Now.Month & task.DateOfExpiry.Year == DateTime.Now.Year & !task.IsDone)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public IEnumerable<ToDoTask> GetTasksForNextDay()
        {
            var tasks = new List<ToDoTask>();

            foreach (var task in _dbContext.Tasks)
            {
                if (task.DateOfExpiry.Day == DateTime.Now.Day+1 & task.DateOfExpiry.Month == DateTime.Now.Month & task.DateOfExpiry.Year == DateTime.Now.Year & !task.IsDone)
                {
                    tasks.Add(task);
                }
            }

            return tasks;
        }

        public IEnumerable<ToDoTask> GetTasksForCurrentWeek()
        {
            var tasks = new List<ToDoTask>();

            foreach (var task in _dbContext.Tasks)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar calendar = dfi.Calendar;
                // Get week number of the year for current week and task's expiry date
                int currentWeek = calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                int taskWeek = calendar.GetWeekOfYear(task.DateOfExpiry, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                if (currentWeek == taskWeek & task.DateOfExpiry.Year == DateTime.Now.Year & task.DateOfExpiry.Day >= DateTime.Now.Day & !task.IsDone)
                {
                    if (task.DateOfExpiry.Day == DateTime.Now.Day & task.DateOfExpiry.TimeOfDay < DateTime.Now.TimeOfDay)
                    {
                        //  Do nothing
                    }
                    else
                    {
                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        public bool CreateTask(ToDoTaskDto dto)
        {
            var task = new ToDoTask
            {
                Tittle = dto.Tittle,
                Description = dto.Description,
                DateOfExpiry = dto.DateOfExpiry
            };

            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateTask(ToDoTaskDto dto, int id)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            if (task is null)   return false;

            if (dto.Tittle is not null)     task.Tittle = dto.Tittle;

            if (dto.Description is not null)    task.Description = dto.Description;

            if (dto.DateOfExpiry > DateTime.Now)    task.DateOfExpiry = dto.DateOfExpiry;

            _dbContext.SaveChanges();
            return true;

        }

        public bool SetPercentComplete(int percentComplete, int id)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            if (task is null)
            {
                return false;
            }

            task.PercentComplete = percentComplete;

            _dbContext.SaveChanges();
            return true;
        }

        public bool SetAsDone(int id)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            if (task is null)
            {
                return false;
            }

            task.IsDone = true;

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _dbContext
                .Tasks
                .FirstOrDefault(t => t.Id == id);

            if (task is null)
            {
                return false;
            }

            foreach (var toDo in _dbContext.Tasks)
            {
                if (toDo.Id == id)
                {
                    _dbContext.Tasks.Remove(toDo);
                    break;
                }
            }

            _dbContext.SaveChanges();
            return true;
        }
    }
}
