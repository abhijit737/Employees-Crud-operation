using EmpManagementAPI.Data;
using EmpManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmpManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmpdbContext _empdbcontext;
        public EmployeeController(EmpdbContext empdbcontext)
        {
            _empdbcontext = empdbcontext;            
        }
        [HttpGet]
        public async Task< IActionResult> GetAllEmployees()
        {
          var employees = await _empdbcontext.Employees.ToListAsync(); 
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody]Employee employeeRequest)

        {
            employeeRequest.Id = Guid.NewGuid();
            await _empdbcontext.Employees.AddAsync(employeeRequest);
            await _empdbcontext.SaveChangesAsync();
            return Ok(employeeRequest);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        // id is used to query database
        public async Task<IActionResult>GetEmployee([FromRoute] Guid id)
        {
          var employee = await _empdbcontext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee ==null)
            {
                return NotFound();
            }
            return Ok(employee);    

        }
    
        
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult>UpdateEmployee([FromRoute] Guid id,Employee updateEmployeeRequest)
        {
        
            var employee=   await _empdbcontext.Employees.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }
                employee.Name= updateEmployeeRequest.Name;
                employee.Email = updateEmployeeRequest.Email;
                employee.Salary = updateEmployeeRequest.Salary;
                employee.Phone = updateEmployeeRequest.Phone;
                employee.Department = updateEmployeeRequest.Department;

                await _empdbcontext.SaveChangesAsync();
                 return Ok(employee);


            
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _empdbcontext.Employees.FindAsync(id);
            if  (employee == null)
            {
                return NotFound();
            }


            _empdbcontext.Employees.Remove(employee);

            await _empdbcontext.SaveChangesAsync();
            return Ok(employee);
        }
    }


} 
