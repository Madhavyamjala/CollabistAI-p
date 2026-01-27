using Collabist.Server.Domain.Constants;
using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Domain.Entities
{
    /*Organization
        Purpose
            Represents the top-level workspace that owns all data.
            Even for an individual user, an organization exists to ensure the system can scale later without refactoring.
        Responsibilities
            Acts as the root boundary for all data
            Defines the current plan type (Individual / Startup / Enterprise)
            Enables future isolation between organizations
        Notes
            For Individual plan, there is exactly one organization
            The name defaults to a personal workspace
            No billing or subscription logic is tied here
        TODO
            Add organization-level metadata (industry, size)
            Add soft-delete support
            Add enterprise identifiers (external directory ID)
     */

    public class Organization
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = DefaultValues.PersonalWorkspaceName;

        public PlanType PlanType { get; set; } = PlanType.Individual;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
