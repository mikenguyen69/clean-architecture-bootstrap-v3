using AutoMapper;
using clean.architecture.api.DTO;
using clean.architecture.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clean.architecture.api.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<ToDoItem, ToDoItemDTO>();
                x.CreateMap<ToDoItemDTO, ToDoItem>();
            });

            return config.CreateMapper();
        }
    }
}
