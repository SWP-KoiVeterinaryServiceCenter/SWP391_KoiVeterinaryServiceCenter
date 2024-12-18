﻿using Application.Model.RatingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingResponse>> GetAllAsync();
        Task<RatingResponse> GetByIdAsync(Guid id);
        Task<IEnumerable<RatingResponse>> GetallRatingByCurrentUser();
        Task<RatingResponse> CreateAsync(AddRatingRequest request);
        Task<RatingResponse> UpdateAsync(Guid id, UpdateRatingRequest request);
        Task DeleteAsync(Guid id);
    }
}