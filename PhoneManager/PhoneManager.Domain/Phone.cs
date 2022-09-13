using System;

namespace PhoneManager.Domain
{
    public class Phone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
