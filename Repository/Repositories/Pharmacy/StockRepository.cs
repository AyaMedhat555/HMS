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
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private IUnitOfWork _unitOfWork;

        public StockRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public Task<Stock> FindByLocation(string location)
        {
            return _unitOfWork.Context.Stocks.Where(S => S.StockLocation == location).Include(S => S.StockMedicines).FirstOrDefaultAsync();
        }

        public Task<Stock> GetStockById(int id)
        {
            return _unitOfWork.Context.Stocks.Where(S => S.StockId == id).Include(S => S.StockMedicines).FirstOrDefaultAsync();
        }

        public IQueryable<Stock> GetAllStocks()
        {
            return _unitOfWork.Context.Stocks.Include(s => s.StockMedicines);
        }
    }
}
