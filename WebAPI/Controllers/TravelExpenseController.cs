using Application.IService.Abstraction;
using Application.Model.TravelExpenseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class TravelExpenseController : BaseController
    {
        private readonly ITravelExpenseService _travelExpenseService;
        public TravelExpenseController(ITravelExpenseService travelExpenseService)
        {
            _travelExpenseService = travelExpenseService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTravelExpense(CreateTravelExpenseModel createTravelExpenseModel)
        {
            var isCreated=await _travelExpenseService.CreateTravelExpense(createTravelExpenseModel);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();    
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelExpense(Guid id)
        {
            var isDeleted=await _travelExpenseService.DeleteTravelExpense(id);
            if (isDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> TravelExpenses()
        {
            var listTravelExpense=await _travelExpenseService.GetAllTravelExpenseAsync();
            return Ok(listTravelExpense);
        }
    }
}
