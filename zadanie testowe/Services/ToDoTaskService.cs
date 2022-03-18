using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Controllers;
using System.Globalization;

namespace zadanie_testowe.Services
{
    public interface IToDoTaskService
    {
        IEnumerable<ToDoTask> GetAllTasks();
        ToDoTask GetTaskById(int id);
        IEnumerable<ToDoTask> GetTasksForCurrentWeek();
        IEnumerable<ToDoTask> GetTasksForNextDay();
        IEnumerable<ToDoTask> GetTasksForToday();
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
                if (task.DateOfExpiry.Day == DateTime.Now.Day & task.DateOfExpiry.Month == DateTime.Now.Month & task.DateOfExpiry.Year == DateTime.Now.Year)
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
                if (task.DateOfExpiry.Day == DateTime.Now.Day+1 & task.DateOfExpiry.Month == DateTime.Now.Month & task.DateOfExpiry.Year == DateTime.Now.Year)
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
                int currentWeek = calendar.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                int taskWeek = calendar.GetWeekOfYear(task.DateOfExpiry, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

                if (currentWeek == taskWeek & task.DateOfExpiry.Year == DateTime.Now.Year & task.DateOfExpiry.Day >= DateTime.Now.Day)
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

    }
}
