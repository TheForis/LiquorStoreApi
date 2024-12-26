using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace LiquorStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController : ControllerBase
    {
        private readonly IBeverageService _service;
        public BeverageController(IBeverageService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public ActionResult<List<BeverageDto>> GetAll()
        {
            try
            {
                var result = _service.GetAllBeverages();
                if (result is not null)
                {
                    return Ok(result);
                }
                else 
                {
                    return NotFound("There are no beverages available. Try again later!");
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
