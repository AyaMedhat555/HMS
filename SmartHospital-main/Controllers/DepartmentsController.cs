using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Responses;

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
        public async Task<IActionResult> Register(DepartmentResponse request)
        {
            Console.WriteLine(request.ToString());
            await _departmentService.AddDepartment(request);
            return Ok("Department: " + request.DepartmentName + " was added successfully!");
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


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDepartment(Department dept)
        {
            return Ok(await _departmentService.UpdateDepartment(dept));
        }



        [HttpGet("getPatientsByDepartmentId/{id}")]
        public async Task<IActionResult> GetPatientsById([FromRoute] int id)
        {
            return Ok(await _departmentService.GetDepartmentPatientsById(id));
        }

        [HttpGet("getEmpsByDepartmentId/{id}")]
        public async Task<IActionResult> GetEmpsById([FromRoute] int id)
        {
            return Ok(await _departmentService.GetDepartmentEmpsById(id));
        }

        [HttpGet("getPatientsByDepartmentName")]
        public async Task<IActionResult> GetPatientsByName(string name)
        {
            return Ok(await _departmentService.GetDepartmentPatientsByName(name));
        }

        [HttpGet("getEmpsByDepartmentName")]
        public async Task<IActionResult> GetEmpsByName(string name)
        {
            return Ok(await _departmentService.GetDepartmentEmpsByName(name));
        }


    }
}
