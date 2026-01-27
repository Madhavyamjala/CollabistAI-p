namespace Collabist.Server.Domain.Constants
{
    /*DefaultValues
        Purpose
            Centralized storage for default values used across the application.
        Responsibilities
            Defines initial names and system defaults
            Avoids magic strings in domain and application layers
        Notes
            These values are not user-facing UI strings
            They represent system initialization defaults
        TODO
            Add plan-specific defaults
            Add localization support if needed
     */

    public static class DefaultValues
    {
        public const string PersonalWorkspaceName = "Personal Workspace";

        public const string InitialKnowledgeBaseName = "My Knowledge Base";
    }
}
