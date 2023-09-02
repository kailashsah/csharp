using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.API.DataContext;

namespace WebApp.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _Context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<Employee> AddEmployee(Employee e)
        {
            var result = await _Context.employees.AddAsync(e);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployees(int id) 
        {
            var result = await _Context.employees.Where(model => model.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.employees.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _Context.employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _Context.employees.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployees(Employee e)
        {

           var result = await _Context.employees.Where(m => m.Id == e.Id).FirstOrDefaultAsync<Employee>();

            if (result != null)
            {
                result.Id = e.Id;
                result.Name = e.Name;
                result.City = e.City;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name)
        {
            IQueryable<Employee> query = _Context.employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.StartsWith(name));
            }
            return await query.ToListAsync();
        }
    }
}
