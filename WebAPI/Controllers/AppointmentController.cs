using Application.IService.Abstraction;
using Application.Model.AppointmentModel;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreateAppointment([FromBody]CreateAppointmentModel model)
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
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody]UpdateAppointmentModel updateAppointmentModel)
        {
            var isUpdated=await _appointmentService.UpdateAppointment(id, updateAppointmentModel);
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var isDeleted=await _appointmentService.DeleteAppointmentAsync(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AppointmentDetail(Guid id)
        {
            var appointmentDetail=await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointmentDetail != null)
            {
                return Ok(appointmentDetail);
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CurrentUserAppointments()
        {
            var appointmentList=await _appointmentService.GetCurrentUserAppointments();
            if (appointmentList.Count() > 0)
            {
                return Ok(appointmentList);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> CancelAppointment(Guid id)
        {
            var isCancelled=await _appointmentService.CancelAppointmentAsync(id);
            if (isCancelled)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
