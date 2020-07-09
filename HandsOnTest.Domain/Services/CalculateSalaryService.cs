using HandsOnTest.Domain.Dto;
using HandsOnTest.Domain.Ports;
using System.Collections.Generic;

namespace HandsOnTest.Domain.Services
{
    public class CalculateSalaryService
    {
        private readonly Factory _Factory;

        public CalculateSalaryService(Factory factory)
        {
            this._Factory = factory;
        }

        public IEnumerable<EmployeesResponseDto> CalculateSalaryEmployees(IEnumerable<EmployeesDto> employees)
        {
            List<EmployeesResponseDto> listEmployees = new List<EmployeesResponseDto>();

            foreach(var employee in employees)
            {
                IEmployee employeeFactory = _Factory.GetEmploye(employee);
                listEmployees.Add(new EmployeesResponseDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Role = employee.RoleName,
                    ContractType = employee.ContractTypeName,
                    Salary = employeeFactory.GetSalary()
                });
            }
            return listEmployees;
        }
    }
}
