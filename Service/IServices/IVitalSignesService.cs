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
        Task<IEnumerable<VitalSign>> GetAllVitalSigns();
        Task<VitalSign> GetById(int id);
        Task<VitalSign> DeleteVitalSigns(int id);
        Task<VitalSign> UpdateVitalSigns(VitalSign VitalSign);
    }
}
