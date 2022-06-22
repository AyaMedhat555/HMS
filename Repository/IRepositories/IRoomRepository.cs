using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        IQueryable<Room> GetFreeRooms();

    }
}
