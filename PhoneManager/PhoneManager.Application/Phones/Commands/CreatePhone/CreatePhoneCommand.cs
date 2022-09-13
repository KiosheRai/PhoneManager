using MediatR;
using System;

namespace PhoneManager.Application.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
