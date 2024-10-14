using Application.Model.AccountModel;
using Application.Model.AppointmentModel;
using Application.Model.KoiModel;
using Application.Model.KoiServiceModel;
using Application.Model.ServiceTypeModel;
using Application.Model.TankModel;
using Application.Model.TravelExpenseModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class MapperProfileConfig : Profile
    {
        public MapperProfileConfig()
        {
            CreateAccountMap();
            CreateServiceTypeMap();
            CreateCenterServiceMap();
            CreateCenterTankMap();
            CreateAppointmentMap();
            CreateTravelExpenseMap();
        }
        internal void CreateAccountMap()
        {
            CreateMap<RegisterModel, Account>().ReverseMap();
        }
        internal void CreateServiceTypeMap()
        {
            CreateMap<CreateServiceTypeModel, ServiceType>()
                .ForMember(scr => scr.TypeName, dest => dest.MapFrom(model => model.TypeName))
                .ForMember(scr=>scr.TravelExpenseId,dest=>dest.MapFrom(model=>model.TravelExpenseId)).ReverseMap();
        }
        internal void CreateCenterServiceMap()
        {
            CreateMap<CreateServiceModel, CenterService>()
                .ForMember(src => src.ServiceName, dest => dest.MapFrom(model => model.Name))
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
                .ForMember(scr => scr.Description, dest => dest.MapFrom(model => model.Description))
                .ForMember(scr => scr.KoiId, dest => dest.MapFrom(model => model.KoiId))
                .ForMember(scr => scr.ServiceId, dest => dest.MapFrom(model => model.CenterServiceId))
                .ForMember(scr => scr.VeterinarianId, dest => dest.MapFrom(model => model.VeterinarianId))
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => DateOnly.Parse(src.AppointmentDate)))
                .ForMember(dest => dest.AppointmentTime, opt => opt.MapFrom(src => TimeSpan.FromHours(src.AppointmentTime)));
           CreateMap<UpdateAppointmentModel, Appointment>()
             .ForMember(scr => scr.Description, dest => dest.MapFrom(model => model.Description))
             .ForMember(scr => scr.KoiId, dest => dest.MapFrom(model => model.KoiId))
             .ForMember(scr => scr.ServiceId, dest => dest.MapFrom(model => model.CenterServiceId))
             .ForMember(scr => scr.VeterinarianId, dest => dest.MapFrom(model => model.VeterinarianId))
             .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => DateOnly.Parse(src.AppointmentDate)))
             .ForMember(dest => dest.AppointmentTime, opt => opt.MapFrom(src => TimeSpan.FromHours(src.AppointmentTime)))
             .ReverseMap();
        }
        internal void CreateTravelExpenseMap()
        {
            CreateMap<CreateTravelExpenseModel, TravelExpense>().ReverseMap();
        }
    }
}

