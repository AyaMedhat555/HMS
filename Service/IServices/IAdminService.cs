using Domain.Models;
using Domain.Models.Users;
using Service.DTO;
using Service.DTO.Users;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IAdminService : IUserService
    {
        Task<RoomDto> AddRoom(RoomDto RoomDto);
        Task ReserveRoom(int RoomId);
        Task ReserveBed(int BedId);

       Task <IEnumerable<RoomDto>> GetFreeRooms();
       Task<IEnumerable<Bed>> GetFreeBedsByRoomId(int RoomId);
       Task<IEnumerable<RoomRead>> GetAllRooms();

        Task<Admin> AddAdmin(AdminDto admin_dto);
        Task<Admin> DeleteAdmin(int admin_id);
        Task<Admin> UpdateAdmin(AdminDto admin_dto);
        Task<IEnumerable<AdminDto>> GetAllAdmins();
        Task<AdminDto> GetAdminById(int admin_id);

        Task<Receptionist> AddReceptionist(ReceptionistDto receptionist_dto);
        Task<Receptionist> DeleteReceptionist(int receptionist_id);
        Task<Receptionist> UpdateReceptionist(ReceptionistDto receptionist_dto);
        Task<IEnumerable<ReceptionistDto>> GetAllReceptionists();
        Task<ReceptionistDto> GetReceptionistById(int receptionist_id);

    }
}
