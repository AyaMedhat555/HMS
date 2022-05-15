using Domain.Models;
using Repository.IRepositories;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Microsoft.Extensions.Configuration;

namespace Service.Services
{
    public class VitalSignsService : IVitalSignesService
    {
       

        private IVitalSignsRepository VitalSignsRepository { get; }

        

        public VitalSignsService(IVitalSignsRepository _VitalSignsRepository)
        {
            VitalSignsRepository = _VitalSignsRepository;
            

        }
        public async Task<VitalSign> AddVitalSignes(VitalSigneDto VitalSignesDto)

        {
            var vitalsigns = new VitalSign
            {
                Pressure = VitalSignesDto.Pressure,
                PulseRate = VitalSignesDto.PulseRate,
                Temperature = VitalSignesDto.Temperature,
                ECG = VitalSignesDto.ECG,
                RespirationRate = VitalSignesDto.RespirationRate,
                vitals_date = VitalSignesDto.vitals_date,
                NurseId =VitalSignesDto.NurseId,



            };
            return await VitalSignsRepository.Add(vitalsigns);
        }
        public string Pressure { get; set; }
        public int PulseRate { get; set; }
        public float Temperature { get; set; }
        public byte[]? ECG { get; set; }
        public float RespirationRate { get; set; }
        public DateTime vitals_date { get; set; }
        public Nurse Nurse { get; set; }
        public int NurseId { get; set; }

        public async Task<VitalSign> UpdateVitalSigns(VitalSign VitalSigns)
        {
            return await VitalSignsRepository.Update(VitalSigns);
        }

        public async Task<VitalSign> DeleteVitalSigns(int id)
        {
            return await VitalSignsRepository.Delete(id);
        }

        public async Task<IEnumerable<VitalSign>> GetAllVitalSigns()
        {
            return await VitalSignsRepository.GetAll().ToListAsync();
        }

        public async Task<VitalSign> GetById(int id)
        {
            return await VitalSignsRepository.GetById(id);
        }

      
    }
}
