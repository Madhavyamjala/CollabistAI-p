using Collabist.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*SemanticIndexingController
        Purpose
            Triggers semantic parsing for indexed files.
        Responsibilities
            Enable controlled semantic processing
        TODO
            Move to background worker
     */

    [ApiController]
    [Route("api/semantic-indexing")]
    public class SemanticIndexingController : ControllerBase
    {
        private readonly SemanticIndexingService _service;

        public SemanticIndexingController(SemanticIndexingService service)
        {
            _service = service;
        }

        [HttpPost("{indexedFileId}")]
        public IActionResult Process(Guid indexedFileId)
        {
            _service.Process(indexedFileId);
            return Ok();
        }
    }
}
