using Application.IService.Abstraction;
using Application.Model.TankModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class CenterTankService : ICenterTankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CenterTankService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateTankAsync(CreateTankModel model)
        {
            var newTank=_mapper.Map<CenterTank>(model);
            await _unitOfWork.CenterTankRepository.AddAsync(newTank);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<ListTankViewModel>> GetAllTanksAsync()
        {
            var listTank = await _unitOfWork.CenterTankRepository.GetAllAsync();
            var listTankModel = listTank.Select(x => new ListTankViewModel
            {
                TankCapacity = x.Capacity,
                TankId = x.Id,
                TankName=x.TankName,
                TankStatus=x.Status
            }).ToList();
            return listTankModel;   
        }
    }
}
