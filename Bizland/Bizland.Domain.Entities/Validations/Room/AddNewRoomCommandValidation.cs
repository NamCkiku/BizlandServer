using Bizland.Domain.Entities.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Entities.Validations
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
