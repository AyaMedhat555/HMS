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
using Microsoft.Extensions.Configuration;
using Service.Helpers;

namespace Service.Services
{
    public class  AdminService : UserService, IAdminService
    {

        private  IRoomRepository RoomRepository { get; }
        private  IBedRepository BedRepository { get; }
        private  IUserRepository UserRepository { get; }


        public AdminService(IUserRepository _UserRepository, IRoomRepository _IRoomRepository, IBedRepository _BedRepository, IConfiguration _Configuration)
            : base(_UserRepository, _Configuration)
        {
            RoomRepository = _IRoomRepository;
            BedRepository = _BedRepository;
            UserRepository = _UserRepository;


        }
        

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

        #region ADMIN CRUD 
        public async Task<Admin> AddAdmin(AdminDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Admin admin = UserMapper.ToAdmin(dto);
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;
            return (Admin)await UserRepository.Add(admin);
        }

        public async Task<Admin> DeleteAdmin(int Admin_id)
        {
            return (Admin)await UserRepository.Delete(Admin_id);
        }

        public async Task<Admin> UpdateAdmin(AdminDto dto)
        {
            Admin currentAdmin = (Admin)await UserRepository.GetById(dto.Id);
            currentAdmin = UserMapper.UpdateAdmin(dto, currentAdmin);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            currentAdmin.PasswordHash = passwordHash;
            currentAdmin.PasswordSalt = passwordSalt;
            return (Admin)await UserRepository.Update(currentAdmin);
        }


        public async Task<AdminDto> GetAdminById(int Admin_id)
        {
            Admin admin = (Admin)await UserRepository.GetById(Admin_id);
            AdminDto admin_dto = UserMapper.ToAdminDto(admin);
            return admin_dto;
        }

        public async Task<IEnumerable<AdminDto>> GetAllAdmins()
        {
            return await UserRepository.GetAll().OfType<Admin>()
                .Select(u => new AdminDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }

        #endregion

        #region RECEPTIONIST CRUD
        public async Task<Receptionist> AddReceptionist(ReceptionistDto dto)
        {
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Receptionist receptionist = UserMapper.ToReceptionist(dto);
            receptionist.PasswordHash = passwordHash;
            receptionist.PasswordSalt = passwordSalt;
            return (Receptionist)await UserRepository.Add(receptionist);
        }

        public async Task<Receptionist> DeleteReceptionist(int Receptionist_id)
        {
            return (Receptionist)await UserRepository.Delete(Receptionist_id);
        }

        public async Task<Receptionist> UpdateReceptionist(ReceptionistDto dto)
        {
            Receptionist currentReceptionist = (Receptionist)await UserRepository.GetById(dto.Id);
            currentReceptionist = UserMapper.UpdateReceptionist(dto, currentReceptionist);
            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            currentReceptionist.PasswordHash = passwordHash;
            currentReceptionist.PasswordSalt = passwordSalt;
            return (Receptionist)await UserRepository.Update(currentReceptionist);
        }


        public async Task<ReceptionistDto> GetReceptionistById(int Receptionist_id)
        {
            Receptionist receptionist = (Receptionist)await UserRepository.GetById(Receptionist_id);
            ReceptionistDto receptionist_dto = UserMapper.ToReceptionistDto(receptionist);
            return receptionist_dto;
        }

        public async Task<IEnumerable<ReceptionistDto>> GetAllReceptionists()
        {
            return await UserRepository.GetAll().OfType<Admin>().Select(u => new ReceptionistDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Mail = u.Mail,
                NationalId = u.NationalId,
                Image = u.Image,
                Gender = u.Gender,
                PhoneNumber = u.PhoneNumber,
                DepartmentName = u.Department.Department_Name,
                CreatedDtm = u.CreatedDtm,
                IsActive = u.IsActive
            }).ToListAsync();
        }
        #endregion
    }
}
