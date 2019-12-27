using Bizland.Application.Service.Room.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Service.Room.Validations
{
    public class AddNewRoomCommandValidation : RoomValidation<AddNewRoomCommand>
    {
        public AddNewRoomCommandValidation()
        {
            ValidateName();
            ValidateAddress();
            ValidateId();
            ValidatePhone();
        }
    }
}
