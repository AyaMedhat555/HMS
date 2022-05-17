using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService PatientService { get; }

        public PatientController(IPatientService _PatientService)
        {
            PatientService = _PatientService;

        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto dto)
        {
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await PatientService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await PatientService.AddPatient(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            PatientDto user = await PatientService.GetPatientById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");

        }

        [HttpGet("getAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await PatientService.GetAllPatients());
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(PatientDto userDto)
        {
            return Ok(await PatientService.UpdatePatient(userDto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await PatientService.DeletePatient(id));
        }
    }
}
