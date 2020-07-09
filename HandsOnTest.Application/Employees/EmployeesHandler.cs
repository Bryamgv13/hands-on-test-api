using HandsOnTest.Domain.Dto;
using HandsOnTest.Domain.Ports;
using HandsOnTest.Domain.Services;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HandsOnTest.Application.Employees
{
    public class EmployeesHandler : IRequestHandler<EmployeesQuery, IEnumerable<EmployeesResponseDto>>
    {
        private readonly IEmployeesRepository _EmployeesRepository;
        private readonly CalculateSalaryService _CalculateSalaryService;

        public EmployeesHandler(IEmployeesRepository employeesRepository, CalculateSalaryService calculateSalaryService)
        {
            this._EmployeesRepository = employeesRepository;
            this._CalculateSalaryService = calculateSalaryService;
        }

        public async Task<IEnumerable<EmployeesResponseDto>> Handle(EmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesData = await _EmployeesRepository.GetEmployees().ConfigureAwait(false);
            var employees = (request.Id != 0) ? employeesData.Where(employee => employee.Id == request.Id) : employeesData;
            return _CalculateSalaryService.CalculateSalaryEmployees(employees);
        }
    }
}
