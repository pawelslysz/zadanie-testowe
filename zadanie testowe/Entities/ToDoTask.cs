using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie_testowe.Controllers
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public int PercentComplete { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public double TimeToExpiry { get; set; }
    }
}
