using Collabist.Server.Application.Services;
using Collabist.Server.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Collabist.Server.Controllers
{
    /*IndexingController
        Purpose
            Triggers indexing operations.
        Responsibilities
            Starts indexing for approved data sources
        TODO
            Add background worker
     */

    [ApiController]
    [Route("api/indexing")]
    public class IndexingController : ControllerBase
    {
        private readonly CollabistDbContext _db;
        private readonly IndexingService _indexing;

        public IndexingController(
            CollabistDbContext db,
            IndexingService indexing)
        {
            _db = db;
            _indexing = indexing;
        }

        [HttpPost("{dataSourceId}")]
        public IActionResult Index(Guid dataSourceId)
        {
            var source = _db.DataSources.Find(dataSourceId);
            if (source == null)
                return NotFound();

            _indexing.IndexDataSource(source);
            return Ok();
        }
    }
}
