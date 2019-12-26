using AutoMapper;
using Bizland.Domain.Entities;
using Bizland.Domain.Entities.Commands;
using Bizland.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bizland.Application.Services.CommandHandlers
{
    public class RoomCommandHandler : IRequestHandler<AddNewRoomCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<RoomCommandHandler> _logger;
        private readonly IMapper _mapper;

        public RoomCommandHandler(IMapper mapper, IUnitOfWork uow, ILogger<RoomCommandHandler> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(AddNewRoomCommand request, CancellationToken cancellationToken)
        {
            var response = false;
            var repo = _uow.RepositoryAsync<Room>();
            var room = _mapper.Map<Room>(request);
            var entity = await repo.AddAsync(room);
            if (entity != null)
            {
                _logger.LogInformation($"Created an room with id: {room.Id}");
                response = true;
            }
            else
            {
                _logger.LogWarning($"Add room: {room.Id} failed");

                response = false;
            }

            return response;
        }
    }
}
