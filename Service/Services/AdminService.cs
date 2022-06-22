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
using Service.Responses;

namespace Service.Services
{
    public class  AdminService : IAdminService
    {

        private  IRoomRepository RoomRepository { get; }
        private  IBedRepository BedRepository { get; }

     
        public AdminService(IRoomRepository _IRoomRepository, IBedRepository _BedRepository)
        {
            RoomRepository = _IRoomRepository;
            BedRepository = _BedRepository;


        }
        //public async Task<RoomDto> AddRoom(RoomDto RoomDto)
        //{
        //    List<BedDto> BedsDto = (List<BedDto>)RoomDto.Beds;

        //    List<Bed> Beds = new List<Bed>();

        //     foreach( var BedDto in BedsDto)
        //    {

        //        Beds.Add(new Bed()
        //        {
        //            Number = BedDto.Number


        //        });
        //    }

        //    var Room = new Room()
        //    {
        //        RoomCharges = RoomDto.RoomCharges,
        //        RoomType = RoomDto.RoomType,
        //        RoomNumber = RoomDto.RoomNumber,

        //        DepartmentId = RoomDto.DepartmentId,
        //        FloorNumber = RoomDto.FloorNumber,
        //        NumberOfBeds = RoomDto.NumberOfBeds,
        //        Beds = Beds



        //    };

        //    await RoomRepository.Add(Room);

        //   return RoomDto;
        //}

        public async Task ReserveRoom(int RoomId)
        {
           Room room=  await RoomRepository.GetById(RoomId);

           List<Bed> FreeBeds = new List<Bed>(); 
          FreeBeds = await BedRepository.GetFreeBedsByRoomId(RoomId).ToListAsync();

            if (FreeBeds.Count == 0) 
            room.Reserved = true;
           await RoomRepository.Update(room);



        }

        public async Task ReserveBed(int BedId)
        {
            Bed bed = await BedRepository.GetById(BedId);
            bed.Reserved = true;
           await BedRepository.Update(bed);

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
                //Beds = R.Beds.Select(B => new BedDto()
                //{
                    
                //    Number = B.Number
                //}).ToList(),

            }
                ) .ToListAsync();
        }

        public async Task<RoomDto> AddRoom(RoomDto RoomDto)
        {
            List<Bed> Beds = new List<Bed>();

            for (int B =1; B <= RoomDto.NumberOfBeds; B++)
            {
                Bed bed = new Bed()
                {
                    Number=B
                   
                };
                Beds.Add(bed);
            } ;

            var Room = new Room()
            {
                RoomCharges = RoomDto.RoomCharges,
                RoomType = RoomDto.RoomType,
                RoomNumber = RoomDto.RoomNumber,

                DepartmentId = RoomDto.DepartmentId,
                FloorNumber = RoomDto.FloorNumber,
                NumberOfBeds = RoomDto.NumberOfBeds,
                Beds=Beds

            };

            await RoomRepository.Add(Room);

             return RoomDto;

        }

        public async Task<IEnumerable<Bed>> GetFreeBedsByRoomId(int RoomId)
        {
             return await BedRepository.GetFreeBedsByRoomId(RoomId).ToListAsync();
        }

        public async Task<IEnumerable<RoomRead>> GetAllRooms()
        {
            //AdminService adminService = new AdminService();

            List<Room> Rooms = RoomRepository.GetAll().ToList();
            List<RoomRead> RoomsRead = new List<RoomRead>();

            for (int i =0; i< Rooms.Count; i++)
            {
                RoomRead roomRead = new RoomRead()
                {
                    FloorNumber = Rooms[i].FloorNumber,
                    NumberOf_freeBeds = BedRepository.GetFreeBedsByRoomId(Rooms[i].Id).ToList().Count(),
                    NumberOf_allBeds = Rooms[i].NumberOfBeds,
                    RoomNumber = Rooms[i].RoomNumber,
                    RoomType = Rooms[i].RoomType
                };
                RoomsRead.Add(roomRead);

            }
            //    NumberOf_allBeds = R.NumberOfBeds,
            //    FloorNumber = R.FloorNumber,
            //    NumberOf_freeBeds = BedRepository.GetFreeBedsByRoomId(R.Id).ToList().Count(),
            //    RoomNumber = R.RoomNumber,
            //    RoomType = R.RoomType

            //}) .ToList();

            
            
            return RoomsRead;

        }
    }
}
