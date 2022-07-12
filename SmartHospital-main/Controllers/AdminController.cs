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

        [Authorize(Roles = "Admin,Nurse")]
        [HttpGet("GetFreeRooms")]
        public async Task<IActionResult> GetFreeRooms()
        {
            return Ok (await AdminService.GetFreeRooms());
           
        }

        [Authorize(Roles = "Admin,Nurse")]
        [HttpGet("GetFreeBedsByRoomId")]
        public async Task<IActionResult> GetFreeBedsByRoomId(int RoomId)
        {
            return Ok(await AdminService.GetFreeBedsByRoomId(RoomId));

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await AdminService.GetAllRooms());

        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("deleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            return Ok(await AdminService.DeleteAdmin(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(AdminDto userDto)
        {
            return Ok(await AdminService.UpdateAdmin(userDto));
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            return Ok(await AdminService.GetAllAdmins());
        }
        #endregion

        #region RECEPTIONIST CRUD
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin,Receptionist")]
        [HttpPut("updateReceptionist")]
        public async Task<IActionResult> UpdateReceptionist(ReceptionistDto userDto)
        {
            return Ok(await AdminService.UpdateReceptionist(userDto));
        }

        [Authorize(Roles = "Admin,Receptionist")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllReceptionists")]
        public async Task<IActionResult> GetAllReceptionists()
        {
            return Ok(await AdminService.GetAllReceptionists());
        }
        #endregion
    }
}
