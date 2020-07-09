using HandsOnTest.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.Domain.Ports
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeesDto>> GetEmployees();
    }
}
