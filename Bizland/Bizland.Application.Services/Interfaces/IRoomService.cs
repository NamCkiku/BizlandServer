using Bizland.Application.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Application.Services.Interfaces
{
    public interface IRoomService : IDisposable
    {
        Task<RoomViewModel> InsertRoomAsyn(RoomViewModel customerViewModel);
        IEnumerable<RoomViewModel> GetAll();
        Task<RoomViewModel> GetByIdAsyn(Guid id);
        void Update(RoomViewModel customerViewModel);
        void Remove(Guid id);
        IList<RoomViewModel> GetAllHistory(Guid id);
    }
}
