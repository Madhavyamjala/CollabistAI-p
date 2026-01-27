namespace Collabist.Server.Application.DTOs.KnowledgeBase
{
    /*KnowledgeBaseResponse
        Purpose
            Represents a knowledge base returned to the client.
        Responsibilities
            Exposes safe metadata only
        Notes
            Does not include documents or embeddings
        TODO
            Add document count
     */

    public class KnowledgeBaseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
