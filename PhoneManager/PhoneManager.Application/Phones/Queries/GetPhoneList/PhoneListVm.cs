using System.Collections.Generic;

namespace PhoneManager.Application.Phones.Queries.GetPhoneList
{
    public class PhoneListVm
    {
        public IList<PhoneLookUpDto> Phones { get; set; }
    }
}
