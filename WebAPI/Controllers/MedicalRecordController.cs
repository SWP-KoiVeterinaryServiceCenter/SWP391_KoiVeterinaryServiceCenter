using Application.IRepository;
using Application.IService.Abstraction;
using Application.Model.MedicalRecordModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class MedicalRecordController : BaseController
    {
        private readonly IMedicalRecordService _medicalRecordService;
        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }
        [Authorize(Roles ="Veterinarian")]
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> CreateMedicalRecord(Guid appointmentId,CreateMedicalRecordModel createMedicalRecordModel)
        {
            var isCreated=await _medicalRecordService.AddMedicalRecord(appointmentId, createMedicalRecordModel);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
