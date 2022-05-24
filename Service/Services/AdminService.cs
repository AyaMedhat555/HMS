using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.IRepositories;

namespace Service.Services
{
    public class AdminService : IAdminService
    {

        private IRoomRepository RoomRepository { get; }

        public AdminService(IRoomRepository _IRoomRepository)
        {
            RoomRepository = _IRoomRepository;
          
        }
        public async Task<RoomDto> AddRoom(RoomDto RoomDto)
        {
            List<BedDto> BedsDto = (List<BedDto>)RoomDto.Beds;

            List<Bed> Beds = new List<Bed>();

             foreach( var BedDto in BedsDto)
            {

                Beds.Add(new Bed()
                {
                    Number = BedDto.Number


                });
            }

            var Room = new Room()
            {
                RoomCharges = RoomDto.RoomCharges,
                RoomType = RoomDto.RoomType,
                RoomNumber = RoomDto.RoomNumber,

                DepartmentId = RoomDto.DepartmentId,
                FloorNumber = RoomDto.FloorNumber,
                NumberOfBeds = RoomDto.NumberOfBeds,
                Beds = Beds



            };

            await RoomRepository.Add(Room);

           return RoomDto;
        }

        public async Task ReserveRoom(int RoomId)
        {
           Room room=  await RoomRepository.GetById(RoomId);
            room.Reserved = true;
            RoomRepository.Update(room);



        }

        public async Task <IEnumerable<RoomDto>> GetFreeRooms()
        {
            return await RoomRepository.GetFreeRooms().Select(R => new RoomDto()
            {
                Id = R.Id,
                NumberOfBeds = R.NumberOfBeds,
                RoomCharges = R.RoomCharges,
                FloorNumber = R.FloorNumber,
                DepartmentId = R.DepartmentId,
                RoomNumber = R.RoomNumber,
                RoomType = R.RoomType,
                Beds = R.Beds.Select(B => new BedDto()
                {
                    
                    Number = B.Number
                }).ToList(),

            }



                ) .ToListAsync();
        }
    }
}
