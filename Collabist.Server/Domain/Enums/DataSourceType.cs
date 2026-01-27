namespace Collabist.Server.Domain.Enums
{
    /*DataSourceType (Enum)
        Purpose
            Distinguishes between folder-based and file-based sources.
        Responsibilities
            Guides indexing behavior
            Simplifies processing logic
        TODO
            Add support for virtual sources (archives, exports)  
     */

    public enum DataSourceType
    {
        Folder = 0,
        File = 1
    }
}
