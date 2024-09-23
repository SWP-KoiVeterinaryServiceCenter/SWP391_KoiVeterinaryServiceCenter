using Application.IService.Abstraction;
using Application.Model.KoiModel;
using AutoMapper;
using MassTransit.JobService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{

    public class KoiController : BaseController
    {
        private readonly IKoiService _koiService;

        public KoiController(IKoiService koiService)
        {
            _koiService = koiService;
        }

        // GET: api/v1/koi/GetKoiById/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKoiById(Guid id)
        {
            try
            {
                var koi = await _koiService.GetKoiByIdAsync(id);
                if (koi == null)
                {
                    return NotFound(new { message = "Koi not found" });
                }
                return Ok(koi);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKoi()
        {
            try
            {
                var koiList = await _koiService.GetAllKoiAsync();
                return Ok(koiList);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/v1/koi/GetKoiByAccountId/{accountId}
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetKoiByAccountId(Guid accountId)
        {
            try
            {
                var koiList = await _koiService.GetAllKoiByAccountIdAsync(accountId);
                return Ok(koiList);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/v1/koi/AddKoi
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddKoi([FromBody] AddKoiRequest koiRequest)
        {
            try
            {
                var result = await _koiService.AddKoiAsync(koiRequest);
                if (result)
                {
                    return Ok(new { message = "Koi added successfully." });
                }
                return BadRequest("Failed to add koi.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/v1/koi/UpdateKoi/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKoi(Guid id, [FromBody] UpdateKoiRequest koiRequest)
        {
            try
            {
                var result = await _koiService.UpdateKoiAsync(id, koiRequest);
                if (result)
                {
                    return NoContent();
                }
                return NotFound(new { message = "Koi not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/v1/koi/DeleteKoi/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoi(Guid id)
        {
            try
            {
                var result = await _koiService.DeleteKoiAsync(id, Guid.NewGuid()); // Assume DeletedBy comes from authenticated user
                if (result)
                {
                    return NoContent();
                }
                return NotFound(new { message = "Koi not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
