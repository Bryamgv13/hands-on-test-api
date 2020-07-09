using HandsOnTest.Domain.Dto;
using HandsOnTest.Domain.Entities;
using HandsOnTest.Domain.Ports;
using System;

namespace HandsOnTest.Domain.Services
{
    public class Factory
    {
        public IEmployee GetEmploye(EmployeesDto employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlyEmployee(employee.HourlySalary);
                case "MonthlySalaryEmployee":
                    return new MonthlyEmployee(employee.MonthlySalary);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
