using HandsOnTest.Application.Employees;
using HandsOnTest.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public EmployeesController(IMediator Mediator)
        {
            this._Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeesResponseDto>> GetAll()
        {
            return await _Mediator.Send(new EmployeesQuery { });
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<EmployeesResponseDto>> Get(int id)
        {
            return await _Mediator.Send(new EmployeesQuery { Id = id });
        }
    }
}
