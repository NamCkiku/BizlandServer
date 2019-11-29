﻿using AutoMapper;
using Bizland.Application.Services.Interfaces;
using Bizland.Application.Services.ViewModels;
using Bizland.Domain.Entities.Entities;
using Bizland.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizland.Application.Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IDapperUnitOfWork _unitOfWork;

        public RoomService(IMapper mapper, IDapperUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var roomRepository = _unitOfWork.QueryRepository<Room, Guid>();

            var lstRoom = roomRepository.Queryable().ToList();

            return _mapper.Map<List<Room>, List<RoomViewModel>>(lstRoom);
        }

        public IList<RoomViewModel> GetAllHistory(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<RoomViewModel> GetByIdAsyn(Guid id)
        {
            var roomRepository = _unitOfWork.QueryRepository<Room, Guid>();

            var lstRoom = await roomRepository.GetByIdAsync(id);

            return _mapper.Map<Room, RoomViewModel>(lstRoom);
        }

        public async Task<RoomViewModel> InsertRoomAsyn(RoomViewModel customerViewModel)
        {
            var roomRepository = _unitOfWork.RepositoryAsync<Room, Guid>();

            var room = new Room();
            var created = await roomRepository.AddAsync(room);

            return _mapper.Map<Room, RoomViewModel>(created);

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