using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Model.FeedbackModel;
using Application.IService.Abstraction;
using Domain.Entities;
using Application.IService.Common;
using Application.IRepository;
using AutoMapper;


namespace Application.Service.Abstraction
{
    public class FeedbackService : IFeedbackRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackResponse>> GetAllAsync()
        {
            var feedback = await _unitOfWork.FeedbackRepository.GetAllAsync();
            return feedback.Select(feedback => new FeedbackResponse
            {
                
                AppointmentID = feedback.AppointmentId,
                FeedbackContent = feedback.FeedbackContent,
                CreationDate = feedback.CreationDate
            });
        }

        public async Task<FeedbackResponse> GetByIdAsync(Guid AppointmentId)
        {
            var feedback = await _unitOfWork.FeedbackRepository.GetByIdAsync(AppointmentId);
            if (feedback == null) return null;

            return new FeedbackResponse
            {


                AppointmentID = feedback.AppointmentId,
                FeedbackContent = feedback.FeedbackContent,
                CreationDate = feedback.CreationDate
            };
        }

        public async Task<FeedbackResponse> CreateAsync(AddFeedbackRequest request)
        {
            var feedback = new Feedback
            {
                
                AppointmentId = request.AppointmentId,
                CreationDate = DateTime.UtcNow
            };

            await _unitOfWork.FeedbackRepository.AddAsync(feedback);
            await _unitOfWork.SaveChangeAsync();

            return new FeedbackResponse
            {
               
                AppointmentID = feedback.AppointmentId,
                FeedbackContent = feedback.FeedbackContent,
                CreationDate = feedback.CreationDate
            };
        }

        
    }
}
