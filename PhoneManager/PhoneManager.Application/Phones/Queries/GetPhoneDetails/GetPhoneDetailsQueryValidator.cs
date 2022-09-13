using FluentValidation;
using System;

namespace PhoneManager.Application.Phones.Queries.GetPhoneDetails
{
    public class GetPhoneDetailsQueryValidator
        : AbstractValidator<GetPhoneDetailsQuery>
    {
        public GetPhoneDetailsQueryValidator()
        {
            RuleFor(getPhoneDetailsQuery => 
                getPhoneDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
