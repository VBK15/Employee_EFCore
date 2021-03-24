using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFAuth.Data;
using EFAuth.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFAuth.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private  EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
           
        }

        public Employee EditEmployee(Employee employee)
        {
           var existingemployee = _employeeContext.Employees.Find(employee.Id);

           if(existingemployee != null)
           {
               _employeeContext.Employees.Update(employee);
               _employeeContext.SaveChanges();
           }

           return employee;
        }

        public Employee GetEmployee(int id)
        {
        //    return _employeeContext.Employees.SingleOrDefault(x=>x.Id == id);

            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

      
    }
}