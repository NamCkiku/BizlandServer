﻿using Bizland.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Services.Room.EventHandlers
{
    public class RoomAddEvent : EventBus
    {
        public RoomAddEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
