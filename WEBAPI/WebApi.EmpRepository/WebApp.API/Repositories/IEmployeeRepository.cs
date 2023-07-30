using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> SearchEmployees(string name);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee( int id);
        Task<Employee> AddEmployee(Employee e);
        Task<Employee> UpdateEmployees(Employee e);
        Task<Employee> DeleteEmployees(int id);


    }
}
