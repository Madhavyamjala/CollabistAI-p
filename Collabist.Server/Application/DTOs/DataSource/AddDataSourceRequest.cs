using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Application.DTOs.DataSource
{
    /*AddDataSourceRequest
        Purpose
            Represents a request to approve a file system path.
        Responsibilities
            Captures user-approved access scope
        TODO
            Add path normalization
     */

    public class AddDataSourceRequest
    {
        public Guid KnowledgeBaseId { get; set; }

        public string Path { get; set; } = string.Empty;

        public DataSourceType Type { get; set; }

        public string? IgnoreFilePath { get; set; }
    }
}
