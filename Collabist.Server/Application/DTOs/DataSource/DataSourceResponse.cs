using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Application.DTOs.DataSource
{
    /*DataSourceResponse
        Purpose
            Represents a data source attached to a knowledge base.
        Responsibilities
            Exposes metadata only
        Notes
            Does not expose file contents
        TODO
            Add indexing status
     */

    public class DataSourceResponse
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public DataSourceType Type { get; set; }
        public string? IgnoreFilePath { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
