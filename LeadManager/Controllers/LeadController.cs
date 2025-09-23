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
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllInvitedAndAccepted();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLeadInputModel model)
        {
            var result = await _service.Create(model);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateLeadInputModel model)
        {
            var result = await _service.Update(model);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpPut("{id}/accept")]
        public async Task<IActionResult> Accept(int id)
        {
            var result = await _service.Accept(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}/decline")]
        public async Task<IActionResult> Decline(int id)
        {
            var result = await _service.Declined(id);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
