using Application.Model.KoiModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IKoiService
    {
        Task<bool> AddKoiAsync(AddKoiRequest addKoiRequest);
        Task<IEnumerable<KoiResponse>> GetAllKoiAsync();
        Task<KoiResponse> GetKoiByIdAsync(Guid id);
        Task<IEnumerable<KoiResponse>> GetAllKoiByAccountIdAsync(Guid accountId);
        Task<bool> UpdateKoiAsync(Guid id, UpdateKoiRequest koiRequest);
        Task<bool> DeleteKoiAsync(Guid id, Guid deletedBy);

    }
}
