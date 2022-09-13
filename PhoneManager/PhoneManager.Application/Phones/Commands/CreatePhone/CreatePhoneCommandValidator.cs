using FluentValidation;
using System;
using System.Linq;

namespace PhoneManager.Application.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommandValidator
        : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(createPhoneCommand =>
               createPhoneCommand.Name).NotEmpty().MaximumLength(70);
            RuleFor(createPhoneCommand =>
                createPhoneCommand.JobTitle).NotEmpty().MaximumLength(70);
            RuleFor(createPhoneCommand =>
                createPhoneCommand.BirthDate).NotNull();
            RuleFor(createPhoneCommand =>
                createPhoneCommand.MobilePhone).Must(IsPhoneValid).MaximumLength(13);
        }

        private bool IsPhoneValid(string phone)
        {
            return !(!phone.StartsWith("+375")
            || !phone.Substring(1).All(c => Char.IsDigit(c)));
        }
    }
}
