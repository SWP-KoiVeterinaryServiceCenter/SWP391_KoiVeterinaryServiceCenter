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
        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> MedicalRecords(Guid appointmentId)
        {
            var listMedicalRecords=await _medicalRecordService.GetListMedicalRecordByAppointmentIdAsync(appointmentId);
            if(listMedicalRecords.Count > 0)
            {
                return Ok(listMedicalRecords);
            }
            return Ok(listMedicalRecords);
        }
    }
}
