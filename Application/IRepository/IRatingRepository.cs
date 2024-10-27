using Application.Model.RatingModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<List<Rating>> GetAllByAccountIdAsync(Guid accountId);
        Task<Rating> GetAssociateAppointmentId(Guid appoitnmentId);
    }
}