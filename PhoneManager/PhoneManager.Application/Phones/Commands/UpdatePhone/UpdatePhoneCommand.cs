using MediatR;
using System;

namespace PhoneManager.Application.Phones.Commands.UpdatePhone
{
    public class UpdatePhoneCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
