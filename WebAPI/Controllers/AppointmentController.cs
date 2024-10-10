using Application.IService.Abstraction;
using Application.Model.AppointmentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    
    public class AppointmentController :BaseController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppoinment([FromBody]CreateAppointmentModel model)
        {
            var isCreated=await _appointmentService.CreateAppointmentAsync(model);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Appointments()
        {
            var appointmentList=await _appointmentService.GetAllAsync();
            if (appointmentList.Any())
            {
                return Ok(appointmentList);
            }
            return BadRequest();
        }
    }
}
