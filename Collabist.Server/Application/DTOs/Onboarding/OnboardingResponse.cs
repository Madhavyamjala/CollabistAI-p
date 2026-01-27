namespace Collabist.Server.Application.DTOs.Onboarding
{
    /*OnboardingResponse
        Purpose
            Represents the result of a successful onboarding operation.
        Responsibilities
            Confirms onboarding completion
            Returns created identifiers
        Notes
            Used by frontend to transition into main app view
        TODO
            Add error metadata
     */

    public class OnboardingResponse
    {
        public Guid OrganizationId { get; set; }

        public Guid UserId { get; set; }

        public Guid KnowledgeBaseId { get; set; }

        public bool Success { get; set; }
    }
}
