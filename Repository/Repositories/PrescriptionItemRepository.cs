using Domain.Models;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PrescriptionItemRepository : GenericRepository<PrescriptionItem>, IPrescriptionItemRepository
    {
        private IUnitOfWork _unitOfWork;
        public PrescriptionItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
