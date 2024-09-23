using Application.Model.TankModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface ICenterTankService
    {
        Task<bool> CreateTankAsync(CreateTankModel model);
        Task<List<ListTankViewModel>> GetAllTanksAsync();
    }
}
