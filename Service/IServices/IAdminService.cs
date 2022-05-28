using Domain.Models;
using Service.DTO;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IAdminService
    {
        Task<RoomDto> AddRoom(RoomDto RoomDto);
        Task ReserveRoom(int RoomId);
        Task ReserveBed(int BedId);

       Task <IEnumerable<RoomDto>> GetFreeRooms();
       Task<IEnumerable<Bed>> GetFreeBedsByRoomId(int RoomId);

    }
}
