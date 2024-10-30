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
        public IActionResult CreateMember([FromBody]string name)
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
            return Ok(JsonConvert.SerializeObject(_houseWorkService.Works));
        }

        [HttpPost]
        [Route("work")]
        public IActionResult CreateWork([FromBody]Work work)
        {
            if (_houseWorkService.CreateOrModifyWork(work))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("work")]
        public IActionResult ModifyWork([FromBody] Work work)
        {
            if (_houseWorkService.CreateOrModifyWork(work))
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
    }
}
