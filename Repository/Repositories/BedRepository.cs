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
    public class BedRepository : GenericRepository<Bed>, IBedRepository
    {
        private IUnitOfWork _unitOfWork;
        public BedRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Bed> GetFreeBedsByRoomId(int RoomId)
        {
            return _unitOfWork.Context.Beds.Where(B=>(B.Reserved==false)&&(B.RoomId== RoomId));
        }
    }
}
