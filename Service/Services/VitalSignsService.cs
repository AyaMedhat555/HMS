using Domain.Models;
using Repository.IRepositories;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Microsoft.Extensions.Configuration;
using Service.Responses;

namespace Service.Services
{
    public class VitalSignsService : IVitalSignesService
    {
        private IVitalSignsRepository VitalSignsRepository { get; }

        public VitalSignsService(IVitalSignsRepository _VitalSignsRepository)
        {
            VitalSignsRepository = _VitalSignsRepository;
            
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

        public async Task<VitalSign> AddVitalSignes(VitalSigneDto VitalSigneDto)

        {
            var vitalsign = new VitalSign
            {
                Pressure = VitalSigneDto.Pressure,
                PulseRate = VitalSigneDto.PulseRate,
                Temperature = VitalSigneDto.Temperature,
                ECG = VitalSigneDto.ECG,
                RespirationRate = VitalSigneDto.RespirationRate,
                vitals_date = VitalSigneDto.vitals_date,
                NurseId = VitalSigneDto.NurseId,
                Patientid = VitalSigneDto.PatientId,

                Note = new Note
                {
                    Body = VitalSigneDto.NoteDto.Body,
                    NurseId = VitalSigneDto.NoteDto.NurseId,
                    CreatedDate = VitalSigneDto.NoteDto.CreatedDate,
                    Subject = VitalSigneDto.NoteDto.Subject,
                    IndoorPatientRecordId = VitalSigneDto.NoteDto.IndoorPatientRecordId


                }

            };
            return await VitalSignsRepository.Add(vitalsign);
        }

        public async Task<IEnumerable<VitalResponce>> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            return await VitalSignsRepository.GetVitalSignesByRangeOfDate(PatientId, StartDate, EndDate)
                .Select(r => new VitalResponce()
                {
                    NurseName = r.Nurse.FirstName,
                    PatientName = r.Patient.FirstName,
                    Pressure = r.Pressure,
                    VitalsignId = r.Id,
                    PulseRate = r.PulseRate,
                    Temperature = r.Temperature,
                    ECG = r.ECG,
                    RespirationRate = r.RespirationRate,
                    vitals_date = r.vitals_date,
                    NoteDto = new NoteDto()
                    {
                        Body = r.Note.Body,
                        NurseId = r.Note.NurseId,
                        CreatedDate = r.Note.CreatedDate,
                        Subject = r.Note.Subject,
                        IndoorPatientRecordId = r.Note.IndoorPatientRecordId


                    }

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<VitalResponce>> GetVitalSignesByRangeOfDateOnly(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            return await VitalSignsRepository.GetVitalSignesByRangeOfDateOnly(PatientId, StartDate, EndDate)
                .Select(r => new VitalResponce()
                {
                    NurseName = r.Nurse.FirstName,
                    PatientName = r.Patient.FirstName,
                    Pressure = r.Pressure,
                    VitalsignId = r.Id,
                    PulseRate = r.PulseRate,
                    Temperature = r.Temperature,
                    ECG = r.ECG,
                    RespirationRate = r.RespirationRate,
                    vitals_date = r.vitals_date,
                    NoteDto = new NoteDto()
                    {
                        Body = r.Note.Body,
                        NurseId = r.Note.NurseId,
                        CreatedDate = r.Note.CreatedDate,
                        Subject = r.Note.Subject,
                        IndoorPatientRecordId = r.Note.IndoorPatientRecordId


                    }

                })
                .ToListAsync();
        }

        public async Task<IEnumerable<VitalResponce>> GetVitalSignesBySpecificDate(int PatientId, DateTime Date)
        {
            return await VitalSignsRepository.GetVitalSignesBySpecificDate(PatientId, Date)
                .Select(r => new VitalResponce()
                {
                    NurseName = r.Nurse.FirstName,
                    PatientName = r.Patient.FirstName,
                    Pressure = r.Pressure,
                    VitalsignId = r.Id,
                    PulseRate = r.PulseRate,
                    Temperature = r.Temperature,
                    ECG = r.ECG,
                    RespirationRate = r.RespirationRate,
                    vitals_date = r.vitals_date,
                    NoteDto = new NoteDto()
                    {
                        Body = r.Note.Body,
                        NurseId = r.Note.NurseId,
                        CreatedDate = r.Note.CreatedDate,
                        Subject = r.Note.Subject,
                        IndoorPatientRecordId = r.Note.IndoorPatientRecordId


                    }

                })
                .ToListAsync();
        }
    }
}
