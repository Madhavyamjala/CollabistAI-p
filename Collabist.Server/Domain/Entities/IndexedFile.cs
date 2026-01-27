using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Domain.Entities
{
    /*IndexedFile
        Purpose
            Represents a file discovered during indexing.
        Responsibilities
            Tracks file state and hash for resumability
        Notes
            Does not store file contents
        TODO
            Add embedding reference
     */

    public class IndexedFile
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DataSourceId { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public string FileHash { get; set; } = string.Empty;

        public IndexingStatus Status { get; set; } = IndexingStatus.Pending;

        public DateTime LastIndexedAt { get; set; } = DateTime.UtcNow;
    }
}
