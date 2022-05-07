using Domain.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IVitalSignesService
    {
        Task<IEnumerable<VitalSigns>> GetAllVitalSigns();

        Task<VitalSigns> AddVitalSignes(VitalSignesDto VitalSignesDto);

        Task<VitalSigns> GetById(int id);

        Task<VitalSigns> DeleteVitalSigns(int id);
        Task<VitalSigns> UpdateVitalSigns(VitalSigns VitalSigns);
    }
}
