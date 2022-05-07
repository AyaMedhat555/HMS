using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using SmartHospital.Models.Labs;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalTestController : ControllerBase
    {
        private IMedicalTestService _medicalTestService { get; }

        public MedicalTestController(IMedicalTestService medicalTestService)
        {
            _medicalTestService=medicalTestService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Test request)
        {
            Console.WriteLine(request.ToString());
            //check if username already used
            await _medicalTestService.AddTest(request);
            return Ok("Test: "+request.Name+" was added successfully!");
        }


        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName(string Testname)
        {
            return Ok(await _medicalTestService.GetTestByName(Testname));
        }

    }
}
