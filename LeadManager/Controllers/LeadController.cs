using LeadManager.Application.Models;
using LeadManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeadManager.API.Controllers
{
    [ApiController]
    [Route("/api/leads")]
    public class LeadController : Controller
    {
        private readonly ILeadService _service;
        public LeadController(ILeadService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateLeadInputModel model)
        {
            var result = _service.Create(model);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, model);
        }

        [HttpPut]
        public IActionResult Put(UpdateLeadInputModel model)
        {
            var result = _service.Update(model);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpPut("{id}/accept")]
        public IActionResult Accept(int id)
        {
            var result = _service.Accept(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}/decline")]
        public IActionResult Decline(int id)
        {
            var result = _service.Declined(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
