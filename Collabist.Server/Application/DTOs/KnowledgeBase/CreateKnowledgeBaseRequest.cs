namespace Collabist.Server.Application.DTOs.KnowledgeBase
{
    /*CreateKnowledgeBaseRequest
        Purpose
            Represents a request to create a new knowledge base.
        Responsibilities
            Captures user-provided name and description
        Notes
            Individual plan creates personal knowledge bases only
        TODO
            Add validation attributes
     */

    public class CreateKnowledgeBaseRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
