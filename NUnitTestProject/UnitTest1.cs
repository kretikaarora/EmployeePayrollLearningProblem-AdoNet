using Ado.Net;
using NUnit.Framework;


namespace NUnitTestProject
{
    public class Tests
    {
        [Test]
        public void UpdatingSalaryFromDataBaseAndReadingSalary()
        {
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.employeeId = 4;
            model.name = "Kretika";
            model.salary =6000000;
            repository.UpdateEmployeeDetailsInTheDataBase(model);
            decimal actualvalue = repository.ReadingUpdatedSalaryfromDataBase();
            Assert.AreEqual(model.salary, actualvalue);

        }
    }
}