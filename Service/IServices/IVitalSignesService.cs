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
    public interface IVitalSignesService
    {
        Task<IEnumerable<VitalSign>> GetAllVitalSigns();
        Task<VitalSign> GetById(int id);
        Task<VitalSign> DeleteVitalSigns(int id);
        Task<VitalSign> AddVitalSignes(VitalSigneDto VitalSignesDto);
        Task<IEnumerable<VitalResponce>> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<VitalResponce>> GetVitalSignesByRangeOfDateOnly(int PatientId, DateTime StartDate, DateTime EndDate);
        Task<IEnumerable<VitalResponce>> GetVitalSignesBySpecificDate(int PatientId, DateTime Date);
    }
}
