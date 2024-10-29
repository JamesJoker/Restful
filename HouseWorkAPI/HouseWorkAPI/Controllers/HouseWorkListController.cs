using HouseWorkAPI.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseWorkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseWorkListController(HouseWorkService service) : ControllerBase
    {
        private readonly HouseWorkService _houseWorkService = service;

        [HttpGet]
        [Route("members")]
        public IActionResult Members()
        {
            return Ok(_houseWorkService.Members);
        }
    }
}
