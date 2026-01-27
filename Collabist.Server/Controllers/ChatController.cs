using Collabist.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*ChatController
        Purpose
            Handles chat message processing.
        Responsibilities
            Accepts user messages
            Returns assistant responses
        Notes
            Currently routes all requests to Gemini
        TODO
            Add AI mode routing
            Add knowledge base context injection
     */

    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly GeminiService _gemini;

        public ChatController(GeminiService gemini)
        {
            _gemini = gemini;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] ChatRequest request)
        {
            var reply = await _gemini.GenerateAsync(request.Message);
            return Ok(new { reply });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}
