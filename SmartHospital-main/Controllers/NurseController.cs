using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.Helpers;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private INurseService NurseService { get; }


        public NurseController(INurseService _NurseService)
        {
            NurseService = _NurseService;

        }

        [HttpPost]
        public async Task<IActionResult> AddNurse([FromBody] NurseDto dto)
        {
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await NurseService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await NurseService.AddNurse(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            NurseDto user = await NurseService.GetNurseById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");

        }

        [HttpGet("getAllNurses")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await NurseService.GetAllNurses());
        }

        [HttpGet("getByState")]
        public async Task<IActionResult> GetByState(bool state)
        {
            return Ok(await NurseService.GetNursesByState(state));
        }

        [HttpGet("getBySpecialization")]
        public async Task<IActionResult> GetBySpecialization(string specialization)
        {
            return Ok(await NurseService.GetNursesBySpecialization(specialization));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(NurseDto userDto)
        {
            return Ok(await NurseService.UpdateNurse(userDto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await NurseService.DeleteNurse(id));
        }

        [HttpPost("AddVitalSignes")]
        public async Task<IActionResult> AddVitalSignes([FromBody] VitalSigneDto VitalSignsDto)
        {

            return Ok(await NurseService.AddVitalSignes(VitalSignsDto));
        }


        [HttpGet("GetVitalSignesByRangeOfDate/{PatientId}/{StartDate}/{EndDate}")]
        public async Task<IActionResult> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate,DateTime EndDate)
        {
            return Ok(await NurseService.GetVitalSignesByRangeOfDate(PatientId, StartDate, EndDate));
        }



        //[HttpGet("GetVitalSignesByRangeOfDate2/{PatientId}/{StartDate}/{EndDate}")]
        //public Task <IActionResult> GetVitalSignesByRangeOfDate2(int PatientId, DateTime StartDate, DateTime EndDate)
        //{
        //    return Ok(NurseService.;
        //}
    }
}
