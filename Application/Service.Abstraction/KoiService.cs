using Application.IService.Abstraction;
using Application.IService.Common;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimService _claimService;
        public KoiService(IUnitOfWork unitOfWork,IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _claimService = claimService;
        }

        public async Task<bool> AddKoiAsync(AddKoiRequest koiRequest)
        {
            var koi = new Koi
            {
                KoiName = koiRequest.KoiName,
                Weight = koiRequest.Weight,
                Age = koiRequest.Age,
                Gender = koiRequest.Gender,
                Varieties = koiRequest.Varieties,
                AccountId = _claimService.GetCurrentUserId
            };

            await _unitOfWork.KoiRepository.AddAsync(koi);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<KoiResponse>> GetAllKoiAsync()
        {
            var koiList = await _unitOfWork.KoiRepository.GetAllAsync();

            var koiResponseList = koiList.Select(koi => new KoiResponse
            {
                Id = koi.Id,
                KoiName = koi.KoiName,
                Weight = koi.Weight,
                Age = koi.Age,
                Gender = koi.Gender,
                Varieties = koi.Varieties,
                AccountId=koi.AccountId
            }).ToList();

            return koiResponseList;
        }


        public async Task<KoiResponse> GetKoiByIdAsync(Guid id)
        {
            var koi = await _unitOfWork.KoiRepository.GetByIdAsync(id);
            if (koi == null)
            {
                throw new Exception("Koi not found");
            }

            return new KoiResponse
            {
                KoiName = koi.KoiName,
                Weight = koi.Weight,
                Age = koi.Age,
                Gender = koi.Gender,
                Varieties = koi.Varieties,
                AccountId = koi.AccountId
            };
        }

        public async Task<List<KoiResponse>> GetAllKoiByAccountIdAsync(Guid accountId)
        {
            var koiList = await _unitOfWork.KoiRepository.FindAsync(k => k.AccountId == accountId);

            var koiResponseList = new List<KoiResponse>();
            foreach (var koi in koiList)
            {
                koiResponseList.Add(new KoiResponse
                {
                    KoiName = koi.KoiName,
                    Weight = koi.Weight,
                    Age = koi.Age,
                    Gender = koi.Gender,
                    Varieties = koi.Varieties,
                    AccountId=koi.AccountId
                });
            }

            return koiResponseList;
        }

        public async Task<bool> UpdateKoiAsync(Guid id, UpdateKoiRequest koiRequest)
        {
            var existingKoi = await _unitOfWork.KoiRepository.GetByIdAsync(id);
            if (existingKoi == null)
            {
                throw new Exception("Koi not found");
            }

            existingKoi.KoiName = koiRequest.KoiName;
            existingKoi.Weight = koiRequest.Weight;
            existingKoi.Age = koiRequest.Age;
            existingKoi.Gender = koiRequest.Gender;
            existingKoi.Varieties = koiRequest.Varieties;
            existingKoi.ModificationDate = DateTime.Now;

            _unitOfWork.KoiRepository.Update(existingKoi);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteKoiAsync(Guid id)
        {
            var koi = await _unitOfWork.KoiRepository.GetByIdAsync(id);
            if (koi == null)
            {
                throw new Exception("Koi not found");
            }
             _unitOfWork.KoiRepository.SoftRemove(koi);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }

}
