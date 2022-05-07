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
            NurseDto nurse = UserMapper.ToNurseDto(await NurseService.AddNurse(dto));
            return Ok(nurse);
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
