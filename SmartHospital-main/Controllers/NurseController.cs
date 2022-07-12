using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO.Users;
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin,Nurse")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin,Nurse")]
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

        


    }
}
