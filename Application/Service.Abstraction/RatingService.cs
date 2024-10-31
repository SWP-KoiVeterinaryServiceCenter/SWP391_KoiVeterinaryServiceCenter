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
        private readonly IClaimService _claimService;

        public RatingService(IUnitOfWork unitOfWork, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _claimService = claimService;
        }

        public async Task<IEnumerable<RatingResponse>> GetAllAsync()
        {
            var ratings = await _unitOfWork.RatingRepository.GetAllAsync();
            return ratings.Select(rating => new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RatingContent = rating.RatingContent,
                AccountId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate
            });
        }

        public async Task<IEnumerable<RatingResponse>> GetallRatingByCurrentUser()
        {
            var id = _claimService.GetCurrentUserId;
            if (id == null)
            {
                return new List<RatingResponse>();
            }
            var ratings = await _unitOfWork.RatingRepository.GetAllByAccountIdAsync(id);
            return ratings.Select(rating => new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RatingContent = rating.RatingContent,
                AccountId = rating.RaterId,
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
                AccountId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate,
                RatingContent= rating.RatingContent
            };
        }

        public async Task<RatingResponse> CreateAsync(AddRatingRequest request)
        {
            var rater = await _unitOfWork.AccountRepository.GetByIdAsync(request.AccountId);
            if (rater == null)
            {
                throw new ArgumentException("RaterId not found.");
            }
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                throw new ArgumentException("AppointmentId not found.");
            }
            var associatedRating=await _unitOfWork.RatingRepository.GetAssociateAppointmentId(request.AppointmentId);
            if (associatedRating != null)
            {
                throw new Exception("This appointment already being rated");
            }
            var rating = new Rating
            {
                RatingPoint = request.RatingPoint,
                RatingContent = request.RatingContent,
                RaterId = request.AccountId,
                AppointmentId = request.AppointmentId,
            };
            await _unitOfWork.RatingRepository.AddAsync(rating);
            await _unitOfWork.SaveChangeAsync();
            appointment.RatingId = rating.Id;
            _unitOfWork.AppointmentRepository.Update(appointment);
            await _unitOfWork.SaveChangeAsync();
            return new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RatingContent = rating.RatingContent,
                AccountId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate
            };
        }


        public async Task<RatingResponse> UpdateAsync(Guid id, UpdateRatingRequest request)
        {
            var rating = await _unitOfWork.RatingRepository.GetByIdAsync(id);
            if (rating == null)
            {
                throw new KeyNotFoundException("Rating not found.");
            }

            var rater = await _unitOfWork.AccountRepository.GetByIdAsync(request.AccountId);
            if (rater == null)
            {
                throw new ArgumentException("RaterId not found.");
            }

            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(request.AppointmentId);
            if (appointment == null)
            {
                throw new ArgumentException("AppointmentId not found.");
            }

            rating.RatingPoint = request.RatingPoint;
            rating.RatingContent = request.RatingContent;
            rating.RaterId = request.AccountId;
            rating.AppointmentId = request.AppointmentId;

            _unitOfWork.RatingRepository.Update(rating);
            await _unitOfWork.SaveChangeAsync();

            return new RatingResponse
            {
                Id = rating.Id,
                RatingPoint = rating.RatingPoint,
                RatingContent = rating.RatingContent,
                AccountId = rating.RaterId,
                AppointmentId = rating.AppointmentId,
                CreationDate = rating.CreationDate,
            };
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