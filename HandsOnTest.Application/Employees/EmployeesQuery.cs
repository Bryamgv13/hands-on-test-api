using HandsOnTest.Domain.Dto;
using MediatR;
using System.Collections.Generic;

namespace HandsOnTest.Application.Employees
{
    public class EmployeesQuery : IRequest<IEnumerable<EmployeesResponseDto>>
    {
        public int Id { get; set; }
    }
}
