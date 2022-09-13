using FluentValidation;
using System;
using System.Linq;

namespace PhoneManager.Application.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommandValidator 
        : AbstractValidator<UpdatePhoneCommand>
    {
        public UpdatePhoneCommandValidator()
        {
            RuleFor(updatePhoneCommand =>
             updatePhoneCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updatePhoneCommand =>
              updatePhoneCommand.Name).NotEmpty().MaximumLength(70);
            RuleFor(updatePhoneCommand =>
                updatePhoneCommand.JobTitle).NotEmpty().MaximumLength(70);
            RuleFor(updatePhoneCommand =>
                updatePhoneCommand.BirthDate).NotNull();
            RuleFor(updatePhoneCommand =>
                updatePhoneCommand.MobilePhone).Must(IsPhoneValid).MaximumLength(13);
        }

        private bool IsPhoneValid(string phone)
        {
            return !(!phone.StartsWith("+375")
            || !phone.Substring(1).All(c => Char.IsDigit(c)));
        }
    }
}
