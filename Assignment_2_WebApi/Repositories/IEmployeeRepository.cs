using Assignment_2_WebApi.Models;

namespace Assignment_2_WebApi.Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public List<Employee> GetEmployeesByDept(string name);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int id);
    }
}
