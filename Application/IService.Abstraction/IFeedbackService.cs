using Application.Model.FeedbackModel;
using Application.Model.RatingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackResponse>> GetAllAsync();
        Task<FeedbackResponse> GetByIdAsync(Guid AppintmentId);
        Task<FeedbackResponse> CreateAsync(AddFeedbackRequest request);
    }
}
