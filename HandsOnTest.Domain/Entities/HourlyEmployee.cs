using HandsOnTest.Domain.Ports;

namespace HandsOnTest.Domain.Entities
{
    public class HourlyEmployee : IEmployee
    {
        private const int MONTH = 12;
        private const int HOUR = 120;

        private readonly double Salary;

        public HourlyEmployee(double salary) 
        {
            this.Salary = salary;
        }

        public double GetSalary()
        {
            return HOUR * Salary * MONTH;
        }
    }
}
