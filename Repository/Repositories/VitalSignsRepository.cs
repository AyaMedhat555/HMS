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
    public class VitalSignsRepository : GenericRepository<VitalSigns>, IVitalSignsRepository
    {
        private IUnitOfWork _unitOfWork;
        public VitalSignsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;



        }

    }
}