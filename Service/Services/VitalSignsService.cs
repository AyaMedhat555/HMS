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
        public async Task<VitalSigns> AddVitalSignes(VitalSignesDto VitalSignesDto)

        {
            var vitalsigns = new VitalSigns
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

        public async Task<VitalSigns> UpdateVitalSigns(VitalSigns VitalSigns)
        {
            return await VitalSignsRepository.Update(VitalSigns);
        }

        public async Task<VitalSigns> DeleteVitalSigns(int id)
        {
            return await VitalSignsRepository.Delete(id);
        }

        public async Task<IEnumerable<VitalSigns>> GetAllVitalSigns()
        {
            return await VitalSignsRepository.GetAll().ToListAsync();
        }

        public async Task<VitalSigns> GetById(int id)
        {
            return await VitalSignsRepository.GetById(id);
        }

      
    }
}
