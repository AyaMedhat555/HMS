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
using Service.Responses;
using Microsoft.Extensions.Configuration;
using Service.Helpers;
using Domain.Models.Users;
using Service.DTO.Users;

namespace Service.Services
{
    public class  AdminService : UserService, IAdminService
    {
        private  IRoomRepository RoomRepository { get; }
        private  IBedRepository BedRepository { get; }
        private  IUserRepository UserRepository { get; }
        private  IAppointmentRepository AppointmentRepository { get; }
        private  IIndoorPatientRepository IndoorPatientRepository { get; }
        private  IReceptionistRepository ReceptionistRepository { get; }
        private  IDoctorRepository DoctorRepository { get; }
        private  INurseRepository NurseRepository { get; }



        public AdminService(IUserRepository _UserRepository, IRoomRepository _IRoomRepository, IBedRepository _BedRepository, IConfiguration _Configuration, IAppointmentRepository _AppointmentRepository, IIndoorPatientRepository _IndoorPatientRepository, IReceptionistRepository _ReceptionistRepository
         ,IDoctorRepository _DoctorRepository, INurseRepository _NurseRepository)
            : base(_UserRepository, _Configuration)
        {
            RoomRepository = _IRoomRepository;
            BedRepository = _BedRepository;
            UserRepository = _UserRepository;
            AppointmentRepository = _AppointmentRepository;
            IndoorPatientRepository = _IndoorPatientRepository;
            ReceptionistRepository = _ReceptionistRepository;
            DoctorRepository = _DoctorRepository;
            NurseRepository = _NurseRepository;
        }
        public async Task<Numbers> GetNumbers(DateTime Today)
        {
             Numbers numbers = new Numbers()
            {
                NumberOfAllAppointments = AppointmentRepository.GetAll().Count(),
                NumberOfTodayAppointments = AppointmentRepository.GetTodayAppointments(Today).Count(),
                NumberOfReceptionist = ReceptionistRepository.GetAll().Count(),
                NumberOfDoctors = DoctorRepository.GetAllDoctors().Count(),
                NumberOfInPatients = IndoorPatientRepository.GetInDoorPatients().Count(),
                NumberOfOutPatients = IndoorPatientRepository.GetDischargedPatients().Count(),
                NumberOfNurses= NurseRepository.GetAll().Count()
            }  ;

            return  numbers;
        }

        public async Task<int> GetNumberOfIndoorPatientsbyDeptId(int? DeptId)
        {
             return await IndoorPatientRepository.GetInDoorPatientsByDept(DeptId).CountAsync();
        }

        public async Task <IEnumerable<Appointment>> AppointmentsPerMonthByDeptId(int DeptId, int Month)
        {
            return await AppointmentRepository.AppointmentsPerMonthByDeptId(DeptId,Month).ToListAsync();
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
              
            return RoomsRead;

        }

        #region ADMIN CRUD 
        public async Task<Admin> AddAdmin(AdminDto dto)
        {
            Admin admin = UserMapper.ToAdmin(dto);
            if (dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                admin.PasswordHash = passwordHash;
                admin.PasswordSalt = passwordSalt;
            }
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
            if (dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                currentAdmin.PasswordHash = passwordHash;
                currentAdmin.PasswordSalt = passwordSalt;
            }
            return (Admin)await UserRepository.Update(currentAdmin);
        }


        public async Task<AdminDto> GetAdminById(int Admin_id)
        {
            Admin admin = (Admin)await UserRepository.GetById(Admin_id);
            if(admin != null)
            {
                AdminDto admin_dto = UserMapper.ToAdminDto(admin);
                return admin_dto;
            }
            return null;
        }

        public async Task<IEnumerable<AdminDto>> GetAllAdmins()
        {
            return await UserRepository.GetAll().OfType<Admin>()
                .Select(u => UserMapper.ToAdminDto(u)).ToListAsync();
        }

        #endregion

        #region RECEPTIONIST CRUD
        public async Task<Domain.Models.Users.Receptionist> AddReceptionist(ReceptionistDto dto)
        {
            Domain.Models.Users.Receptionist receptionist = UserMapper.ToReceptionist(dto);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                receptionist.PasswordHash = passwordHash;
                receptionist.PasswordSalt = passwordSalt;
            }
            return (Domain.Models.Users.Receptionist)await UserRepository.Add(receptionist);
        }

        public async Task<Domain.Models.Users.Receptionist> DeleteReceptionist(int Receptionist_id)
        {
            return (Domain.Models.Users.Receptionist)await UserRepository.Delete(Receptionist_id);
        }

        public async Task<Domain.Models.Users.Receptionist> UpdateReceptionist(ReceptionistDto dto)
        {
            Domain.Models.Users.Receptionist currentReceptionist = (Domain.Models.Users.Receptionist)await UserRepository.GetById(dto.Id);
            currentReceptionist = UserMapper.UpdateReceptionist(dto, currentReceptionist);
            if (dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                currentReceptionist.PasswordHash = passwordHash;
                currentReceptionist.PasswordSalt = passwordSalt;
            }
            return (Domain.Models.Users.Receptionist)await UserRepository.Update(currentReceptionist);
        }


        public async Task<ReceptionistDto> GetReceptionistById(int Receptionist_id)
        {
            Domain.Models.Users.Receptionist receptionist = (Domain.Models.Users.Receptionist)await UserRepository.GetById(Receptionist_id);
            if(receptionist != null)
            {
                ReceptionistDto receptionist_dto = UserMapper.ToReceptionistDto(receptionist);
                return receptionist_dto;
            }
            return null;
        }

        public async Task<IEnumerable<ReceptionistDto>> GetAllReceptionists()
        {
            return await UserRepository.GetAll().OfType<Receptionist>().Select(u => UserMapper.ToReceptionistDto(u)).ToListAsync();
        }

       




        #endregion
    }
}
