
using MessengerApi.DTOs.Message;
using MessengerApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApi.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController(IMessageService messageService) : ControllerBase
    {
        private readonly IMessageService _messageService = messageService;


        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetAllByUser([FromRoute] Guid id)
        {
            var messages = await _messageService.GetAllByUserAsync(id);

            return Ok(messages);
        }


        [HttpGet("group/{id}")]
        public async Task<IActionResult> GetAllByGroup([FromRoute] Guid id)
        {
            var messages = await _messageService.GetAllByGroupAsync(id);

            return Ok(messages);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageRequestDto messageDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var message = await _messageService.CreateAsync(messageDto);

            if (message == null) return BadRequest();

            return Ok(message);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var message = await _messageService.DeleteAsync(id);

            if (message == null) return BadRequest();

            return Ok(message);

        }

        [HttpPut("{id}/restore")]
        public async Task<IActionResult> Restore([FromRoute] Guid id)
        {
            var message = await _messageService.RestoreAsync(id);
            if (message == null) return BadRequest();

            return Ok(message);
        }

    }
}