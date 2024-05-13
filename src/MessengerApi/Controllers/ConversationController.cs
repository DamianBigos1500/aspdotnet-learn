using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApi.Interface;
using MessengerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApi.Controllers
{
    [ApiController]
    [Route("api/conversations")]
    public class ConversationController(IConversationService conversationService) : ControllerBase
    {
        private readonly IConversationService _conversationService = conversationService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _conversationService.GetAllAsync();

            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdGroup([FromRoute] Guid id)
        {
            var messages = await _conversationService.GetByIdAsync(id);

            return Ok(messages);
        }
    }
}