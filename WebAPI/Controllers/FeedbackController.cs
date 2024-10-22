using Application.IService.Abstraction;
using Application.Model.FeedbackModel;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _feedbackService.GetAllAsync();
            return Ok(feedback);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByAccountId(Guid AppointmentId)
        {
            var feedback = await _feedbackService.GetByIdAsync(AppointmentId);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AddFeedback = await _feedbackService.CreateAsync(request);
            if (AddFeedback == null)
            {
                return BadRequest("Không thể tạo đánh giá.");
            }

            return Created(string.Empty, AddFeedback);
        }

    }
}
