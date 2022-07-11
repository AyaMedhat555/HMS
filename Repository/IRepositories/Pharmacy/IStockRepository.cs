using Domain.Models.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories.Pharmacy
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        IQueryable<Stock> GetAllStocks();
        Task<Stock> FindByLocation(string location);
        Task<Stock> GetStockById(int id);
    }
}
