using Ado.Net;
using NUnit.Framework;


namespace NUnitTestProject
{
    public class Tests
    {
        /// <summary>
        /// Updating Salary From Data Base And Reading Salary
        /// UC4
        /// </summary>
        [Test]
        public void UpdatingSalaryFromDataBaseAndReadingSalary()
        {
            ///creating instance of Employee repository class and EmployeeModel
            EmployeeRepository repository = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            ///initialising data 
            model.employeeId = 4;
            model.name = "Kretika";
            model.salary =6000000;
            ///updating using update function
            repository.UpdateEmployeeDetailsInTheDataBase(model);
            ///checking if value returned from Reading is same 
            decimal actualvalue = repository.ReadingUpdatedSalaryfromDataBase();
            Assert.AreEqual(model.salary, actualvalue);

        }
    }
}