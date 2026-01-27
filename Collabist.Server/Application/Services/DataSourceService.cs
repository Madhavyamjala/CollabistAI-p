using Collabist.Server.Application.DTOs.DataSource;
using Collabist.Server.Domain.Entities;
using Collabist.Server.Infrastructure.Persistence;

namespace Collabist.Server.Application.Services
{
    /*DataSourceService
        Purpose
            Manages data sources attached to knowledge bases.
        Responsibilities
            Add data sources
            List data sources per knowledge base
        Notes
            Does not read files yet
        TODO
            Add duplicate path detection
            Add removal support
     */

    public class DataSourceService
    {
        private readonly CollabistDbContext _db;

        public DataSourceService(CollabistDbContext db)
        {
            _db = db;
        }

        public DataSource Add(AddDataSourceRequest request)
        {
            var ds = new DataSource
            {
                KnowledgeBaseId = request.KnowledgeBaseId,
                Path = request.Path,
                Type = request.Type,
                IgnoreFilePath = request.IgnoreFilePath
            };

            _db.DataSources.Add(ds);
            _db.SaveChanges();

            return ds;
        }

        public IEnumerable<DataSource> GetByKnowledgeBase(Guid knowledgeBaseId)
        {
            return _db.DataSources
                .Where(d => d.KnowledgeBaseId == knowledgeBaseId)
                .ToList();
        }
    }
}
