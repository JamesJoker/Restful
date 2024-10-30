using HouseWorkAPI.Modules.Services;
using Newtonsoft.Json;
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
            return Ok(JsonConvert.SerializeObject(_houseWorkService.Members));
        }

        [HttpGet]
        [Route("member/{id}")]
        public IActionResult GetMember(int id)
        {
            return Ok(JsonConvert.SerializeObject(_houseWorkService.GetMember(id)));
        }
    }
}
