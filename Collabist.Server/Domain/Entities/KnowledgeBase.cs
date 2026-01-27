namespace Collabist.Server.Domain.Entities
{
    /*KnowledgeBase
        Purpose
            Represents a logical collection of documents that are indexed and queried together.
        Responsibilities
            Acts as a boundary for context retrieval
            Enables domain-specific knowledge separation
            Reduces AI cost by limiting context size
        Notes
            Users may have multiple knowledge bases
            Documents belong to exactly one knowledge base
            Queries operate on one knowledge base by default
        TODO
            Add knowledge base visibility settings
            Add archive / disable support
            Add enterprise-level ownership metadata
     */

    public class KnowledgeBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrganizationId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
