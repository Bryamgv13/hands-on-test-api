using HandsOnTest.Domain.Ports;

namespace HandsOnTest.Domain.Entities
{
    public class MonthlyEmployee : IEmployee
    {
        private const int MONTH = 12;

        private readonly double Salary;

        public MonthlyEmployee(double salary)
        {
            this.Salary = salary;
        }

        public double GetSalary()
        {
            return Salary * MONTH;

        }
    }
}
