using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.DTO.Users;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private IAdminService AdminService { get; }


        public AdminController(IAdminService _AdminService)
        {

            AdminService = _AdminService;
        }

        [Authorize(Roles = "Admin")]

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


        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await AdminService.GetAllRooms());

        }

        [HttpGet("GetNumbers/{Today}")]
        public async Task<IActionResult> GetNumbers(DateTime Today)
        {
            return Ok(await AdminService.GetNumbers(Today));

        }

        [HttpGet("GetAppointmentsPerMonthByDeptId/{DeptId}/{Month}")]
        public async Task<IActionResult> GetAppointmentsPerMonthByDeptId(int DeptId,int Month)
        {
            return Ok(await AdminService.AppointmentsPerMonthByDeptId(DeptId,Month));

        }

        [HttpGet("GetNumberOfIndoorPatientsbyDeptId/{DeptId}")]
        public async Task<IActionResult> GetIndoorPatientsByDeptId(int DeptId)
        {
            return Ok(await AdminService.GetNumberOfIndoorPatientsbyDeptId(DeptId));

        }


        #region ADMIN CRUD

        [HttpPost("admin")]
        public async Task<IActionResult> AddAdmin([FromBody] AdminDto dto)
        {
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await AdminService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await AdminService.AddAdmin(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }

        [HttpDelete("deleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            return Ok(await AdminService.DeleteAdmin(id));
        }

        [HttpPut("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(AdminDto userDto)
        {
            return Ok(await AdminService.UpdateAdmin(userDto));
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetAdminById([FromRoute] int id)
        {
            AdminDto user = await AdminService.GetAdminById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");
        }

        [HttpGet("getAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            return Ok(await AdminService.GetAllAdmins());
        }
        #endregion

        #region RECEPTIONIST CRUD
        [HttpPost("receptionist")]
        public async Task<IActionResult> AddReceptionist([FromBody] ReceptionistDto dto)
        {
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await AdminService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await AdminService.AddReceptionist(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }

        [HttpDelete("deleteReceptionist")]
        public async Task<IActionResult> DeleteReceptionist(int id)
        {
            return Ok(await AdminService.DeleteReceptionist(id));
        }

        [HttpPut("updateReceptionist")]
        public async Task<IActionResult> UpdateReceptionist(ReceptionistDto userDto)
        {
            return Ok(await AdminService.UpdateReceptionist(userDto));
        }

        [HttpGet("receptionist/{id}")]
        public async Task<IActionResult> GetReceptionistById([FromRoute] int id)
        {
            ReceptionistDto user = await AdminService.GetReceptionistById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");
        }

        [HttpGet("getAllReceptionists")]
        public async Task<IActionResult> GetAllReceptionists()
        {
            return Ok(await AdminService.GetAllReceptionists());
        }
        #endregion
    }
}
