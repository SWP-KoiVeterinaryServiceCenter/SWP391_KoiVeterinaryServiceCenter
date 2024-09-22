using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    internal interface IKoiRepository
    {
        // Thêm mới một Koi vào cơ sở dữ liệu
        Task<bool> AddAsync(Koi koi);

        // Cập nhật thông tin Koi trong cơ sở dữ liệu
        Task<bool> UpdateAsync(Koi koi);

        // Lấy tất cả các Koi từ cơ sở dữ liệu
        Task<IEnumerable<Koi>> GetAllAsync();
    }
}
