using Application.IService.Abstraction;
using Application.Model.KoiServiceModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class CenterServiceService : ICenterServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CenterServiceService(IUnitOfWork unitOfWork,IMapper mapper)
        {

            _unitOfWork=unitOfWork;
            _mapper = mapper;

        }
        public async Task<bool> CreateCenterServiceAysnc(CreateServiceModel createServiceModel)
        {
           var newCenterService=_mapper.Map<CenterService>(createServiceModel);
            await _unitOfWork.CenterServiceRepository.AddAsync(newCenterService);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<ListCenterServiceModel>> GetAllService()
        {
            var listCenterService=await _unitOfWork.CenterServiceRepository.GetAllAsync();
            var listCenterServiceModel=listCenterService.Select(x=>new ListCenterServiceModel
            {
                Id= x.Id,
                Name=x.ServiceName,
                Price=x.Price
            }).ToList();
            return listCenterServiceModel;
        }
    }
}
