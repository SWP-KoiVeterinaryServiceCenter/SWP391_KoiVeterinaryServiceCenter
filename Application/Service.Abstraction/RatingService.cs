using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.RatingModel;
using Application.IService.Abstraction;
using Application.IService.Common;
using AutoMapper;
using Domain.Entities;



namespace Application.Service.Abstraction
{
    public class RatingService : IRatingService
    {

        private readonly IUnitOfWork _unitOfWork;

        public RatingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RatingResponse>> GetAllAsync()
        {
            var ratings = await _unitOfWork.RatingRepository.GetAllAsync();
            return ratings.Select(rating => new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RaterId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate
            });
        }

        public async Task<RatingResponse> GetByIdAsync(Guid id)
        {
            var rating = await _unitOfWork.RatingRepository.GetByIdAsync(id);
            if (rating == null) return null;

            return new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RaterId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate
            };
        }

        public async Task<RatingResponse> CreateAsync(AddRatingRequest request)
        {
            var rating = new Rating
            {
                RatingPoint = request.RatingPoint,
                RaterId = request.RaterId,
                AppointmentId = request.AppointmentId,
                CreationDate = DateTime.UtcNow
            };

            await _unitOfWork.RatingRepository.AddAsync(rating);
            await _unitOfWork.SaveChangeAsync();

            return new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RaterId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate
            };
        }

        public async Task UpdateAsync(Guid id, UpdateRatingRequest request)
        {
            var rating = await _unitOfWork.RatingRepository.GetByIdAsync(id);
            if (rating != null)
            {
                rating.RatingPoint = request.RatingPoint;
                rating.ModificationDate = DateTime.UtcNow;

                _unitOfWork.RatingRepository.Update(rating);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var rating = await _unitOfWork.RatingRepository.GetByIdAsync(id);
            if (rating != null)
            {
                _unitOfWork.RatingRepository.SoftRemove(rating);
                await _unitOfWork.SaveChangeAsync();
            }
        }
    }
}
