using Collabist.Server.Domain.Constants;

namespace Collabist.Server.Application.DTOs.Onboarding
{
    /*OnboardingRequest
        Purpose
            Represents the data submitted by the user during first-time onboarding.
        Responsibilities
            Captures initial workspace configuration
            Captures AI mode preferences
            Captures initial knowledge base name
        Notes
            Used only once per installation in Individual plan
        TODO
            Add validation attributes
            Add startup / enterprise fields later
     */

    public class OnboardingRequest
    {
        public string DisplayName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string InitialKnowledgeBaseName { get; set; } = DefaultValues.InitialKnowledgeBaseName;

        public bool AllowLocalModels { get; set; }

        public bool AllowCompanyCloud { get; set; }

        public bool AllowOwnApi { get; set; }
    }
}
