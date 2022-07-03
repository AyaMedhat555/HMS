using Domain.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories.Pharmacy
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        IQueryable<Medicine> GetAllMedicnes();
        Task<Medicine> GetMedicineById(int id);
        Task<Medicine> GetByCommercialName(string commercialName);
        IQueryable<Medicine> GetBySubstance(string substance);
        IQueryable<Medicine> GetMedicinesByGroup(string groupName);
        IQueryable<Medicine> GetByNames(HashSet<string> names);

    }

}
