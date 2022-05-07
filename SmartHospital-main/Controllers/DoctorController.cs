using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService DoctorService { get; }

        public DoctorController(IDoctorService _DoctorService)
        {
            DoctorService = _DoctorService;

        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDto dto)
        {
            return Ok(await DoctorService.AddDoctor(dto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            DoctorDto user = await DoctorService.GetDoctorById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");

        }

        [HttpGet("getAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await DoctorService.GetAllDoctors());
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DoctorDto userDto)
        {
            return Ok(await DoctorService.UpdateDoctor(userDto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await DoctorService.DeleteDoctor(id));
        }
    }
}
