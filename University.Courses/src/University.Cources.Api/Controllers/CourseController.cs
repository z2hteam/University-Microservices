﻿using System.Threading.Tasks;
using MicroPack.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using University.Cources.Application.Commands;

namespace University.Cources.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CourseController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        
        [HttpPost(nameof(Create))]
        public async Task<ActionResult> Create(AddCourse command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
        }
    }
}