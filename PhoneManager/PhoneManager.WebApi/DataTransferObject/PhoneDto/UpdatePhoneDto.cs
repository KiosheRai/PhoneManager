using AutoMapper;
using PhoneManager.Application.Common.Mappings;
using PhoneManager.Application.Phones.Commands.UpdatePhone;
using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneManager.WebApi.DataTransferObject.PhoneDto
{
    public class UpdatePhoneDto : IMapWith<UpdatePhoneCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MobilePhone { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePhoneDto, UpdatePhoneCommand>()
                .ForMember(phoneCommand => phoneCommand.Name,
                    opt => opt.MapFrom(phoneDto => phoneDto.Name))
                .ForMember(phoneCommand => phoneCommand.Name,
                    opt => opt.MapFrom(phoneDto => phoneDto.Name))
                .ForMember(phoneCommand => phoneCommand.MobilePhone,
                    opt => opt.MapFrom(phoneDto => phoneDto.MobilePhone))
                .ForMember(phoneCommand => phoneCommand.JobTitle,
                    opt => opt.MapFrom(phoneDto => phoneDto.JobTitle))
                .ForMember(phoneCommand => phoneCommand.BirthDate,
                    opt => opt.MapFrom(phoneDto => phoneDto.BirthDate));
        }
    }
}
