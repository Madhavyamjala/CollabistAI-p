using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Domain.Entities
{
    /*DataSource
        Purpose
            Represents a user-approved source of data, either a folder or a file.
        Responsibilities
            Defines where documents originate from
            Tracks whether ignore rules are applied
            Enables controlled indexing
        Notes
            Paths are read-only
            No recursive access beyond user consent
            .collabistignore affects only this source
        TODO
            Add change detection metadata
            Add indexing schedule configuration
            Add source health status
     */

    public class DataSource
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid KnowledgeBaseId { get; set; }

        public string Path { get; set; } = string.Empty;

        public DataSourceType Type { get; set; }

        public string? IgnoreFilePath { get; set; }

        public DateTime ApprovedAt { get; set; } = DateTime.UtcNow;
    }
}
