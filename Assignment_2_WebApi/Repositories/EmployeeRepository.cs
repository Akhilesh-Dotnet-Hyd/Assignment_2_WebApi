using Assignment_2_WebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Assignment_2_WebApi.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        static List<Employee> _employees = new List<Employee>()
        {
            new Employee(){Id=101,Name="Prabhas",Email="prabhas@actor.com",Department="Action",MobileNo=1234567890},
            new Employee(){Id=102,Name="Rajamouli",Email="rajamouli@dir.com",Department="Direction",MobileNo=9876543210},
            new Employee(){Id=103,Name="Keeravani",Email="Keeravani@music.com",Department="Music",MobileNo=4567891230}
        };

        public void AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }
        public void DeleteEmployee(int id)
        {
            var emp = GetEmployeeById(id);
            if(emp != null)
            {
                _employees.Remove(emp);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            var emp = _employees.FirstOrDefault(e=> e.Id == id);
            if(emp != null)
            {
                return emp;
            }
            return null;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public List<Employee> GetEmployeesByDept(string name)
        {
            var emps = _employees.FindAll(e => e.Department == name);
            return emps;
        }

        public void UpdateEmployee(Employee emp)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == emp.Id);
            if(existing != null)
            {
                existing.Name = emp.Name;
                existing.Email = emp.Email;
                existing.Department = emp.Department;
                existing.MobileNo= emp.MobileNo;
            }
        }
    }
}
