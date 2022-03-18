// Model Dto for creating and updating ToDoTask 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie_testowe.Models
{
    public class ToDoTaskDto
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
