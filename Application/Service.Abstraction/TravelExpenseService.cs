using Application.IService.Abstraction;
using Application.Model.TravelExpenseModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class TravelExpenseService : ITravelExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TravelExpenseService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateTravelExpense(CreateTravelExpenseModel createTravelExpenseModel)
        {
            var newTravelExpense = _mapper.Map<TravelExpense>(createTravelExpenseModel);
            await _unitOfWork.TravelExpenseRepository.AddAsync(newTravelExpense);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> DeleteTravelExpense(Guid id)
        {
            var foundTravelExpense =await _unitOfWork.TravelExpenseRepository.GetByIdAsync(id);
            if (foundTravelExpense == null)
            {
                throw new Exception("Travel expense not found");
            }
            _unitOfWork.TravelExpenseRepository.SoftRemove(foundTravelExpense);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<List<ListTravelExpenseViewModel>> GetAllTravelExpenseAsync()
        {
            var listTravelExpense = await _unitOfWork.TravelExpenseRepository.GetAllAsync();
            var listTravelExpenseViewModel = listTravelExpense.Select(x => new ListTravelExpenseViewModel
            {
                Id= x.Id,   
                BaseRate= x.BaseRate,
                MaximumTravelRate= x.MaximumTravelRate,
                MinimumTravelRate=x.MaximumTravelRate
            }).ToList();
            return listTravelExpenseViewModel;
        }
    }
}
