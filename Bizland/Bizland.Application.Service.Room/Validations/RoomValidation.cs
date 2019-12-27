using Bizland.Application.Service.Room.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Service.Room.Validations
{
    public abstract class RoomValidation<T> : AbstractValidator<T> where T : RoomCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.RoomName)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidatePhone()
        {
            RuleFor(c => c.Phone)
                 .NotEmpty().WithMessage("Please ensure you have entered the PhoneNumber")
                .Length(2, 15).WithMessage("The Name must have between 2 and 15 characters");
        }

        protected void ValidateAddress()
        {
            RuleFor(c => c.Address)
               .NotEmpty().WithMessage("Please ensure you have entered the Address")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        //protected static bool HaveMinimumAge(DateTime birthDate)
        //{
        //    return birthDate <= DateTime.Now.AddYears(-18);
        //}
    }
}
