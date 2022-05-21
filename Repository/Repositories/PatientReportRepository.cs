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
    public class PatientReportRepository : GenericRepository<PatientReport>, IPatientReportRepository
    {
        private IUnitOfWork _unitOfWork;
        public PatientReportRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
