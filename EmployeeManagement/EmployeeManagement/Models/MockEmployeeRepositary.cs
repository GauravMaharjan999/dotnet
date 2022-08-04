using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepositary: IEmployeeRepositary
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepositary()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1,
                    Name = "Gaurav", Department = Dept.HR, Email = "Gaurav1@gmail.com"},
                new Employee() { Id = 2,
                Name = "ram", Department = Dept.IT, Email = "ram@gmail.com" },
                new Employee() { Id = 3,
                Name = "sita", Department = Dept.Payroll, Email = "sita@gmail.com" }

            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;

            }
            return employee;
        }
    }
}