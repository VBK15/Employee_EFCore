using System.Collections.Generic;
using EFAuth.Entities;
using EFAuth.EmployeeData;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFAuth.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id =1,
                Name = "Clark"
            },
             new Employee()
            {
                Id =2,
                Name = "Bruce"
            }
        };        
        public Employee AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return employee;            
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingemployee = GetEmployee(employee.Id);
            existingemployee.Name =employee.Name;

            return existingemployee;

        }

        public Employee GetEmployee(int id)
        {
            return employees.SingleOrDefault(x => x.Id ==id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

      
    }
}