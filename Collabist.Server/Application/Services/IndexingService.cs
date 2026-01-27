using Collabist.Server.Domain.Entities;
using Collabist.Server.Domain.Enums;
using Collabist.Server.Infrastructure.Persistence;

namespace Collabist.Server.Application.Services
{
    /*IndexingService
        Purpose
            Coordinates background indexing for data sources.
        Responsibilities
            Discovers files
            Computes hashes
            Persists indexing progress
        Notes
            Safe to restart at any time
        TODO
            Add parallel processing
     */

    public class IndexingService
    {
        private readonly CollabistDbContext _db;
        private readonly FileDiscoveryService _discovery;
        private readonly FileHashService _hash;

        public IndexingService(
            CollabistDbContext db,
            FileDiscoveryService discovery,
            FileHashService hash)
        {
            _db = db;
            _discovery = discovery;
            _hash = hash;
        }

        public void IndexDataSource(DataSource source)
        {
            var ignore = source.IgnoreFilePath != null
                ? File.ReadAllLines(source.IgnoreFilePath)
                : Array.Empty<string>();

            var files = _discovery.Discover(source.Path, ignore);

            foreach (var file in files)
            {
                var hash = _hash.Compute(file);

                var existing = _db.IndexedFiles
                    .FirstOrDefault(f => f.FilePath == file && f.DataSourceId == source.Id);

                if (existing != null && existing.FileHash == hash)
                    continue;

                if (existing == null)
                {
                    existing = new IndexedFile
                    {
                        DataSourceId = source.Id,
                        FilePath = file
                    };

                    _db.IndexedFiles.Add(existing);
                }

                existing.FileHash = hash;
                existing.Status = IndexingStatus.Indexed;
                existing.LastIndexedAt = DateTime.UtcNow;

                _db.SaveChanges();
            }
        }
    }
}
