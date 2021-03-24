using System.Threading.Tasks;
using EFAuth.EmployeeData;
using EFAuth.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using Microsoft.Extensions.Logging;

namespace EFAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private  IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        // [Authorize]
        public IActionResult GetEmployees()
        {
            Log.Information($"GET EmployeeController called at {DateTime.Now}");
            return Ok(_employeeData.GetEmployees());

        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Log.Information($"GET EmployeeController called at {DateTime.Now}");
            var employee = _employeeData.GetEmployee(id);
            if(employee != null)
            {
                return Ok(employee);
            }            
            return NotFound($"Employee with Id: {id} was not found");

        }

        [HttpPost]
        public IActionResult GetEmployee(Employee employee)
        {
             _employeeData.AddEmployee(employee);

             return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +employee.Id,employee);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
 
            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }            
            return NotFound($"Employee with Id: {id} was not found");
        }

        [HttpPut("{id}")] 
        [Authorize]
        public IActionResult EditEmployee(int id, Employee employee)
        {
           var existingemployee = _employeeData.GetEmployee(id);
            
            if(existingemployee != null)
            {
                employee.Id = existingemployee.Id;
               _employeeData.EditEmployee(employee);                
                
            } 
            return  Ok(employee);
        }
    }
}