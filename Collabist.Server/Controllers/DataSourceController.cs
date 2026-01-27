using Collabist.Server.Application.DTOs.DataSource;
using Collabist.Server.Application.Services;
using Collabist.Server.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*DataSourceController
        Purpose
            Exposes APIs for managing approved file system access.
        Responsibilities
            Add and list data sources
        TODO
            Add delete endpoint
     */

    [ApiController]
    [Route("api/data-sources")]
    public class DataSourceController : ControllerBase
    {
        private readonly DataSourceService _service;

        public DataSourceController(CollabistDbContext db)
        {
            _service = new DataSourceService(db);
        }

        [HttpPost]
        public IActionResult Add(AddDataSourceRequest request)
        {
            return Ok(_service.Add(request));
        }

        [HttpGet("{knowledgeBaseId}")]
        public IActionResult Get(Guid knowledgeBaseId)
        {
            return Ok(_service.GetByKnowledgeBase(knowledgeBaseId));
        }
    }
}
