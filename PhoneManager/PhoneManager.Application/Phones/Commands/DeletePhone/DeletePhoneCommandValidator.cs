using FluentValidation;
using System;


namespace PhoneManager.Application.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommandValidator 
        : AbstractValidator<DeletePhoneCommand>
    {
        public DeletePhoneCommandValidator()
        {
            RuleFor(deletePhoneCommand =>
              deletePhoneCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
