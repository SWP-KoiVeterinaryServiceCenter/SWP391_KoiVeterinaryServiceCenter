using Application.Model.KoiModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    internal interface IKoiService
    {
        // Tạo mới một cá Koi
        Task<bool> CreateKoiAsync(CreateKoi model);

        // Cập nhật thông tin của cá Koi theo Id
        Task<bool> UpdateKoiAsync(UpdateKoi model);

        // Lấy danh sách tất cả các cá Koi
        Task<IEnumerable<Koi>> GetAllKoiAsync();

        
        
    }
}
