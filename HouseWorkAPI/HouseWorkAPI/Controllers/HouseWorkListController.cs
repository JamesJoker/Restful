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

        [HttpGet]
        [Route("works")]
        public IActionResult Works()
        {
            var now = DateTimeOffset.UtcNow;
            return Ok(JsonConvert.SerializeObject(_houseWorkService.GetWorks(now.AddDays(-15), now.AddDays(15))));
        }
    }
}
