namespace Collabist.Server.Domain.Enums
{/*DocumentStatus (Enum)
    Purpose
        Tracks the lifecycle of document indexing.
    Responsibilities
        Enables retry logic
        Enables error reporting
        Enables partial indexing states
    TODO
        Add warning state
        Add deprecated status
*/

    public enum DocumentStatus
    {
        Pending = 0,
        Indexed = 1,
        Failed = 2,
        Ignored = 3
    }
}
