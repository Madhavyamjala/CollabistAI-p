using Collabist.Server.Domain.Enums;

namespace Collabist.Server.Domain.Entities
{
    /*User
        Purpose
            Represents a human user interacting with the system.
        Responsibilities
            Identifies who is performing actions
            Links activity to an organization
            Defines role within the system
        Notes
            Individual plan always has exactly one user
            Role is Owner for Individual plan
            Email is required for future identity integrations
        TODO
            Add external identity provider fields (SSO)
            Add last login tracking
            Add user status lifecycle (invited, active, suspended)
     */

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrganizationId { get; set; }

        public string Email { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Owner;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
