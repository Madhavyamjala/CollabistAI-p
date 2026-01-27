using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Domain.Entities
{
    /*Document
        Purpose
            Represents a single indexed file within a knowledge base.
        Responsibilities
            Tracks indexing state
            Stores metadata for retrieval
            Acts as the unit of embedding generation
        Notes
            Content is not stored here
            Embeddings and chunks are stored separately
            Status reflects processing state
        TODO
            Add checksum/hash for change detection
            Add version history
            Add document-level access overrides
      */

    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid KnowledgeBaseId { get; set; }

        public Guid DataSourceId { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public string FileType { get; set; } = string.Empty;

        public DateTime LastModifiedAt { get; set; }

        public DateTime? IndexedAt { get; set; }

        public DocumentStatus Status { get; set; } = DocumentStatus.Pending;
    }
}
