using System;
using Application.Model.KoiModel;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Mappers
{
    public class MapperProfileKoi : Profile
    {
        public MapperProfileKoi()
        {
            CreateKoiMap();  // Ánh xạ cho CreateKoiModel
            UpdateKoiMap();  // Ánh xạ cho UpdateKoiModel
        }

        internal void CreateKoiMap()
        {
            // Tạo ánh xạ giữa CreateKoiModel và Koi
            CreateMap<CreateKoi, Koi>()
                .ForMember(dest => dest.KoiName, opt => opt.MapFrom(src => src.KoiName))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Varieties, opt => opt.MapFrom(src => src.Varieties))                
                .ForMember(dest => dest.IsDelete, opt => opt.MapFrom(src => false)) // Giá trị mặc định là chưa bị xóa
                .ReverseMap(); // Cho phép ánh xạ ngược
        }

        internal void UpdateKoiMap()
        {
            // Tạo ánh xạ giữa UpdateKoiModel và Koi
            CreateMap<UpdateKoi, Koi>()
                .ForMember(dest => dest.KoiName, opt => opt.MapFrom(src => src.KoiName))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Varieties, opt => opt.MapFrom(src => src.Varieties))
                .ReverseMap(); // Cho phép ánh xạ ngược
        }
    }
}