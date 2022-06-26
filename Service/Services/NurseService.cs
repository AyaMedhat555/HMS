using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.IRepositories;
using Repository.Repositories;
using Service.DTO.Users;
using Service.Helpers;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class NurseService : UserService, INurseService
    {
        private INurseRepository NurseRepository { get; }
        private IVitalSignsRepository VitalSignsRepository { get; }

        public NurseService(IUserRepository _UserRepository, INurseRepository _NurseRepository, IConfiguration _Configuration, IVitalSignsRepository _vitalSignsRepository)
            : base(_UserRepository, _Configuration)
        {
            NurseRepository = _NurseRepository;
            VitalSignsRepository = _vitalSignsRepository;
        }

        public async Task<Nurse> AddNurse(NurseDto dto)
        {
            Nurse nurse = UserMapper.ToNurse(dto);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                nurse.PasswordHash = passwordHash;
                nurse.PasswordSalt = passwordSalt;
            }
            return await NurseRepository.Add(nurse);
        }

        public async Task<Nurse> DeleteNurse(int Nurse_id)
        {
            return await NurseRepository.Delete(Nurse_id);
        }

        public async Task<IEnumerable<NurseDto>> GetAllNurses()
        {
            return await NurseRepository.GetAllNurses().Select(u => UserMapper.ToNurseDto(u)).ToListAsync();
        }

        public async Task<IEnumerable<NurseDto>> GetNursesByState(bool state)
        {
            return await NurseRepository.GetNursesByState(state).Select(u => UserMapper.ToNurseDto(u)).ToListAsync();
        }

        public async Task<IEnumerable<NurseDto>> GetNursesBySpecialization(string specialization)
        {
            return await NurseRepository.GetNursesBySpecialization(specialization).Select(u => UserMapper.ToNurseDto(u)).ToListAsync();
        }
    

        public async Task<Nurse> UpdateNurse(NurseDto dto)
        {
            Nurse currentNurse = await NurseRepository.GetById(dto.Id);
            currentNurse = UserMapper.UpdateNurse(dto, currentNurse);
            if(dto.Password != null)
            {
                CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                currentNurse.PasswordHash = passwordHash;
                currentNurse.PasswordSalt = passwordSalt;
            }
            return await NurseRepository.Update(currentNurse);
        }

        public async Task<NurseDto> GetNurseById(int Nurse_id)
        {
            Nurse nurse = await NurseRepository.GetNurseById(Nurse_id);
            if(nurse != null)
            {
                NurseDto nurse_dto = UserMapper.ToNurseDto(nurse);
                return nurse_dto;
            }
            return null;
        }

        public async Task<NurseDto> GetNurseByName(string Nursename)
        {
            Nurse nurse = await NurseRepository.FindByName(Nursename);
            if (nurse != null)
            {
                NurseDto nurse_dto = UserMapper.ToNurseDto(nurse);
                return nurse_dto;
            }
            return null;
        }


       
    }
}

