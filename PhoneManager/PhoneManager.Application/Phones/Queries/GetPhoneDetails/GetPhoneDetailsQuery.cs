using MediatR;
using System;

namespace PhoneManager.Application.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQuery : IRequest<PhoneDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
