using HandsOnTest.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandsOnTest.Domain.Tests
{
    [TestClass]
    public class CalculateSalaryTest
    {
        [TestMethod]
        public void CalculateSalaryHourlyEmployee()
        {
            //Arrage
            HourlyEmployee employee = new HourlyEmployee(60000);

            //Act
            double salary = employee.GetSalary();

            //Assert
            Assert.AreEqual(86400000, salary);
        }

        [TestMethod]
        public void CalculateSalaryMonthlyEmployee()
        {
            //Arrage
            MonthlyEmployee employee = new MonthlyEmployee(80000);

            //Act
            double salary = employee.GetSalary();

            //Assert
            Assert.AreEqual(960000, salary);
        }
    }
}
