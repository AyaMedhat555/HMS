using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService { get; }
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Register(Department request)
        {
            Console.WriteLine(request.ToString());
            //check if username already used
            await _departmentService.AddDepartment(request);
            return Ok("Department: "+request.Department_Name+" was added successfully!");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _departmentService.GetAllDepartments());
        }

        [HttpGet("getAllEmps")]
        public async Task<IActionResult> GetAllEmps()
        {
            return Ok(await _departmentService.GetAllDepartmentsEmps());
        }

        [HttpGet("getAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            return Ok(await _departmentService.GetAllDepartmentsEmps());
        }
    }
}
