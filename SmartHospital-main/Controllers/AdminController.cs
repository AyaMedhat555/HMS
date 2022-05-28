using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService AdminService { get; }


        public AdminController(IAdminService _AdminService)
        {

            AdminService = _AdminService;
        }


        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom([FromBody] RoomDto RoomDto)
        {
            return Ok(await AdminService.AddRoom(RoomDto));
        }

        [HttpPut("ReserveRoom/{RoomId}")]
        public async Task<IActionResult> ReserveRoom([FromRoute] int RoomId)
        {
            await AdminService.ReserveRoom(RoomId);
            return Ok($"Room With Id {RoomId} has been Reserved");
        }


        [HttpGet("GetFreeRooms")]
        public async Task<IActionResult> GetFreeRooms()
        {
            return Ok (await AdminService.GetFreeRooms());
           
        }


        [HttpGet("GetFreeBedsByRoomId")]
        public async Task<IActionResult> GetFreeBedsByRoomId(int RoomId)
        {
            return Ok(await AdminService.GetFreeBedsByRoomId(RoomId));

        }
    }
}
