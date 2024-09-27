using Application.Model.AccountModel;
using Application.Model.AppointmentModel;
using Application.Model.KoiModel;
using Application.Model.KoiServiceModel;
using Application.Model.ServiceTypeModel;
using Application.Model.TankModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class MapperProfileConfig:Profile
    {
        public MapperProfileConfig()
        {
            CreateAccountMap();
            CreateServiceTypeMap();
            CreateCenterServiceMap();
            CreateCenterTankMap();
            CreateAppointmentMap();
        }
        internal void CreateAccountMap()
        {
            CreateMap<RegisterModel, Account>().ReverseMap();
        }
        internal void CreateServiceTypeMap()
        {
            CreateMap<CreateServiceTypeModel, ServiceType>()
                .ForMember(scr => scr.TypeName, dest => dest.MapFrom(model => model.TypeName)).ReverseMap();
        }
        internal void CreateCenterServiceMap()
        {
            CreateMap<CreateServiceModel, CenterService>()
                .ForMember(src=>src.ServiceName,dest=>dest.MapFrom(model=>model.Name))
                .ForMember(scr => scr.TankId, dest => dest.MapFrom(model => model.TankId))
                .ForMember(scr => scr.TypeId, dest => dest.MapFrom(model => model.TypeId)).ReverseMap();
        }
        internal void CreateCenterTankMap()
        {
            CreateMap<CreateTankModel, CenterTank>()
                .ReverseMap();
        }
        internal void CreateAppointmentMap()
        {
            CreateMap<CreateAppointmentModel, Appointment>()
                .ForMember(scr => scr.KoiId, dest => dest.MapFrom(model => model.KoiId))
                .ForMember(scr => scr.ServiceId, dest => dest.MapFrom(model => model.ServiceId))
                .ForMember(scr=>scr.VeterinarianId,dest=>dest.MapFrom(model=>model.VeterinarianId)).ReverseMap();
        }
    }
}

