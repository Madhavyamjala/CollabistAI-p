namespace Collabist.Server.Domain.Entities
{
    /*SemanticDocument
        Purpose
            Stores lightweight semantic understanding of a file.
        Responsibilities
            Enables fast routing and context selection
        Notes
            Generated once per file version
        TODO
            Add confidence score
            Add model identifier
     */

    public class SemanticDocument
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid IndexedFileId { get; set; }

        public string Summary { get; set; } = string.Empty;

        public string Keywords { get; set; } = string.Empty;

        public string DocumentType { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}
