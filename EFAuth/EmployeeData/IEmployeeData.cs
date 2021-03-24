using System.Collections.Generic;
using System.Threading.Tasks;
using EFAuth.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFAuth.EmployeeData
{
    public interface IEmployeeData
    {
         
         List<Employee> GetEmployees();

         Employee GetEmployee(int id);

         Employee AddEmployee(Employee employee);

         void DeleteEmployee(Employee employee);

         Employee EditEmployee(Employee employee);
        
    }
}