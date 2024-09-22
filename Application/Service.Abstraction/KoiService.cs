using Application.IService.Abstraction;
using Application.Model.KoiModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Service.Abstraction
{
    public class KoiService : IKoiService
    {
        private readonly IMapper _mapper;
        private readonly IKoiRepository _koiRepository; 

        public KoiService(IMapper mapper, IKoiRepository koiRepository)
        {
            _mapper = mapper;
            _koiRepository = koiRepository;
        }

        // Tạo mới một cá Koi
        public async Task<bool> CreateKoiAsync(CreateKoi model)
        {
            // Ánh xạ CreateKoiModel sang thực thể Koi
            var koiEntity = _mapper.Map<Koi>(model);
            koiEntity.CreationDate = DateTime.UtcNow; // Gán ngày tạo
            koiEntity.IsDelete = false; // Mặc định chưa bị xóa

            // Gọi repository để lưu Koi vào database
            bool isCreated = await _koiRepository.AddAsync(koiEntity);
            return isCreated;
        }

        // Cập nhật thông tin cá Koi theo Id
        public async Task<bool> UpdateKoiAsync(Guid id, UpdateKoi model)
        {
            // Lấy cá Koi từ database theo Id
            var existingKoi = await _koiRepository.GetByIdAsync(id);
            if (existingKoi == null)
            {
                return false; // Trả về false nếu không tìm thấy cá Koi
            }

            // Ánh xạ thông tin từ UpdateKoiModel sang thực thể Koi đã có
            _mapper.Map(model, existingKoi);
            existingKoi.ModificationDate = DateTime.UtcNow; // Gán ngày cập nhật

            // Gọi repository để cập nhật Koi trong database
            bool isUpdated = await _koiRepository.UpdateAsync(existingKoi);
            return isUpdated;
        }

        // Lấy danh sách tất cả các cá Koi
        public async Task<IEnumerable<Koi>> GetAllKoiAsync()
        {
            // Gọi repository để lấy danh sách cá Koi từ database
            var koiList = await _koiRepository.GetAllAsync();
            return koiList;
        }

       
        
    }

}
