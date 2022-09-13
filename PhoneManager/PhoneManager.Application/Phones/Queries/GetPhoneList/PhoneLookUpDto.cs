using AutoMapper;
using PhoneManager.Application.Common.Mappings;
using PhoneManager.Domain;
using System;

namespace PhoneManager.Application.Phones.Queries.GetPhoneList
{
    public class PhoneLookUpDto : IMapWith<Phone>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Phone, PhoneLookUpDto>()
                 .ForMember(phoneVm => phoneVm.Id,
                    opt => opt.MapFrom(phone => phone.Id))
                .ForMember(phoneVm => phoneVm.Name,
                    opt => opt.MapFrom(phone => phone.Name))
                .ForMember(phoneVm => phoneVm.MobilePhone,
                    opt => opt.MapFrom(phone => phone.MobilePhone))
                .ForMember(phoneVm => phoneVm.JobTitle,
                    opt => opt.MapFrom(phone => phone.JobTitle))
                .ForMember(phoneVm => phoneVm.BirthDate,
                    opt => opt.MapFrom(phone => phone.BirthDate));
        }
    }
}
