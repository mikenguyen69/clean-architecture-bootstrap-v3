using AutoMapper;
using clean.architecture.api.DTO;
using clean.architecture.core.Entities;
using clean.architecture.core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clean.architecture.api.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ToDoItem> _repository;

        public ToDoItemsController(IMapper mapper, IRepository<ToDoItem> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List()
                .Select(item => _mapper.Map<ToDoItem, ToDoItemDTO>(item));

            return Ok(items);
        }
    }
}
