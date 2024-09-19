using Application.Model.AccountModel;
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
        }
        internal void CreateAccountMap()
        {
            CreateMap<RegisterModel, Account>().ReverseMap();
        }
    }
}
