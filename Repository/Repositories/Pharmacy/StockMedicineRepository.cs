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
    public class StockMedicineRepository : GenericRepository<StockMedicine>, IStockMedicineRepository
    {
        private IUnitOfWork _unitOfWork;

        public StockMedicineRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public IQueryable<StockMedicine> GetByIds(HashSet<int> ids)
        {
            return _unitOfWork.Context.StockMedicines.Where(m => ids.Any(i => m.Id == i));
        }

        public IQueryable<StockMedicine> GetScarceMedicine(int stockId, int quantity)
        {
            return _unitOfWork.Context.StockMedicines.Where(
                S => S.StockId == stockId && S.Quantity < quantity).Include(S => S.Medicine);
        }
    }
}
