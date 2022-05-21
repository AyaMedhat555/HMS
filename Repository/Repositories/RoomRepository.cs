using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public  class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private IUnitOfWork _unitOfWork;
        public RoomRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<Room> GetFreeRooms()
        {
             return _unitOfWork.Context.Rooms.Where(R=>R.Reserved== false).Include(R =>R.Beds);
        }
    }
}
