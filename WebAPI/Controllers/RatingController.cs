using Application.IService.Abstraction;
using Application.Model.RatingModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRatingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRating = await _ratingService.CreateAsync(request);
            if (createdRating == null)
            {
                return BadRequest("Không thể tạo đánh giá.");
            }

            return CreatedAtAction(nameof(GetById), new { id = createdRating.Id }, createdRating);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRatingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRating = await _ratingService.GetByIdAsync(id);
            if (existingRating == null)
            {
                return NotFound();
            }

            await _ratingService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingRating = await _ratingService.GetByIdAsync(id);
            if (existingRating == null)
            {
                return NotFound();
            }

            await _ratingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
