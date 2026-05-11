using AutoMapper;
using SMSsenderAPI.Dto;
using SMSsenderAPI.Models;
using System;

namespace SMSsenderAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SmsDto, Sms>();
            CreateMap<SmsWithoutTemplateDto, Sms>();
            CreateMap<SmsFilterDto, Sms>()

                //.ForMember(des => des.ContainerPlacementFeePerDay, opt=> opt.MapFrom(src=> src.test))

                .ReverseMap();
        }
    }
}
