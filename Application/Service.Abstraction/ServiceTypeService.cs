using Application.IService.Abstraction;
using Application.Model.ServiceTypeModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServiceTypeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateServiceTypeAsync(CreateServiceTypeModel model)
        {
            var newServiceType=_mapper.Map<ServiceType>(model);
            await _unitOfWork.ServiceTypeRepository.AddAsync(newServiceType);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteServiceType(Guid typeId)
        {
            var serviceType=await _unitOfWork.ServiceTypeRepository.GetByIdAsync(typeId);
            if(serviceType == null)
            {
                throw new Exception("Service type not found");
            }
            _unitOfWork.ServiceTypeRepository.SoftRemove(serviceType);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<ServiceTypeListViewModel>> GetAllServiceTypeAsync()
        {
            var serviceTypeList = await _unitOfWork.ServiceTypeRepository.GetAllAsync();
            var serviceTypeListModel = serviceTypeList.Select(x => new ServiceTypeListViewModel
            {
                TypeId=x.Id,
                TypeName=x.TypeName
            }).ToList();
            return serviceTypeListModel;
        }
    }
}
