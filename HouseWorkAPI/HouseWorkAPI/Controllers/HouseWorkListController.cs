using HouseWorkAPI.Modules.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HouseWorkAPI.Models;

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

        [HttpPost]
        [Route("member")]
        public IActionResult CreateMember([FromBody] string name)
        {
            if (_houseWorkService.AddMember(name))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("member")]
        public IActionResult ModifyMember([FromBody] Member member)
        {
            if (_houseWorkService.ModifyMember(member.Id, member.Name))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("member")]
        public IActionResult DeleteMember(int id)
        {
            if (_houseWorkService.DeleteMember(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("works")]
        public IActionResult Works()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_houseWorkService.Works));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("work")]
        public IActionResult CreateWork([FromBody] Work work)
        {
            if (_houseWorkService.CreateWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("work")]
        public IActionResult ModifyWork([FromBody] Work work)
        {
            if (_houseWorkService.ModifyWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("work")]
        public IActionResult DeleteWork(Work work)
        {
            if (_houseWorkService.DeleteWork(work))
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet]
        [Route("houseworks")]
        public IActionResult GetHouseWorks([FromQuery] string? from, [FromQuery] string? end)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(end))
            {
                var now = DateTimeOffset.UtcNow;
                return Ok(JsonConvert.SerializeObject(_houseWorkService.GetHouseWorks(now.AddDays(-15), now.AddDays(15))));
            }
            else
            {
                DateTimeOffset f = DateTimeOffset.Parse(from);
                DateTimeOffset e = DateTimeOffset.Parse(end);
                return Ok(JsonConvert.SerializeObject(_houseWorkService.GetHouseWorks(f, e)));
            }
        }

        [HttpPost]
        [Route("housework")]
        public IActionResult CreateHouseWork([FromBody] HouseWork work)
        {
            if (_houseWorkService.CreateOrModifyHouseWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("housework")]
        public IActionResult ModifyHouseWork([FromBody] HouseWork work)
        {
            if (_houseWorkService.CreateOrModifyHouseWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("housework")]
        public IActionResult DeleteHouseWork([FromBody] HouseWork work)
        {
            if (_houseWorkService.DeleteHouseWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
