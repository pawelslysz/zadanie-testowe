using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadanie_testowe.Controllers;
using zadanie_testowe.Models;

namespace zadanie_testowe
{
    public class ToDoTaskMappingProfile : Profile
    {
        public ToDoTaskMappingProfile()
        {
            CreateMap<ToDoTask, ToDoTaskDto>();
        }
    }
}
