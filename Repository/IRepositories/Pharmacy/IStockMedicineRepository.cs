using Domain.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories.Pharmacy
{
    public interface IStockMedicineRepository : IGenericRepository<StockMedicine>
    {
        IQueryable<StockMedicine> GetScarceMedicine(int stockId, int quantity);
        IQueryable<StockMedicine> GetByIds(HashSet<int> ids);

    }
}
