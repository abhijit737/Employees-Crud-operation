using EmpManagementAPI.Data;
using EmpManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
} 
