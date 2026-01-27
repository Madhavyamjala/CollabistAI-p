namespace Collabist.Server.Domain.Enums
{
    /*UserRole (Enum)
        Purpose
            Defines permission level of a user.
        Responsibilities
            Distinguishes owners, admins, and members
            Enables future permission enforcement
        Notes
            Individual users are always Owner
            Startup and Enterprise plans will use all roles
        TODO
            Map roles to permission sets
            Support custom roles in enterprise plans
     */

    public enum UserRole
    {
        Owner = 0,   // Individual user
        Admin = 1,   // Startup / Enterprise
        Member = 2
    }
}
