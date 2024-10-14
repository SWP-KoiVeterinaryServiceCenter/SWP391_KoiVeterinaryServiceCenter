using Application.Model.TravelExpenseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface ITravelExpenseService
    {
        Task<bool> CreateTravelExpense(CreateTravelExpenseModel createTravelExpenseModel);
        Task<bool> DeleteTravelExpense(Guid id);
        Task<List<ListTravelExpenseViewModel>> GetAllTravelExpenseAsync();
    }
}
