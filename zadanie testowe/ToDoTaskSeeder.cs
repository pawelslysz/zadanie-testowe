// Inserting sample values into the database

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Controllers;

namespace zadanie_testowe
{
    public class ToDoTaskSeeder
    {
        private readonly ToDoTaskDbContext _dbContext;

        public ToDoTaskSeeder(ToDoTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Tasks.Any())
                {
                    var tasks = GetTasks();
                    _dbContext.Tasks.AddRange(tasks);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<ToDoTask> GetTasks()
        {
            DateTime timeToExpiry1 = new DateTime(2022, 03, 22, 12, 30, 0);
            DateTime timeToExpiry2 = new DateTime(2022, 03, 24, 20, 40, 0);

            var tasks = new List<ToDoTask>()
            {
                new ToDoTask()
                {
                    Tittle = "kupić mleko",
                    Description = "najlepiej w Lidlu",
                    PercentComplete = 0,
                    DateOfExpiry = new DateTime(2022, 03, 20, 12, 30, 0),
                },

                new ToDoTask()
                {
                    Tittle = "zamówić bilety",
                    Description = "bilet do kina na poniedziałek na batmana",
                    PercentComplete = 0,
                    DateOfExpiry = new DateTime(2022, 03, 24, 20, 40, 0),
                }
            };

            return tasks;
        }
    }
}
