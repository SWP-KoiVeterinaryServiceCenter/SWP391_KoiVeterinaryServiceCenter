using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.KoiServiceModel;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class CenterServiceService : ICenterServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUploadImageService _uploadImageService;
        public CenterServiceService(IUnitOfWork unitOfWork,IMapper mapper,IUploadImageService uploadImageService)
        {

            _unitOfWork=unitOfWork;
            _mapper = mapper;
            _uploadImageService=uploadImageService;

        }
        public async Task<bool> CreateCenterServiceAysnc(CreateServiceModel createServiceModel)
        {
           var newCenterService=_mapper.Map<CenterService>(createServiceModel);
            var image = await _uploadImageService.UploadFileToFireBase(createServiceModel.serviceImage, "CenterService");
            newCenterService.CenterServiceImage = image;
            if (createServiceModel.Duration > 60)
            {
                int minute=createServiceModel.Duration%60;
                int hour=createServiceModel.Duration/60;
                TimeSpan timeSpan=new TimeSpan(hour,minute,0);
                newCenterService.Duration = timeSpan;
            }
            TimeSpan timeSpan1=new TimeSpan(0,createServiceModel.Duration,0);
            newCenterService.Duration = timeSpan1;
            await _unitOfWork.CenterServiceRepository.AddAsync(newCenterService);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> DeleteCenterService(Guid centerServiceId)
        {
            var foundCenterService=await _unitOfWork.CenterServiceRepository.GetByIdAsync(centerServiceId);
            if (foundCenterService==null)
            {
                throw new Exception("Center service already been removed");
            }
            _unitOfWork.CenterServiceRepository.SoftRemove(foundCenterService);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<ListCenterServiceModel>> GetAllService()
        {
            var listCenterServiceModel=await _unitOfWork.CenterServiceRepository.GetAllCenterService();
            return listCenterServiceModel;
        }
    }
}
