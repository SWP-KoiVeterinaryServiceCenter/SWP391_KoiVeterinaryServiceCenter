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
    }
}
