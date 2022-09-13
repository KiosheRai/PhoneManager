using MediatR;
using System;

namespace PhoneManager.Application.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
