using Application.Model.ServiceTypeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IServiceTypeService
    {
        Task<bool> CreateServiceTypeAsync(CreateServiceTypeModel model);
        Task<List<ServiceTypeListViewModel>> GetAllServiceTypeAsync();
        Task<bool> DeleteServiceType(Guid typeId);
    }
}
