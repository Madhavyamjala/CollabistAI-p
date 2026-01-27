namespace Collabist.Server.Domain.Enums
{
    /*PlanType (Enum)
        Purpose
            Defines the active product tier for an organization.
            Used strictly as a feature flag, not billing logic.
        Responsibilities
            Controls which features are enabled or disabled
            Guides UI and backend behavior
        Notes
            Changing plan type should never require schema changes
            PlanType must be checked in service logic, not controllers
        TODO
            Add plan-based feature capability mapping
            Add migration hooks for plan upgrades
     */

    public enum PlanType
    {
        Individual = 0,
        Startup = 1,
        Enterprise = 2
    }
}
