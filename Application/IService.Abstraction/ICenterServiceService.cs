using Application.Model.KoiServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface ICenterServiceService
    {
        Task<bool> CreateCenterServiceAysnc(CreateServiceModel createServiceModel);
        Task<List<ListCenterServiceModel>> GetAllService();

    }
}
