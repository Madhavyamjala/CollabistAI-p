using Collabist.Server.Application.DTOs.KnowledgeBase;
using Collabist.Server.Application.Services;
using Collabist.Server.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*KnowledgeBaseController
        Purpose
            Exposes knowledge base APIs.
        Responsibilities
            Create and list knowledge bases
        Notes
            Individual plan only
        TODO
            Add authorization
     */

    [ApiController]
    [Route("api/knowledge-bases")]
    public class KnowledgeBaseController : ControllerBase
    {
        private readonly KnowledgeBaseService _service;

        public KnowledgeBaseController(CollabistDbContext db)
        {
            _service = new KnowledgeBaseService(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateKnowledgeBaseRequest request)
        {
            return Ok(_service.Create(request));
        }
    }
}
