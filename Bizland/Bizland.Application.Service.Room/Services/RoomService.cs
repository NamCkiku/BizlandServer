using AutoMapper;
using Bizland.Application.Service.Room.Commands;
using Bizland.Application.Service.Room.Interfaces;
using Bizland.Application.Service.Room.ViewModels;
using Bizland.Domain.Entities;
using Bizland.Infrastructure.Dapper;
using Bizland.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Application.Service.Room.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public RoomService(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var roomRepository = _unitOfWork.QueryRepository<Bizland.Domain.Entities.Room>();

            var lstRoom = roomRepository.Queryable().ToList();

            return _mapper.Map<List<Bizland.Domain.Entities.Room>, List<RoomViewModel>>(lstRoom);
        }

        public IList<RoomViewModel> GetAllHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoomViewModel> GetByIdAsyn(Guid id)
        {
            var roomRepository = _unitOfWork.QueryRepository<Bizland.Domain.Entities.Room>();

            var lstRoom = roomRepository.Queryable().Where(x => x.Id == id).FirstOrDefault();

            return await Task.FromResult(_mapper.Map<Bizland.Domain.Entities.Room, RoomViewModel>(lstRoom));
        }

        public async Task<bool> InsertRoomAsyn(RoomViewModel roomViewModel)
        {
            var registerCommand = _mapper.Map<AddNewRoomCommand>(roomViewModel);

            return await _mediator.Send(registerCommand);

        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
