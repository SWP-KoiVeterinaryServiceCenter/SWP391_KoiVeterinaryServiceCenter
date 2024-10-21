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
        Task<IEnumerable<RatingResponse>> GetAllAsync();
        Task<RatingResponse> GetByIdAsync(Guid AppintmentId);
        Task<RatingResponse> CreateAsync(AddRatingRequest request);
    }
}
