using Domain.Models.Pharmacy;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.IRepositories.Pharmacy;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Pharmacy
{
    public class MedicineRepository : GenericRepository<Medicine>, IMedicineRepository
    {
        private IUnitOfWork _unitOfWork;

        public MedicineRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public IQueryable<Medicine> GetAllMedicnes()
        {
            return _unitOfWork.Context.Medicines.Include(M => M.StockMedicines);
        }

        public async Task<Medicine> GetByCommercialName(string commercialName)
        {
            return await _unitOfWork.Context.Medicines.Include(M => M.StockMedicines.Where(S => S.Quantity > 0).OrderBy(s => s.ExpireDtm))
                .FirstOrDefaultAsync(M => M.CommercialName == commercialName && M.StockMedicines.Count > 0);
        }

        public IQueryable<Medicine> GetBySubstance(string substance)
        {
            return _unitOfWork.Context.Medicines.Where(M => M.EffectiveSubstance == substance && M.StockMedicines.Count > 0)
                .Include(M => M.StockMedicines.Where(S => S.Quantity > 0).OrderBy(s => s.ExpireDtm));
        }

        public async Task<Medicine> GetMedicineById(int id)
        {
            return await _unitOfWork.Context.Medicines.Include(M => M.StockMedicines.Where(S => S.Quantity > 0)
            .OrderBy(s => s.ExpireDtm)).FirstOrDefaultAsync(M => M.MedicineId == id);
        }

        public IQueryable<Medicine> GetMedicinesByGroup(string groupName)
        {
            return _unitOfWork.Context.Medicines.Where(M => M.Group == groupName && M.StockMedicines.Count > 0)
                .Include(M => M.StockMedicines.Where(S => S.Quantity > 0).OrderBy(s => s.ExpireDtm));
        }

        public IQueryable<Medicine> GetByNames(HashSet<string> names)
        {
            return _unitOfWork.Context.Medicines.Where(m => names.Any(l => m.CommercialName == l) && m.StockMedicines.Count > 0)
                .Include(M => M.StockMedicines.Where(S => S.Quantity > 0).OrderBy(s => s.ExpireDtm));
        }

    }
}
